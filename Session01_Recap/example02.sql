-- Example 02
-- List all databases and their DATETIME_INTERVAL_PRECISION using the following tables:
-- (1) pg_database
--     + oid
--     + datname
-- (2) pg_stat_database
--     + xact_commit
--     + xact_rollback

SELECT 
    d.oid,
    d.datname,
    sd.xact_commit,
    sd.xact_rollback,
    NULL::int AS datetime_interval_precision
FROM pg_database d
LEFT JOIN pg_stat_database sd 
       ON d.oid = sd.datid
ORDER BY d.datname;

