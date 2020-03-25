CREATE FUNCTION [dbo].[WHS_GETCHANGEDSTORES_FN]
(
	@CountingType INT
)
RETURNS @Stores TABLE
(
	Value INT
)
AS
BEGIN
	declare @lastrun datetime;
	set @lastrun = null;
	select -- sj.name, sjs.last_run_outcome, -- 0 = fail, 1 = succeed, 2 = cancel
		   -- sjs.last_outcome_message,
		   @lastrun = 
		   case when sjs.last_run_date > 0
				then datetimefromparts(sjs.last_run_date/10000, sjs.last_run_date/100%100, sjs.last_run_date%100, sjs.last_run_time/10000, sjs.last_run_time/100%100, sjs.last_run_time%100, 0)
		   end
	  from msdb.dbo.sysjobservers sjs
	  left outer join msdb.dbo.sysjobs sj on (sj.job_id = sjs.job_id)
	 where sj.name = 'CountingDiff'
	   and last_run_outcome = 1
	 order by sj.name

	set @lastrun = isnull(@lastrun - 1.0/24.0, getdate() - 2)
	INSERT INTO @Stores
	SELECT DISTINCT SS.STORE
	  FROM WHS_STOCKTAKINGSCHEDULE SS
	  JOIN WHS_STOCKTAKING ST ON SS.STOCKTAKINGSCHEDULEID = ST.STOCKTAKINGSCHEDULE
	 WHERE SS.COUNTINGTYPE = @CountingType
	   AND (ST.UPDATE_DT >= @lastrun OR SS.UPDATE_DT >= @lastrun)

	RETURN
END