using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using KrausWarehouseServices.Connections;

namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
    public class ShipmentDetailPageGrid1DTO
    {

        [DataMember]
        public String ShipmentID { get; set; }

        [DataMember]
        public DateTime? ShippingCreatedTime { get; set; }

        [DataMember]
        public String ShippingDate { get; set; }

        [DataMember]
        public String ShippingTime { get; set; }

        [DataMember]
        public String OrderID { get; set; }

        [DataMember]
        public String PONumber { get; set; }

        [DataMember]
        public String PartnerID { get; set; }

        [DataMember]
        public String DeliveryMode { get; set; }

        [DataMember]
        public String Carrier { get; set; }

        [DataMember]
        public String ExpectedShipDate { get; set; }

        [DataMember]
        public int shqty { get; set; }

        [DataMember]
        public int pkqty { get; set; }

        [DataMember]
        public int TrkCount { get; set; }

        [DataMember]
        public int BoxCount { get; set; }

        [DataMember]
        public String ShipmentStatus { get; set; }

        public ShipmentDetailPageGrid1DTO()
        {
        }

        public ShipmentDetailPageGrid1DTO(ShipmentDetailPageGrid1DTO _shipping)
        {
            if (_shipping.ShipmentID != null) this.ShipmentID = (String)_shipping.ShipmentID;
            if (_shipping.ShippingCreatedTime != null) this.ShippingCreatedTime = (DateTime)_shipping.ShippingCreatedTime;
            if (_shipping.ShippingDate != null) this.ShippingDate = (String)_shipping.ShippingDate;
            if (_shipping.ShippingTime != null) this.ShippingTime = (String)_shipping.ShippingTime;
            if (_shipping.OrderID != null) this.OrderID = (String)_shipping.OrderID;
            if (_shipping.PONumber != null) this.PONumber = (String)_shipping.PONumber;
            if (_shipping.PartnerID != null) this.PartnerID = (String)_shipping.PartnerID;
            if (_shipping.DeliveryMode != null) this.DeliveryMode = (String)_shipping.DeliveryMode;
            if (_shipping.Carrier != null) this.Carrier = (String)_shipping.Carrier;
            if (_shipping.ExpectedShipDate != null) this.ExpectedShipDate = (String)_shipping.ExpectedShipDate;
            if (_shipping.shqty != null) this.shqty = (int)_shipping.shqty;
            if (_shipping.pkqty != null) this.pkqty = (int)_shipping.pkqty;
            if (_shipping.TrkCount != null) this.TrkCount = (int)_shipping.TrkCount;
            if (_shipping.BoxCount != null) this.BoxCount = (int)_shipping.BoxCount;
            if (_shipping.ShipmentStatus != null) this.ShipmentStatus = (String)_shipping.ShipmentStatus;

        }
    }
}
