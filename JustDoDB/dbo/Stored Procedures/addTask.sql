-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[addTask] (
	@pName nvarchar(200) = '', 
	@pDescription text = '',
	@pDueDateTime datetime,
	@pPriority int = 0 -- 0 - default, 1 - low, 2 - middle, 3 - high
	)
AS
BEGIN
	INSERT INTO [dbo].[Tasks]
           ([Name]
           ,[Description]
		   ,[DueDatetime]
           ,[Priority])
     VALUES
           (@pName
           ,@pDescription
		   ,@pDueDateTime
           ,@pPriority)
END
