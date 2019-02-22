SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS OFF
GO
CREATE procedure [dbo].[UP_sys_user_GetList] 
(@user_realname VarChar(50),
@pagesize int,
@pageindex int,
@docount bit)
as
set nocount on
if(@docount=1)
select count(*) from sys_user where 1=1
else
begin
declare @indextable table(id int identity(1,1),nid int)
declare @PageLowerBound int
declare @PageUpperBound int
set @PageLowerBound=(@pageindex-1)*@pagesize
set @PageUpperBound=@PageLowerBound+@pagesize
set rowcount @PageUpperBound
insert into @indextable(nid) select user_id from sys_user  where 1=1 order by user_name desc
select * from sys_user O,@indextable t where O.user_id=t.nid
and t.id between @PageLowerBound+1 and @PageUpperBound order by t.id
end
set nocount off
GO
