CREATE TABLE AutoGenerateCode
(
	CodeID INT IDENTITY(1,1) NOT NULL,
	CodeType VARCHAR(30) NOT NULL,
	LastCodeValue BIGINT NOT NULL,
	CONSTRAINT PK_AutoGenerateCode PRIMARY KEY (CodeID)
)