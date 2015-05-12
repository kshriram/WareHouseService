using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.RMA
{
    [DataContract]
  public  class ReturnWithStringDTO
    {
        public ReturnWithStringDTO(ReturnWithStringDTO _return)
        {
            if (_return.ReturnID != Guid.Empty) this.ReturnID = (Guid)_return.ReturnID;
            if (_return.RMANumber != null) this.RMANumber = _return.RMANumber;
            if (_return.ShipmentNumber != null) this.ShipmentNumber = _return.ShipmentNumber;
            if (_return.OrderNumber != null) this.OrderNumber = _return.OrderNumber;
            if (_return.PONumber != null) this.PONumber = _return.PONumber;
            if (_return.OrderDate != null) this.OrderDate = (DateTime)_return.OrderDate;
            if (_return.DeliveryDat != null) this.DeliveryDat = (DateTime)_return.DeliveryDat;
            if (_return.ReturnDate != null) this.ReturnDate = (DateTime)_return.ReturnDate;
            if (_return.ScannedDate != null) this.ScannedDate = (DateTime)_return.ScannedDate;
            if (_return.ExpirationDate != null) this.ExpirationDate = (DateTime)_return.ExpirationDate;
            if (_return.VendorNumber != null) this.VendorNumber = _return.VendorNumber;
            if (_return.VendoeName != null) this.VendoeName = _return.VendoeName;
            if (_return.CustomerName1 != null) this.CustomerName1 = _return.CustomerName1;
            if (_return.CustomerName2 != null) this.CustomerName2 = _return.CustomerName2;
            if (_return.Address1 != null) this.Address1 = _return.Address1;
            if (_return.Address2 != null) this.Address2 = _return.Address2;
            if (_return.Address3 != null) this.Address3 = _return.Address3;
            if (_return.ZipCode != null) this.ZipCode = _return.ZipCode;
            if (_return.City != null) this.City = _return.City;
            if (_return.State != null) this.State = _return.State;
            if (_return.Country != null) this.Country = _return.Country;
            if (_return.ReturnReason != null) this.ReturnReason = _return.ReturnReason;
            if (_return.RMAStatus != null) this.RMAStatus = _return.RMAStatus;
            if (_return.Decision != null) this.Decision = _return.Decision;
            if (_return.CreatedBy != null) this.CreatedBy = _return.CreatedBy;
            if (_return.UpdatedBy != null) this.UpdatedBy = _return.UpdatedBy;

            if (_return.Wrong_RMA_Flg != null) this.Wrong_RMA_Flg = _return.Wrong_RMA_Flg;
            if (_return.Warranty_STA != null) this.Warranty_STA = _return.Warranty_STA;
            if (_return.Setting_Wty_Days != null) this.Setting_Wty_Days = (int)_return.Setting_Wty_Days;
            if (_return.ShipDate_ScanDate_Days_Diff != null) this.ShipDate_ScanDate_Days_Diff = (int)_return.ShipDate_ScanDate_Days_Diff;

            if (_return.CreatesDate != null) this.CreatesDate = (DateTime)_return.CreatesDate;
            if (_return.UpdatedDate != null) this.UpdatedDate = (DateTime)_return.UpdatedDate;
            if (_return.RGAROWID != null) this.RGAROWID = _return.RGAROWID;

            if (_return.CallTag != null) this.CallTag = _return.CallTag;
            if (_return.Ready_To_Export != null) this.Ready_To_Export = _return.Ready_To_Export;
            if (_return.Exported_in_ERP != null) this.Exported_in_ERP = _return.Exported_in_ERP;

            if (_return.ProgressFlag != null) this.ProgressFlag = _return.ProgressFlag;

            if (_return.UpdatedByStr != null) this.UpdatedByStr = _return.UpdatedByStr;

            if (_return.DecisionStr != null) this.DecisionStr = _return.DecisionStr;
            if (_return.RMAStatusStr != null) this.RMAStatusStr = _return.RMAStatusStr;
            if (_return.UpdatedDates != null) this.UpdatedDates = _return.UpdatedDates;
            if (_return.ReturnDates != null) this.ReturnDates = _return.ReturnDates;
            //this.UpdatedByString = _return.UpdatedByString;

            //this.UpdatedByString = _return.DecisionString;

            //this.UpdatedByString = _return.PendingString;



        }
        public ReturnWithStringDTO()
        { }

        [DataMember]
        public string ReturnDates { get; set; }

        [DataMember]
        public string UpdatedDates { get; set; }

        [DataMember]
        public string DecisionStr { get; set; }

        [DataMember]
        public string RMAStatusStr { get; set; }


        [DataMember]
        public string UpdatedByStr { get; set; }


        [DataMember]
        public int? ProgressFlag { get; set; }

        [DataMember]
        public int? Ready_To_Export { get; set; }

        [DataMember]
        public int? Exported_in_ERP { get; set; }

        [DataMember]
        public string CallTag { get; set; }


        [DataMember]
        public Guid ReturnID { get; set; }

        [DataMember]
        public string RMANumber { get; set; }

        [DataMember]
        public string ShipmentNumber { get; set; }

        [DataMember]
        public string OrderNumber { get; set; }

        [DataMember]
        public string PONumber { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public DateTime DeliveryDat { get; set; }

        [DataMember]
        public DateTime ReturnDate { get; set; }

        [DataMember]
        public string VendorNumber { get; set; }

        [DataMember]
        public string VendoeName { get; set; }

        [DataMember]
        public string CustomerName1 { get; set; }

        [DataMember]
        public string CustomerName2 { get; set; }

        [DataMember]
        public string Address1 { get; set; }

        [DataMember]
        public string Address2 { get; set; }

        [DataMember]
        public string Address3 { get; set; }

        [DataMember]
        public string ZipCode { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string ReturnReason { get; set; }

        [DataMember]
        public byte? RMAStatus { get; set; }

        [DataMember]
        public byte? Decision { get; set; }

        [DataMember]
        public Guid? CreatedBy { get; set; }

        [DataMember]
        public Guid? UpdatedBy { get; set; }

        [DataMember]
        public DateTime CreatesDate { get; set; }

        [DataMember]
        public DateTime UpdatedDate { get; set; }

        [DataMember]
        public string RGAROWID { get; set; }

        [DataMember]
        public DateTime ScannedDate { get; set; }

        [DataMember]
        public DateTime ExpirationDate { get; set; }

        [DataMember]
        public string Wrong_RMA_Flg { get; set; }

        [DataMember]
        public string Warranty_STA { get; set; }

        [DataMember]
        public int Setting_Wty_Days { get; set; }

        [DataMember]
        public int ShipDate_ScanDate_Days_Diff { get; set; }
    }
}
