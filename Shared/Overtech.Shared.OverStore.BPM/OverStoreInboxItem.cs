using Overtech.API.BPM;
using Overtech.Core.Data;
using Overtech.Shared.BPM;
using System.Runtime.Serialization;

namespace Overtech.Shared.OverStore.BPM
{
    [DataContract]
    public class OverStoreInboxItem : InboxItem
    {
        public OverStoreInboxItem(InboxItem inboxItem, IMapper mapper)
        {

            mapper.Map<InboxItem, OverStoreInboxItem>(inboxItem, this);
        }

        [DataMember]
        public string Description
        {
            get
            {
                return ActionAttributes.TryGetValue<string>("Description");
            }
        }

        [DataMember]
        public string Priority
        {
            get
            {
                return ActionAttributes.TryGetValue<string>("Priority");
            }
        }
    }
}
