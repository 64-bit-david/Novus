--FOR REFERENCE ONLY
--USE IN SSMS TO CREATE STORED PROCEDURE

CREATE PROCEDURE InsertDiagnosticsLogs
(
    @Message NVARCHAR(MAX),
    @Timestamp DATETIME,
    @MessageType NVARCHAR(50)
)
AS
BEGIN
    INSERT INTO Logs (Message, Timestamp, MessageType)
    VALUES (@Message, @Timestamp, @MessageType)
END