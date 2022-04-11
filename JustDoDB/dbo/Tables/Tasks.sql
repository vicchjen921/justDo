CREATE TABLE [dbo].[Tasks] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (200) NULL,
    [Description] TEXT           NULL,
    [DueDatetime] DATETIME       NULL,
    [Priority]    INT            NULL
);

