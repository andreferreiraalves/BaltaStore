CREATE PROCEDURE spGetCustomerOrdersCount
	@Document VARCHAR(11)
as
	select C.[Id], CONCAT(C.[FirstName], ' ', C.[LastName]), C.[Document], count(O.Id)
	  from [Customer] C
			inner join [Order] O on O.[CustomerId] = c.[Id]
	 where C.[Document] = @Document
	 group by C.[Id], CONCAT(C.[FirstName], ' ', C.[LastName]), C.[Document]