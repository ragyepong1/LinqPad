<Query Kind="Expression">
  <Connection>
    <ID>81a75eb9-2d82-4fd3-900a-7cf2f154c463</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

// Get the order totals and basic customer information for each order
from row in Orders
select new
// Initialization List - Google this
{
	Company = row.Customer.CompanyName,
	Contact = row.Customer.ContactName,
	Items = from item in row.OrderDetails
			select new
			{
				ProductName = item.Product.ProductName,
				item.UnitPrice,
				item.Quantity,
				item.Discount,
				Total = item.UnitPrice * item.Quantity // TODO: Apply a discount
			}
}