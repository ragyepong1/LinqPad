<Query Kind="Expression">
  <Connection>
    <ID>a2cd4270-c48b-491e-9255-cb394d12baa2</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eBikes</Database>
  </Connection>
</Query>

from x in PurchaseOrderDetails
where x.PurchaseOrderID == 458
orderby x.PartID
select new
{
	PartID = x.PartID,
	PartDescription = x.Part.Description,
	QuantityOnOrder = x.Part.QuantityOnOrder,
	QuantityOutstanding = x.Quantity
}