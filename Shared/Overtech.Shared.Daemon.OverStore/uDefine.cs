using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Data;

namespace uDefine
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PLU
    {
        // [MarshalAsAttribute(UnmanagedType.LPStr, SizeConst = 36)]
        public string Name;     //Name, 36 characters
        public int LFCode;	    //fresh code, 1-999999, uniquely identifies each fresh product
        public string Code;	    // goods no, 10 digits
        public int BarCode;	    //barcode type, 0-99
        public int UnitPrice;	//0-9999999 //unit price, no decimal mode, 0-9999999
        public int WeightUnit;	///Weighing Units 0-12  (0: 50g, 1: g, 2: 10g, 3: 100g, 4: Kg, 5: oz, 6: Lb, 7: 500g, 8: 600g, 9 : PCS (g), 10: PCS (Kg), 11: PCS (oz), 12: PCS (Lb))
        public int Deptment;	// Department, two digits
        public double Tare;	    //Tare, logical conversion should be within 15Kg
        public int ShlefTime;	//0-365 // Shelf life, 0-365
        public int PackageType;	//Package Type 0: Normal 1: Fixed Weight 2: Pricing 3: Fixed Price 4: QR Code
        public double PackageWeight; // Package weight, logical conversion should be within 15Kg
        public int Tolerance;	//0-20 Packaging error, 0-20 
        public byte Message1;	//0-19999 Message 1,
        public byte Reserved;	// // Reserved
        public Int16 Reserved1;	// //Reserved
        public byte Message2;	//0-197 // Message 2, 0- 197
        public byte Reserved2;	// //Reserved
        public byte MultiLabel;	//  Label type 1,2,4,8,16,32,64,128,,3,12 correspond to the label types of the label editor RTLabel.exe (A0, A1, B0, B1, C0, C1, D0, D1, E0, E1)
        public byte Rebate;   //0-99  //discounts
        public int Account;	//Reserved
    }

    public class rtsdrv
    {

        /// <summary>
        ///  Ethernet connection label scale
        /// </summary>
        /// <param name="RefLFZKFileName">, \lfzk.dat， ,,
        ///  fresh font table file name includes the path to XX \ lfzk.dat, currently useless xx for the application installation path (temporarily useless)
        /// </param>
        /// <param name="RefCFGFileName">,,\system.cfg
        //                  Configure the file name, including the path, point to  XX\system.cfg
        /// </param>
        /// <param name="IPAddr">:192.168.2.87
        ///                     Configure the file name, including the path
        /// </param>
        /// <returns>0： ，-1：  -3:
        ///          0: connection succeeded, -1: connection failed -3: abnormal
        /// </returns>
        [DllImport("rtscaledrv.dll")]
        public static extern int rtscaleConnectEx(string RefLFZKFileName,
                       string RefCFGFileName,
                       string IPAddr
                       );
        /// <summary>
        ///  Ethernet disconnect label
        /// </summary>
        /// <param name="IPAddr"> Label scale IP address</param>
        /// <returns>0： ，-1：
        ///  0: connection succeeded, -1: connection failed -3: abnormal
        /// </returns>
        [DllImport("rtscaledrv.dll")]
        public static extern int rtscaleDisConnectEx(string IPAddr);
        /// <summary>
        ///
        ///Connect the label scale to COM port
        /// </summary>
        /// <param name="RefLFZKFileName">, \lfzk.dat， ，,""
        ///  fresh font table file name includes the path to XX \ lfzk.dat, currently useless xx for the application installation path (temporarily useless)
        /// </param>
        /// <param name="RefCFGFileName">,,\system.cfg
        /// The configuration file name, including the path, usually points to XX \ system.cfg
        /// </param>
        /// <param name="SerialNO">,，
        /// Label scale serial number, no use, fill 22
        /// </param>
        /// <param name="CommName">,:COM1,COM2
        ///                   Device name, such as
        /// </param>
        /// <param name="BaudRate">，9600 Baud rate</param>
        /// <returns></returns>
        [DllImport("rtscaledrv.dll")]  //
        public static extern int rtscaleConnect(string RefLFZKFileName,
                       string RefCFGFileName,
                       int SerialNO,
                       string CommName,
                       int BaudRate
                      );

        /// <summary>
        /// Serial port disconnect label
        /// </summary>
        /// <param name="SerialNO">，，
        /// Label scale, no use, fill 22
        /// </param>
        /// <returns>0： ，-1：  -3:
        ///      0: connection succeeded, -1: connection failed -3: abnormal
        /// </returns>
        [DllImport("rtscaledrv.dll")]//
        public static extern int rtscaleDisConnect(int SerialNO);

        /// <summary>
        /// 
        /// Send a group of (4) plu data to the label scale
        /// </summary>
        /// <param name="plu">
        /// plu structure array
        /// </param>
        /// <returns>0： ，-1：
        /// 0: successful, -1: failed
        /// </returns>
        [DllImport("rtscaledrv.dll")]//CharSet = CharSet.Ansi, PreserveSig = false, CallingConvention = CallingConvention.StdCall
        public static extern int rtscaleTransferPLUCluster(PLU[] plu);

        /// <summary>
        ///  
        /// Clear all PLUs
        /// </summary>
        /// <returns>0： ，-1：
        /// 0: successful, -1: failed
        /// </returns>
        [DllImport("rtscaledrv.dll")]
        public static extern int rtscaleClearPLUData();

        /// <summary>
        ///   ,，
        ///   Send information to the label scale, for printing labels, you can print out the custom information
        /// </summary>
        /// <param name="id">，0~19999 </param>
        /// <param name="PMessage">   Message content </param>
        /// <param name="DataLen">DataLen    Message content length  </param>
        /// <returns>0： ，-1：</returns>
        [DllImport("rtscaledrv.dll")]
        public static extern int rtscaleTransferMessage(int id, string PMessage, int DataLen);

        /// <summary>
        ///  Get the current weight
        /// </summary
        /// <param name="dWeight"> weight</param>
        /// <returns>0： ，-1： 
        /// 0: successful, -1: failed
        /// </returns>
        [DllImport("rtscaledrv.dll")]
        public static extern int rtscaleGetPluWeight(ref Double dWeight);

        /// <summary>
        ///()， Send a group of (84) hot keys to the label scale
        /// </summary>
        /// <param name="HotkeyTable"></param>
        /// <param name="TableIndex"></param>
        /// <returns>0： ，-1：
        ///  0: successful, -1: failed
        /// </returns>
        [DllImport("rtscaledrv.dll")]
        public static extern int rtscaleTransferHotkey(int[] HotkeyTable, int TableIndex); //

        /// <summary>
        /// 
        /// Convert a Plu structure to a string of Rongta plu files
        /// </summary>
        /// <param name="LPPLU"> A plu pointer structure</param>
        /// <param name="LPStr">(),
        /// String (one line in a TXP file), this pointer must be pre-allocated space
        /// </param>
        /// <returns> 0: successful, -1: failed</returns>
        [DllImport("rtscaledrv.dll")]//, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
        public static extern int rtscalePLUToStr(PLU[] LPPLU, StringBuilder ptr);

    }
}
