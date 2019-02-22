SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS OFF
GO
create procedure [dbo].[getproductsByPage]
(@pname VarChar(100),
@pagesize int,
@pageindex int,
@docount bit)
as
set nocount on
if(@docount=1)
select count(*) from products_view where product_name like '%'+@pname+'%'
else
begin
declare @indextable table(id int identity(1,1),nid int)
declare @PageLowerBound int
declare @PageUpperBound int
set @PageLowerBound=(@pageindex-1)*@pagesize
set @PageUpperBound=@PageLowerBound+@pagesize
set rowcount @PageUpperBound
insert into @indextable(nid) select product_id from products_view  where product_name like '%'+@pname+'%' order by product_id desc
select * from products_view O,@indextable t where O.product_id=t.nid
and t.id between @PageLowerBound+1 and @PageUpperBound order by t.id
end
set nocount off
GO
