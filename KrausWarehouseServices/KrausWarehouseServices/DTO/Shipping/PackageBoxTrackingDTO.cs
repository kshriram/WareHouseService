using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
using System.Runtime.Serialization;

namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
    public class PackageBoxTrackingDTO
    {
        public PackageBoxTrackingDTO()
        {

        }

        [DataMember]
        public String BOXNUM { get; set; }

        [DataMember]
        public String SKUNumber { get; set; }

        [DataMember]
        public int SKUQuantity { get; set; }

        [DataMember]
        public String BoxLocation { get; set; }

        [DataMember]
        public String Date { get; set; }

        [DataMember]
        public String TrackingNumber { get; set; }

        [DataMember]
        public String Status { get; set; }

        [DataMember]
        public String Carrier { get; set; }

        [DataMember]
        public String Heights { get; set; }

        [DataMember]
        public String Lengths { get; set; }

        [DataMember]
        public String Widths { get; set; }

        [DataMember]
        public String Weights { get; set; }

        [DataMember]
        public String FreightCharges { get; set; }

        public PackageBoxTrackingDTO(PackageBoxTrackingDTO packageDetails)
        {
            if (packageDetails.BOXNUM != null) this.BOXNUM = (String)packageDetails.BOXNUM;
            if (packageDetails.SKUNumber != null) this.SKUNumber = (String)packageDetails.SKUNumber;
            if (packageDetails.SKUQuantity != null) this.SKUQuantity = (Int32)packageDetails.SKUQuantity;
            if (packageDetails.Date == null)
            { this.Date = ("01/01/0001"); }
            else
            {
                this.Date = (String)packageDetails.Date;
            }
            if (packageDetails.TrackingNumber != null) this.TrackingNumber = (String)packageDetails.TrackingNumber;
            if (packageDetails.Status != null) this.Status = (String)packageDetails.Status;
            if (packageDetails.BoxLocation != null) this.BoxLocation = (String)packageDetails.BoxLocation;
            if (packageDetails.Carrier != null) this.Carrier = (String)packageDetails.Carrier;
            if (packageDetails.Heights != null) this.Heights = (String)packageDetails.Heights;
            if (packageDetails.Lengths != null) this.Lengths = (String)packageDetails.Lengths;
            if (packageDetails.Widths != null) this.Widths = (String)packageDetails.Widths;
            if (packageDetails.Weights != null) this.Weights = (String)packageDetails.Weights;
            if (packageDetails.FreightCharges != null) this.FreightCharges = (String)packageDetails.FreightCharges;

        }

    }
}

