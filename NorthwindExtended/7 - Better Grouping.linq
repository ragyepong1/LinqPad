<Query Kind="Expression">
  <Connection>
    <ID>aa206032-2ab7-413b-b4cc-9dc9b497ff91</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>NorthwindExtended</Database>
  </Connection>
</Query>

// Get the total amount from all orders grouped by customer

from row in Orders
group row by new {row.Customer.CompanyName, row.Customer.ContactName}
					into customerOrders
// orderby row.Customer.CompanyName
select new
// Initialization List - Google this
{
	Customer= customerOrders.Key.CompanyName,
	Customer= customerOrders.Key.ContactName,
	OrderTotal = (from order in row.customerOrders
					from item in order.OrderDetails
				select item.UnitPrice * item.Quantity).Sum(),
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