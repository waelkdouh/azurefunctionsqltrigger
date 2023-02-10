alter database sfa set change_tracking = on (change_retention = 2 days, auto_cleanup = on )

alter Table dbo.ToDo enable CHANGE_TRACKING


INSERT into [dbo].[ToDo] values (newid() , 1,'buy cat food','https://www.bing.com',0)
  
UPDATE [dbo].[ToDo] set [completed]= 1 where id= 'a30d7526-4827-4d07-8cce-130b37f03953'


CREATE USER cchfuncapp FROM EXTERNAL PROVIDER;
ALTER ROLE db_datareader ADD MEMBER cchfuncapp;
ALTER ROLE db_datawriter ADD MEMBER cchfuncapp
GRANT VIEW CHANGE TRACKING ON [dbo].[ToDo] TO cchfuncapp
GO

