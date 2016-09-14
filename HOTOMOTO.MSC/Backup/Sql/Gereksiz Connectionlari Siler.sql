CREATE TABLE #TmpWho
(	spid INT, 
	STATUS VARCHAR(500), 
	Login  VARCHAR(200),
	HostNAme VARCHAR(200),
	BlkBy  VARCHAR(200),
	dbname VARCHAR(150), 
	Command   VARCHAR(200),
	CPUTime   VARCHAR(200),
	DiskIO   VARCHAR(200),
	LastBatch   VARCHAR(200),
	ProgramName VARCHAR(150),
	SPID2 INT,
	REQUESTID INT)


INSERT INTO 	#TmpWho
EXEC      	sp_who2
DECLARE 	@spid INT
DECLARE 	@tString varchar(15)

DECLARE 	@getspid CURSOR

SET @getspid = 	CURSOR FOR
SELECT      	spid
FROM     	#TmpWho
WHERE      	dbname = 'TURQUIA' AND ProgramName LIKE '%SqlClient%' OPEN @getspid

FETCH NEXT FROM @getspid INTO @spid
WHILE @@FETCH_STATUS = 0

BEGIN
	SET @tString = 'KILL ' + CAST(@spid AS VARCHAR(5))
	print @tString
	--EXEC(@tString)
	FETCH NEXT FROM @getspid INTO @spid
END

CLOSE @getspid
DEALLOCATE @getspid

DROP TABLE #TmpWho