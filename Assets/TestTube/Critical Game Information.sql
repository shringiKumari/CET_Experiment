
CREATE TEMPORARY TABLE IF NOT EXISTS RelevantSessions AS (Select session_id as "session", ip from GameplaySession where gameID = 63);

SELECT CONCAT(
'SELECT `CriticalEvents`.session', GROUP_CONCAT('
 ,    `t_', REPLACE(title, '`', '``'), '`.info
     AS `', REPLACE(title, '`', '``'), '`'
 SEPARATOR ''),
' FROM `CriticalEvents` ', GROUP_CONCAT('
 LEFT JOIN `CriticalEvents`   AS `t_', REPLACE(title, '`', '``'), '`
        ON `CriticalEvents`. session = `t_', REPLACE(title, '`', '``'), '`.session
       AND `t_', REPLACE(title, '`', '``'), '`.title = ', QUOTE(title)
 SEPARATOR ''),
' GROUP BY `CriticalEvents`.session'
) INTO @qry FROM (SELECT DISTINCT title FROM CriticalEvents Join RelevantSessions ON RelevantSessions.session = CriticalEvents.session) t;

SET @storetmp = CONCAT('CREATE TEMPORARY TABLE IF NOT EXISTS Results AS ', @qry);


PREPARE stmt FROM @storetmp;
EXECUTE stmt;

Select Results.*, RelevantSessions.ip from Results join RelevantSessions on RelevantSessions.session = Results.session;
