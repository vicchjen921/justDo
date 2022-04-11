-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[removeTask] (
	@pId bigint
	)
AS
BEGIN
	DELETE FROM [dbo].[Tasks]
      WHERE Id = @pId
END
