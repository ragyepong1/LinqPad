<Query Kind="Statements">
  <Connection>
    <ID>613f289d-4e6f-494f-8138-720948994a90</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind_DMIT2018</Database>
  </Connection>
</Query>

// TODO 5) Most Popular products sold(qty) by year and month

var ProductQuantitiesByYearAndMonth = 
	from soldItem in OrderDetails
	group soldItem by new 	{
								soldItem.Product.ProductName,
								soldItem.Order.OrderDate.Value.Year,
								soldItem.Order.OrderDate.Value.Month
							}
		into groupedOrderDetails
	orderby groupedOrderDetails.Key.Year, groupedOrderDetails.Key.Month
	// Temporary where clause, for a single months worth
	where 
		groupedOrderDetails.Key.Year == 1996
		&& groupedOrderDetails.Key.Month == 7
	select new 	{
					Product = groupedOrderDetails.Key.ProductName,
					Year = groupedOrderDetails.Key.Year,
					Month = groupedOrderDetails.Key.Month,
					TotalQuantitySold = groupedOrderDetails.Sum(detailItem => detailItem.Quantity)
				};
// See the output
//ProductQuantitiesByYearAndMonth.Dump("Intermediate Results");
var maxQty = ProductQuantitiesByYearAndMonth.Max(x => x.TotalQuantitySold);
maxQty.Dump("Max for the whole collection");
var maxItem = 	from product in ProductQuantitiesByYearAndMonth
				where	product.TotalQuantitySold == maxQty
				select product;
maxItem.Dump("Max Item");

//from item in Products
//select new
//{
//	Name = item.ProductName,
//	TotalQuantities = item.OrderDetails.Sum(sold => sold.Quantity),
//	Quantity = from sold in item.OrderDetails
//				select sold.Quantity,
//	OrderQuantitesByYearAndMonth = from sold in item.OrderDetails
//									group sold by new{Year = sold.Order.OrderDate.Value.Year,
//														Month = sold.Order.OrderDate.Value.Month}
//									into  groupedOrderDetails
//									select new
//									{
//										Year = groupedOrderDetails.Key.Year,
//										Month = groupedOrderDetails.Key.Month,
//										Quantities = groupedOrderDetails.Sum(detail => detail.Quantity)
//									}
//}