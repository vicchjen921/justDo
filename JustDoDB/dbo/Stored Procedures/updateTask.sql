-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[updateTask] (
	@pId bigint,
	@pName nvarchar(200) = NULL, 
	@pDescription text = NULL,
	@pDueDatetime datetime = NULL,
	@pPriority int = NULL -- 0 - default, 1 - low, 2 - middle, 3 - high
	)
AS
BEGIN
	if(@pName is NULL)
		select @pName = Name from Tasks where Id = @pId
	
	if(@pDescription is NULL)
		select @pDescription = Description from Tasks where Id = @pId

	if(@pPriority is NULL)
		select @pPriority = Priority from Tasks where Id = @pId

	if(@pDueDatetime is NULL)
		select @pDueDatetime = DueDatetime from Tasks where Id = @pId
	
	UPDATE [dbo].[Tasks] 
	   SET [Name] = @pName
		  ,[Description] = @pDescription
		  ,[DueDatetime] = @pDueDatetime
 		  ,[Priority] = @pPriority
	 WHERE Id = @pId
END
