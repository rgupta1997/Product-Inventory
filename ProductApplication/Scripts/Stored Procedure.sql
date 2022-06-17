-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec product_crud_operation null,null,null,null,4,null
Alter  procedure [dbo].[product_crud_operation]
(
@product_id int=null
,@desc varchar(255) =null
,@is_delete bit =null
,@name varchar(255)=null
,@op_type int=null 
,@price decimal(18,2)=null

)

as begin
 
if(@op_type=1) --Insert
begin

Insert into Product(
IsDelete
,Description
,Name
,Price) 
SELECT 0,@desc,@name ,@price

Select 'Product Created Successfully' as result
 

end 
else if(@op_type=2) --Update

begin

Update Product set IsDelete=@is_delete,Description=@desc,Name=@name,Price=@price
where ProductId = @product_id

Select 'Product Updated Successfully' as result
end

 else if(@op_type=3) -- Delete
 begin
  Update Product set IsDelete=1
where ProductId = @product_id

 Select 'Product Deleted Successfully' as result

  end

  else if(@op_type=4) -- Fetch
 begin
 if(@product_id is not null)
 begin
  Select * from Product
  where ProductId=@product_id
  end
  else
  begin
  Select * from Product
  end
  end

   else if(@op_type=5) --Activate the Porduct
 begin
  Update Product set IsDelete=0
where ProductId = @product_id
 Select 'Product Activated Successfully' as result
  end

end 


