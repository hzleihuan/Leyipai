SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS OFF
GO
CREATE PROCEDURE [dbo].[UP_GetRecordByPage]
@tblName varchar(255), -- 表名
@fldName varchar(255), -- 主键字段名
@PageSize int = 20, -- 页尺寸
@PageIndex int = 1, -- 页码
@IsReCount bit = 0, -- 返回记录总数, 非 0 值则返回
@OrderType bit = 0, -- 设置排序类型, 非 0 值则降序
@strWhere varchar(1000) = '' -- 查询条件 (注意: 不要加 where)
AS
declare @strSQL varchar(6000) -- 主语句
declare @strTmp varchar(100) -- 临时变量(查询条件过长时可能会出错，可修改100为1000)
declare @strOrder varchar(400) -- 排序类型
if @OrderType != 0
begin
set @strTmp = '<(select min'
set @strOrder = ' order by [' + @fldName +'] desc'
end
else
begin
set @strTmp = '>(select max'
set @strOrder = ' order by [' + @fldName +'] asc'
end
set @strSQL = 'select top ' + str(@PageSize) + ' * from ['
+ @tblName + '] where [' + @fldName + ']' + @strTmp + '(['
+ @fldName + ']) from (select top ' + str((@PageIndex-1)*@PageSize) + ' ['
+ @fldName + '] from [' + @tblName + ']' + @strOrder + ') as tblTmp)'
+ @strOrder
if @strWhere != ''
set @strSQL = 'select top ' + str(@PageSize) + ' * from ['
+ @tblName + '] where [' + @fldName + ']' + @strTmp + '(['
+ @fldName + ']) from (select top ' + str((@PageIndex-1)*@PageSize) + ' ['
+ @fldName + '] from [' + @tblName + '] where ' + @strWhere + ' '
+ @strOrder + ') as tblTmp) and ' + @strWhere + ' ' + @strOrder
if @PageIndex = 1
begin
set @strTmp =''
if @strWhere != ''
set @strTmp = ' where ' + @strWhere
set @strSQL = 'select top ' + str(@PageSize) + ' * from ['
+ @tblName + ']' + @strTmp + ' ' + @strOrder
end
if @IsReCount != 0
set @strSQL = 'select count(*) as Total from [' + @tblName + ']'+' where ' + @strWhere
exec (@strSQL)
GO
