<Query Kind="Expression">
  <Connection>
    <ID>a2cd4270-c48b-491e-9255-cb394d12baa2</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eBikes</Database>
  </Connection>
</Query>

from x in PurchaseOrders
where x.Closed == false
&& x.OrderDate.HasValue
&& x.PurchaseOrderNumber.HasValue
select new
{
	ID = x.PurchaseOrderID,
	Order = x.PurchaseOrderNumber,
	OrderDate = x.OrderDate,
	Vender = x.Vendor.VendorName,
	Contact = x.Vendor.Phone
}