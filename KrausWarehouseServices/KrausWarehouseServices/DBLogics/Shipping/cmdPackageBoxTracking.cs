using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.DTO.Shipping;
using KrausWarehouseServices.Connections.Shipping;
using System.Data.Objects;

namespace KrausWarehouseServices.DBLogics.Shipping
{
    public class cmdPackageBoxTracking
    {
        Shipping_ManagerEntities1 entPackageWithBoxInfo = new Shipping_ManagerEntities1();
        public List<PackageBoxTrackingDTO> GetAllPackageBoxTracking(String ShippingNumber)
        {
            //List<PackageWithBoxInfoDTO> _PackageWithBoxInfo = new List<PackageWithBoxInfoDTO>();
            List<PackageBoxTrackingDTO> _PackageBoxTracking = new List<PackageBoxTrackingDTO>();
            try
            {

                var PackageBoxTracking = entPackageWithBoxInfo.ExecuteStoreQuery<PackageBoxTrackingDTO>(@"select distinct(t.BOXNUM), pd.ShipmentLocation BoxLocation,t.trackingNum TrackingNumber,
                                                                                                            t.SRVTYP Carrier,t.Height Heights,t.Length Lengths,t.Width Widths,t.Weight Weights,t.PCKCHG FreightCharges,
                                                                                                            CONVERT(VARCHAR(10), (t.CreatedDateTime), 101) Date,
                                                                                                            case
                                                                                                            when t.Exported = 0 then 'Not Shipped'
                                                                                                            when t.Exported = 1 then 'Shipped'
                                                                                                            end as Status
                                                                                                            from 
                                                                                                            PackageDetail pd 
                                                                                                            left join
                                                                                                            Tracking t on pd.PackingID=t.PackingID
                                                                                                            where t.PackingId in
                                                                                                            (select PackingId from Package where ShippingNum='" + ShippingNumber + "')  and substring(isnull(t.[trackingNum],''),9,2) <> '90'").ToList();


                foreach (var item in PackageBoxTracking)
                {
                    _PackageBoxTracking.Add(item);
                }

            }
            catch (Exception)
            {
            }
            return _PackageBoxTracking;
        }

    }
}
