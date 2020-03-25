using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Overtech.Core.Logger;
using Overtech.Core.Threading;
using Overtech.DataModels.Price;
using Overtech.ServiceContracts.Price;
using Overtech.DataModels.Announcement;
using Overtech.ServiceContracts.Announcement;
using Overtech.ServiceContracts.Security;
using Overtech.ServiceContracts.Store;
using Overtech.ServiceContracts.Accounting;

namespace Overtech.Shared.Daemon.OverStore
{
    class PriceNotificationWorker : DualWorker<IEnumerable<PriceChangeHistory>>
    {
        private readonly ICurrentPricesService _currentPriceService;
        private readonly INotificationService _notificationService;
        private readonly INotificationUserService _notificationUserService;
        private readonly IStoreService _storeService;
        private readonly IUserService _userService;
        private readonly ISaleInvoiceService _saleInvoiceService;

        public PriceNotificationWorker(
            ILoggerFactory loggerFactory,
            IDictionary<string, string> parameters, string name,
            ICurrentPricesService currentPriceService,
            INotificationService notificationService,
            INotificationUserService notificationUserService,
            IStoreService storeService,
            IUserService userService,
            ISaleInvoiceService saleInvoiceService) : base(loggerFactory, parameters, name)
        {
            _currentPriceService = currentPriceService;
            _notificationService = notificationService;
            _notificationUserService = notificationUserService;
            _storeService = storeService;
            _userService = userService;
            _saleInvoiceService = saleInvoiceService;
        }

        public override void ProcessItem(IEnumerable<PriceChangeHistory> item)
        {
            throw new NotSupportedException("Processing is not supported by this worker.");
        }

        public override bool TryFetchItem(out IEnumerable<PriceChangeHistory> item)
        {
            try
            {
                _logger.Debug($"Trying to fetch current prices");
                IEnumerable<PriceChangeHistory> changedPrices = _currentPriceService.ListPriceChanges();
                IEnumerable<long> stores = changedPrices.GroupBy(cp => cp.Store)
                                                        .Select(p => p.First())
                                                        .Select(s => s.Store);

                if (changedPrices.Count() > 0)
                {
                    foreach(long store in stores)
                    {
                        try
                        {
                            IEnumerable<PriceChangeHistory> priceChangesForStore = changedPrices.Where(c => c.Store == store);

                            long notificationId = CreateNotification(store, priceChangesForStore);
                            IEnumerable<long> userIds = GetStoreUsers(store);
                            AssignNotificationToStoreUsers(notificationId, userIds);
                            PublishNotification(notificationId);
                            _currentPriceService.CheckedPricesChangesAsNotified(priceChangesForStore);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error($"Price changes notification can not be created/published for storeId={store}." + ex);
                        }
                    }
                }

                _logger.Debug($"Process EInvoice started");
                try
                {
                    _saleInvoiceService.ProcessCashRegisterEInvoice();
                    _logger.Debug($"Process EInvoice ended");
                }
                catch (Exception ex)
                {
                    _logger.Error($"Process EInvoice error : {ex.Message}");
                }


                _logger.Debug($"Fetch complete.");
                item = null;
                return false;
            }
            catch (Exception ex)
            {
                _logger.Error("Trying to fetch current prices", ex);
                // Wait a little to prevent high CPU situations
                _cancelSpinEvent.WaitOne(10000);
                item = null;
                return false;
            }
        }

        public long CreateNotification(long storeId, IEnumerable<PriceChangeHistory> priceChangesForStore)
        {
            string notificationText = "";

            IEnumerable<PriceChangeHistory> inserted = priceChangesForStore.Where(p => p.OperationCode == "INS");
            IEnumerable<PriceChangeHistory> updated = priceChangesForStore.Where(p => p.OperationCode == "UPD");
            // IEnumerable<PriceChangeHistory> deleted = priceChangesForStore.Where(p => p.OperationCode == "DEL");
      
            if (inserted.Any())
            {
                notificationText += $"{inserted.Count()} adet yeni ürün tanımlanmıştır. " +
                                    $"Lütfen kasa ve terazilerinizi kontrol edip gerekli etiket basımlarını gerçekleştiriniz. ";
                if (inserted.Count() <= 20)
                {
                    notificationText += $"\n\n{"Ürün".PadRight(30)}\tFiyat\n";
                    foreach (PriceChangeHistory p in priceChangesForStore)
                    {
                        notificationText += p.ProductName.PadRight(30).Substring(0, 30) + "\t" + String.Format("{0:0.00}", p.NewPriceAmount) + "\n";
                    }
                }
                notificationText += "\n";
            }
            if (updated.Any())
            {
                if(updated.Count() <= 20)
                {
                    notificationText += $"Aşağıda listelenen {updated.Count()} üründe fiyat değişikliği olmuştur. " +
                                    $"Lütfen kasa ve terazilerinizi kontrol edip gerekli etiket basımlarını gerçekleştiriniz. " +
                                    $"\n\n{"Ürün".PadRight(30)}\tÖnceki\tYeni\n";
                    foreach (PriceChangeHistory p in priceChangesForStore)
                    {
                        notificationText += p.ProductName.PadRight(30).Substring(0, 30) + "\t" + String.Format("{0:0.00}", p.OldPriceAmount) + "\t" + String.Format("{0:0.00}", p.NewPriceAmount) + "\n";
                    }
                } else
                {
                    notificationText += $"{updated.Count()} üründe fiyat değişikliği olmuştur. " +
                                    $"Lütfen kasa ve terazilerinizi kontrol edip gerekli etiket basımlarını gerçekleştiriniz. ";
                }   
                notificationText += "\n";
            }
            //if (deleted.Any())
            //{
            //    notificationText += $"{updated.Count()} üründe kaldırılmıştır. " +
            //                          "\n\nÜrün";

            //    foreach (PriceChangeHistory p in priceChangesForStore)
            //    {
            //        notificationText += p.ProductName + "\n";
            //    }
            //}        

            Notification notification = new Notification();
            notification.Organization = 1;
            notification.Event = 1051;
            notification.NotificationText = notificationText;
            notification.NotificationType = 1;
            notification.NotificationStatus = 1;

            return _notificationService.Create(notification).NotificationId;
        }

        public void AssignNotificationToStoreUsers(long notificationId, IEnumerable<long> userIds)
        {
            foreach(int userId in userIds)
            {
                NotificationUser notUser = new NotificationUser();
                notUser.Notification = notificationId;
                notUser.User = userId;
                notUser.IsRead = false;
                notUser.UserList = new int[1];
                notUser.UserList[0] = userId;
                _notificationUserService.AddNotificationUsers(notUser);
            }
        }

        public IEnumerable<long> GetStoreUsers(long storeId)
        {
            long branch = _storeService.Read(storeId).OrganizationBranch;
            IEnumerable<long> userIds = _userService.List().Where(u => u.Branch == branch && u.Active == true)
                                                           .Select(u => u.UserId);
            return userIds;
        }

        public void PublishNotification(long notificationId)
        {
            Notification notification = _notificationService.Read(notificationId);
            _notificationService.PublishNotification(notification);
        }
    }
}
