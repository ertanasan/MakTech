﻿CREATE PROCEDURE [dbo].[WHS_SEL_PALLETBYGATHERINGID_SP]
	@GatheringId BIGINT,
	@PalletNo INT
AS
	SELECT *
	  FROM WHS_GATHERINGPALLET GP
	 WHERE GP.PALLET_NO = @PalletNo
	   AND GP.GATHERING = @GatheringId