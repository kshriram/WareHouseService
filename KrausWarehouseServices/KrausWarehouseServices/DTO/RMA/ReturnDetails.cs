using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KrausWarehouseServices.DTO.RMA
{
    public class ReturnDetails
    {
        public Guid ReturnID { get; set; }
        public String TrackingNumber { get; set; }
    }
}
