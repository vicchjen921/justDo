-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE getAllTasks
AS
BEGIN
	SELECT [Id]
      ,[Name]
      ,[Description]
      ,[DueDatetime]
      ,[Priority]
  FROM [dbo].[Tasks]
END
