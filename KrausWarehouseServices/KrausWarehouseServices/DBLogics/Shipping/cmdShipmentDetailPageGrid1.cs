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
    public class cmdShipmentDetailPageGrid1
    {
        Shipping_ManagerEntities1 entPackageWithBoxInfo = new Shipping_ManagerEntities1();
        public List<ShipmentDetailPageGrid1DTO> GetAllShipmentDetailPageGrid1(String Date)
        {
            //List<PackageWithBoxInfoDTO> _PackageWithBoxInfo = new List<PackageWithBoxInfoDTO>();
            List<ShipmentDetailPageGrid1DTO> _ShipmentDetailPageGrid1 = new List<ShipmentDetailPageGrid1DTO>();
            try
            {

                var ShipmentDetailPageGrid1 = entPackageWithBoxInfo.ExecuteStoreQuery<ShipmentDetailPageGrid1DTO>(@"select
                                                                                                                    *,
                                                                                                                    case
                                                                                                                    when ShippingCreatedTime is null then 'Waiting to be Packed'
                                                                                                                    when pkqty <> 0 and shqty > pkqty then 'Partially Packed'
                                                                                                                    when pkqty <> 0 and TrkCount <> 0 and shqty = pkqty and TrkCount = BoxCount then 'Shipped'
                                                                                                                    when pkqty <> 0 and shqty = pkqty and TrkCount <> BoxCount then 'Completely Packed - Waiting for Tracking'
                                                                                                                    end as [ShipmentStatus]
                                                                                                                    from
                                                                                                                    (select distinct
                                                                                                                    SageSh.SDHNUM_0 ShipmentID ,
                                                                                                                    s.CreatedDateTime ShippingCreatedTime,
                                                                                                                    CONVERT(VARCHAR(10), s.CreatedDateTime, 101) ShippingDate,
                                                                                                                    CONVERT(VARCHAR(10), (s.CreatedDateTime), 114) ShippingTime,
                                                                                                                    SageSo.SOHNUM_0 OrderID,
                                                                                                                    SageSo.CUSORDREF_0 PONumber,
                                                                                                                    SageSo.BPCORD_0 PartnerID,
                                                                                                                    isnull(s.DeliveryMode,YCARSRV_0) DeliveryMode,
                                                                                                                    isnull(s.Carrier,SageSh.BPTNUM_0) Carrier,
                                                                                                                    CONVERT(VARCHAR(10), SageSo.SHIDAT_0, 101) ExpectedShipDate,
 
                                                                                                                    (select sum(Quantity) from Get_Shipping_Data gsd where SageSh.SDHNUM_0 = gsd.ShipmentID and LineType <> 6) shqty,
 
                                                                                                                    ISNULL((select sum(SKUQuantity) from
                                                                                                                    PackageDetail pkdi
                                                                                                                    left join Package pki on pki.PackingID = pkdi.PackingID
                                                                                                                    left join Shipping si on si.ShippingID = pki.ShippingID
                                                                                                                    where si.ShippingID = s.ShippingID
                                                                                                                    ),0) pkqty,
 
                                                                                                                    (select count(distinct ti.TrackingNum) from
                                                                                                                    Tracking ti
                                                                                                                    left join PackageDetail pkdi on pkdi.BoxNumber = ti.BOXNUM
                                                                                                                    left join Package pki on pki.PackingID = pkdi.PackingID
                                                                                                                    left join Shipping si on si.ShippingID = pki.ShippingID
                                                                                                                    where si.ShippingID = s.ShippingID
                                                                                                                    AND substring(isnull(ti.[TrackingNum_UPS],''),9,2) <> '90' and
                                                                                                                    ti.TrackingNum not in (Select TrackingNum from Tracking where VOIIND = 'Y')
                                                                                                                    ) TrkCount,
 
                                                                                                                    (select count(distinct BoxNumber) from
                                                                                                                    PackageDetail pkdi
                                                                                                                    left join Package pki on pki.PackingID = pkdi.PackingID
                                                                                                                    left join Shipping si on si.ShippingID = pki.ShippingID
                                                                                                                    where si.ShippingID = s.ShippingID) BoxCount
 
                                                                                                                    from
                                                                                                                    x3v6.PRODUCTION.SDELIVERY SageSh
                                                                                                                    left join Shipping s on SageSh.SDHNUM_0 = s.ShippingNum COLLATE Latin1_General_BIN
                                                                                                                    left join Package pk on s.ShippingID = pk.ShippingID
                                                                                                                    left join PackageDetail pkd on pk.PackingID = pkd.PackingID
                                                                                                                    left join Tracking t on pkd.BoxNumber = t.BOXNUM
                                                                                                                    inner join x3v6.PRODUCTION.SORDER SageSo on SageSh.SOHNUM_0 = SageSo.SOHNUM_0
                                                                                                                    WHERE SageSh.CREDAT_0 = '" + Date + "'  AND SageSo.CUSORDREF_0 not like 'WHS%' and SageSo.CUSORDREF_0 not like '%TEST%') as Shipping_Data ORDER BY 1").ToList();


                foreach (var item in ShipmentDetailPageGrid1)
                {
                    _ShipmentDetailPageGrid1.Add(item);
                }

            }
            catch (Exception)
            {
            }
            return _ShipmentDetailPageGrid1;
        }



        public List<ShipmentDetailPageGrid1DTO> GetAllShipmentDetailPageGrid1Total(String Date)
        {
            //List<PackageWithBoxInfoDTO> _PackageWithBoxInfo = new List<PackageWithBoxInfoDTO>();
            List<ShipmentDetailPageGrid1DTO> _ShipmentDetailPageGrid1 = new List<ShipmentDetailPageGrid1DTO>();
            try
            {

                var ShipmentDetailPageGrid1 = entPackageWithBoxInfo.ExecuteStoreQuery<ShipmentDetailPageGrid1DTO>(@"select
                                                                                                                            *,
                                                                                                                            case
                                                                                                                            when ShippingCreatedTime is null then 'Waiting to be Packed'
                                                                                                                            when pkqty <> 0 and shqty > pkqty then 'Partially Packed'
                                                                                                                            when pkqty <> 0 and TrkCount <> 0 and shqty = pkqty and TrkCount = BoxCount then 'Shipped'
                                                                                                                            when pkqty <> 0 and shqty = pkqty and TrkCount <> BoxCount then 'Completely Packed - Waiting for Tracking'
                                                                                                                            end as [ShipmentStatus]
                                                                                                                            from
                                                                                                                            (select distinct
                                                                                                                            SageSh.SDHNUM_0 ShipmentID ,
                                                                                                                            s.CreatedDateTime ShippingCreatedTime,
                                                                                                                            CONVERT(VARCHAR(10), s.CreatedDateTime, 101) ShippingDate,
                                                                                                                            CONVERT(VARCHAR(10), (s.CreatedDateTime), 114) ShippingTime,
                                                                                                                            SageSo.SOHNUM_0 OrderID,
                                                                                                                            SageSo.CUSORDREF_0 PONumber,
                                                                                                                            SageSo.BPCORD_0 PartnerID,
                                                                                                                            isnull(s.DeliveryMode,YCARSRV_0) DeliveryMode,
                                                                                                                            isnull(s.Carrier,SageSh.BPTNUM_0) Carrier,
                                                                                                                            CONVERT(VARCHAR(10), SageSo.SHIDAT_0, 101) ExpectedShipDate,
 
                                                                                                                            (select sum(Quantity) from Get_Shipping_Data gsd where SageSh.SDHNUM_0 = gsd.ShipmentID and LineType <> 6) shqty,
 
                                                                                                                            ISNULL((select sum(SKUQuantity) from
                                                                                                                            PackageDetail pkdi
                                                                                                                            left join Package pki on pki.PackingID = pkdi.PackingID
                                                                                                                            left join Shipping si on si.ShippingID = pki.ShippingID
                                                                                                                            where si.ShippingID = s.ShippingID
                                                                                                                            ),0) pkqty,
 
                                                                                                                            (select count(distinct ti.TrackingNum) from
                                                                                                                            Tracking ti
                                                                                                                            left join PackageDetail pkdi on pkdi.BoxNumber = ti.BOXNUM
                                                                                                                            left join Package pki on pki.PackingID = pkdi.PackingID
                                                                                                                            left join Shipping si on si.ShippingID = pki.ShippingID
                                                                                                                            where si.ShippingID = s.ShippingID
                                                                                                                            AND substring(isnull(ti.[TrackingNum_UPS],''),9,2) <> '90' and
                                                                                                                            ti.TrackingNum not in (Select TrackingNum from Tracking where VOIIND = 'Y')
                                                                                                                            ) TrkCount,
 
                                                                                                                            (select count(distinct BoxNumber) from
                                                                                                                            PackageDetail pkdi
                                                                                                                            left join Package pki on pki.PackingID = pkdi.PackingID
                                                                                                                            left join Shipping si on si.ShippingID = pki.ShippingID
                                                                                                                            where si.ShippingID = s.ShippingID) BoxCount
 
                                                                                                                            from
                                                                                                                            x3v6.PRODUCTION.SDELIVERY SageSh
                                                                                                                            left join Shipping s on SageSh.SDHNUM_0 = s.ShippingNum COLLATE Latin1_General_BIN
                                                                                                                            left join Package pk on s.ShippingID = pk.ShippingID
                                                                                                                            left join PackageDetail pkd on pk.PackingID = pkd.PackingID
                                                                                                                            left join Tracking t on pkd.BoxNumber = t.BOXNUM
                                                                                                                            inner join x3v6.PRODUCTION.SORDER SageSo on SageSh.SOHNUM_0 = SageSo.SOHNUM_0
                                                                                                                            WHERE SageSh.CREDAT_0 BETWEEN  '3/1/2015' AND '" + Date + "' AND SageSo.CUSORDREF_0 not like 'WHS%' and SageSo.CUSORDREF_0 not like '%TEST%') as Shipping_Data ORDER BY 1 ").ToList();


                foreach (var item in ShipmentDetailPageGrid1)
                {
                    _ShipmentDetailPageGrid1.Add(item);
                }

            }
            catch (Exception)
            {
            }
            return _ShipmentDetailPageGrid1;
        }


        public List<ShipmentDetailPageGrid1DTO> GetAllShipmentDetailPageGrid1ByDateSearch(String Date1, String Date2)
        {
            //List<PackageWithBoxInfoDTO> _PackageWithBoxInfo = new List<PackageWithBoxInfoDTO>();
            List<ShipmentDetailPageGrid1DTO> _ShipmentDetailPageGrid1 = new List<ShipmentDetailPageGrid1DTO>();
            try
            {

                var ShipmentDetailPageGrid1 = entPackageWithBoxInfo.ExecuteStoreQuery<ShipmentDetailPageGrid1DTO>(@"select
                                                                                                                            *,
                                                                                                                            case
                                                                                                                            when ShippingCreatedTime is null then 'Waiting to be Packed'
                                                                                                                            when pkqty <> 0 and shqty > pkqty then 'Partially Packed'
                                                                                                                            when pkqty <> 0 and TrkCount <> 0 and shqty = pkqty and TrkCount = BoxCount then 'Shipped'
                                                                                                                            when pkqty <> 0 and shqty = pkqty and TrkCount <> BoxCount then 'Completely Packed - Waiting for Tracking'
                                                                                                                            end as [ShipmentStatus]
                                                                                                                            from
                                                                                                                            (select distinct
                                                                                                                            SageSh.SDHNUM_0 ShipmentID ,
                                                                                                                            s.CreatedDateTime ShippingCreatedTime,
                                                                                                                            CONVERT(VARCHAR(10), s.CreatedDateTime, 101) ShippingDate,
                                                                                                                            CONVERT(VARCHAR(10), (s.CreatedDateTime), 114) ShippingTime,
                                                                                                                            SageSo.SOHNUM_0 OrderID,
                                                                                                                            SageSo.CUSORDREF_0 PONumber,
                                                                                                                            SageSo.BPCORD_0 PartnerID,
                                                                                                                            isnull(s.DeliveryMode,YCARSRV_0) DeliveryMode,
                                                                                                                            isnull(s.Carrier,SageSh.BPTNUM_0) Carrier,
                                                                                                                            CONVERT(VARCHAR(10), SageSo.SHIDAT_0, 101) ExpectedShipDate,
 
                                                                                                                            (select sum(Quantity) from Get_Shipping_Data gsd where SageSh.SDHNUM_0 = gsd.ShipmentID and LineType <> 6) shqty,
 
                                                                                                                            ISNULL((select sum(SKUQuantity) from
                                                                                                                            PackageDetail pkdi
                                                                                                                            left join Package pki on pki.PackingID = pkdi.PackingID
                                                                                                                            left join Shipping si on si.ShippingID = pki.ShippingID
                                                                                                                            where si.ShippingID = s.ShippingID
                                                                                                                            ),0) pkqty,
 
                                                                                                                            (select count(distinct ti.TrackingNum) from
                                                                                                                            Tracking ti
                                                                                                                            left join PackageDetail pkdi on pkdi.BoxNumber = ti.BOXNUM
                                                                                                                            left join Package pki on pki.PackingID = pkdi.PackingID
                                                                                                                            left join Shipping si on si.ShippingID = pki.ShippingID
                                                                                                                            where si.ShippingID = s.ShippingID
                                                                                                                            AND substring(isnull(ti.[TrackingNum_UPS],''),9,2) <> '90' and
                                                                                                                            ti.TrackingNum not in (Select TrackingNum from Tracking where VOIIND = 'Y')
                                                                                                                            ) TrkCount,
 
                                                                                                                            (select count(distinct BoxNumber) from
                                                                                                                            PackageDetail pkdi
                                                                                                                            left join Package pki on pki.PackingID = pkdi.PackingID
                                                                                                                            left join Shipping si on si.ShippingID = pki.ShippingID
                                                                                                                            where si.ShippingID = s.ShippingID) BoxCount
 
                                                                                                                            from
                                                                                                                            x3v6.PRODUCTION.SDELIVERY SageSh
                                                                                                                            left join Shipping s on SageSh.SDHNUM_0 = s.ShippingNum COLLATE Latin1_General_BIN
                                                                                                                            left join Package pk on s.ShippingID = pk.ShippingID
                                                                                                                            left join PackageDetail pkd on pk.PackingID = pkd.PackingID
                                                                                                                            left join Tracking t on pkd.BoxNumber = t.BOXNUM
                                                                                                                            inner join x3v6.PRODUCTION.SORDER SageSo on SageSh.SOHNUM_0 = SageSo.SOHNUM_0
                                                                                                                            WHERE SageSh.CREDAT_0 BETWEEN  '" + Date1 + "' AND '" + Date2 + "' AND SageSo.CUSORDREF_0 not like 'WHS%' and SageSo.CUSORDREF_0 not like '%TEST%') as Shipping_Data ORDER BY 1 ").ToList();


                foreach (var item in ShipmentDetailPageGrid1)
                {
                    _ShipmentDetailPageGrid1.Add(item);
                }

            }
            catch (Exception)
            {
            }
            return _ShipmentDetailPageGrid1;
        }


        public List<ShipmentDetailPageGrid1DTO> GetAllShipmentDetailPageGrid1ByDateSearchExpected(String Date1, String Date2)
        {
            //List<PackageWithBoxInfoDTO> _PackageWithBoxInfo = new List<PackageWithBoxInfoDTO>();
            List<ShipmentDetailPageGrid1DTO> _ShipmentDetailPageGrid1 = new List<ShipmentDetailPageGrid1DTO>();
            try
            {

                var ShipmentDetailPageGrid1 = entPackageWithBoxInfo.ExecuteStoreQuery<ShipmentDetailPageGrid1DTO>(@"select
                                                                                                                            *,
                                                                                                                            case
                                                                                                                            when ShippingCreatedTime is null then 'Waiting to be Packed'
                                                                                                                            when pkqty <> 0 and shqty > pkqty then 'Partially Packed'
                                                                                                                            when pkqty <> 0 and TrkCount <> 0 and shqty = pkqty and TrkCount = BoxCount then 'Shipped'
                                                                                                                            when pkqty <> 0 and shqty = pkqty and TrkCount <> BoxCount then 'Completely Packed - Waiting for Tracking'
                                                                                                                            end as [ShipmentStatus]
                                                                                                                            from
                                                                                                                            (select distinct
                                                                                                                            SageSh.SDHNUM_0 ShipmentID ,
                                                                                                                            s.CreatedDateTime ShippingCreatedTime,
                                                                                                                            CONVERT(VARCHAR(10), s.CreatedDateTime, 101) ShippingDate,
                                                                                                                            CONVERT(VARCHAR(10), (s.CreatedDateTime), 114) ShippingTime,
                                                                                                                            SageSo.SOHNUM_0 OrderID,
                                                                                                                            SageSo.CUSORDREF_0 PONumber,
                                                                                                                            SageSo.BPCORD_0 PartnerID,
                                                                                                                            isnull(s.DeliveryMode,YCARSRV_0) DeliveryMode,
                                                                                                                            isnull(s.Carrier,SageSh.BPTNUM_0) Carrier,
                                                                                                                            CONVERT(VARCHAR(10), SageSo.SHIDAT_0, 101) ExpectedShipDate,
 
                                                                                                                            (select sum(Quantity) from Get_Shipping_Data gsd where SageSh.SDHNUM_0 = gsd.ShipmentID and LineType <> 6) shqty,
 
                                                                                                                            ISNULL((select sum(SKUQuantity) from
                                                                                                                            PackageDetail pkdi
                                                                                                                            left join Package pki on pki.PackingID = pkdi.PackingID
                                                                                                                            left join Shipping si on si.ShippingID = pki.ShippingID
                                                                                                                            where si.ShippingID = s.ShippingID
                                                                                                                            ),0) pkqty,
 
                                                                                                                            (select count(distinct ti.TrackingNum) from
                                                                                                                            Tracking ti
                                                                                                                            left join PackageDetail pkdi on pkdi.BoxNumber = ti.BOXNUM
                                                                                                                            left join Package pki on pki.PackingID = pkdi.PackingID
                                                                                                                            left join Shipping si on si.ShippingID = pki.ShippingID
                                                                                                                            where si.ShippingID = s.ShippingID
                                                                                                                            AND substring(isnull(ti.[TrackingNum_UPS],''),9,2) <> '90' and
                                                                                                                            ti.TrackingNum not in (Select TrackingNum from Tracking where VOIIND = 'Y')
                                                                                                                            ) TrkCount,
 
                                                                                                                            (select count(distinct BoxNumber) from
                                                                                                                            PackageDetail pkdi
                                                                                                                            left join Package pki on pki.PackingID = pkdi.PackingID
                                                                                                                            left join Shipping si on si.ShippingID = pki.ShippingID
                                                                                                                            where si.ShippingID = s.ShippingID) BoxCount
 
                                                                                                                            from
                                                                                                                            x3v6.PRODUCTION.SDELIVERY SageSh
                                                                                                                            left join Shipping s on SageSh.SDHNUM_0 = s.ShippingNum COLLATE Latin1_General_BIN
                                                                                                                            left join Package pk on s.ShippingID = pk.ShippingID
                                                                                                                            left join PackageDetail pkd on pk.PackingID = pkd.PackingID
                                                                                                                            left join Tracking t on pkd.BoxNumber = t.BOXNUM
                                                                                                                            inner join x3v6.PRODUCTION.SORDER SageSo on SageSh.SOHNUM_0 = SageSo.SOHNUM_0
                                                                                                                            WHERE SageSo.SHIDAT_0 BETWEEN  '" + Date1 + "' AND '" + Date2 + "' AND SageSo.CUSORDREF_0 not like 'WHS%' and SageSo.CUSORDREF_0 not like '%TEST%') as Shipping_Data ORDER BY 1 ").ToList();


                foreach (var item in ShipmentDetailPageGrid1)
                {
                    _ShipmentDetailPageGrid1.Add(item);
                }

            }
            catch (Exception)
            {
            }
            return _ShipmentDetailPageGrid1;
        }

    }
}
