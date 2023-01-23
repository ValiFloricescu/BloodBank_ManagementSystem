CREATE TABLE [dbo].[PatientTbl] (
    [PNum]     INT          IDENTITY (500, 1) NOT NULL,
    [PName]    VARCHAR (50) NOT NULL,
    [PAge]     INT          NOT NULL,
    [PPhone]   BIGINT NOT NULL,
    [PGender]  VARCHAR (10) NOT NULL,
    [PBGroup]  VARCHAR (5)  NOT NULL,
    [PAddress] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([PNum] ASC)
);

