﻿CREATE TABLE RCL_ZCONTROLLOG (
[ZCONTROLLOGID]		  BIGINT NOT NULL IDENTITY,
[CREATE_DT]           DATETIME NOT NULL,
[CREATEUSER]          INT NOT NULL,
[STORE]               INT NOT NULL,
[RECONCILIATION_DT]   DATETIME NOT NULL,
[ZET_AMT]             NUMERIC(22,6))