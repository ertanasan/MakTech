﻿CREATE TABLE [RCL_STORELOG]
(
    [STORERECID] BIGINT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [STORE]               INT NULL,
    [RECONCILIATION_DT]   DATETIME NOT NULL,
    [ZET_AMT]             NUMERIC(22,6) NOT NULL,
    [DEFINEDADVANCE_AMT]  NUMERIC(22,6) NOT NULL,
    [EXPENSE_AMT]         NUMERIC(22,6) NULL,
    [CASH_AMT]            NUMERIC(22,6) NOT NULL,
    [CARD_AMT]            NUMERIC(22,6) NOT NULL,
    [RECOVERED_AMT]       NUMERIC(22,6) NULL,
    [ADJUSTMENT_AMT]      NUMERIC(22,6) NULL,
    [NETOFF_AMT]          NUMERIC(22,6) NOT NULL,
    [BANK_AMT]            NUMERIC(22,6) NOT NULL,
    [CURRENTADVANCE_AMT]  NUMERIC(22,6) NOT NULL,
    [EXPENSERETURN_AMT]   NUMERIC(22,6) NULL,
    [DIFFREASONCODES_TXT] VARCHAR(300) NULL,
    [DIFFREASON_TXT]      VARCHAR(500) NULL,
    [LASTSTEP_NO]         INT NULL,
    [COMPLETE_FL]         VARCHAR(1) NULL,
    [ADJUSTMENT_DSC]      VARCHAR(300) NULL,
    [DEFICITCYCLE_CNT]    INT NULL
)
GO