-- Bước 1: Xóa tất cả Foreign Key
DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += 'ALTER TABLE ' + QUOTENAME(t.name) + ' DROP CONSTRAINT ' + QUOTENAME(f.name) + ';' + CHAR(13)
FROM sys.foreign_keys f
JOIN sys.tables t ON f.parent_object_id = t.object_id;

EXEC sp_executesql @sql;

-- Bước 2: Xóa tất cả bảng
SET @sql = N'';

SELECT @sql += 'DROP TABLE ' + QUOTENAME(name) + ';' + CHAR(13)
FROM sys.tables;

EXEC sp_executesql @sql;
