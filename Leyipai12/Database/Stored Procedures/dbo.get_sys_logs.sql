SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS OFF
GO
CREATE procedure [dbo].[get_sys_logs] 
(@startIndex int,
@endIndex int,
@docount bit)
as
set nocount on
if(@docount=1)
select count(*) from sys_log
else
begin
declare @indextable table(id int identity(1,1),nid int)
set rowcount @endIndex
insert into @indextable(nid) select id from sys_log  order by id desc
select * from sys_log O,@indextable t where O.id=t.nid
and t.id between @startIndex and @endIndex order by t.id
end
set nocount off
GO
