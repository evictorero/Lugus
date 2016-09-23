USE [lugus]
GO
declare @id integer = 0
WHILE @id < 100
BEGIN  

set @id = @id + 1
   
INSERT INTO [dbo].[bBebida]
           ([id_bebida]
           ,[descripcion_corta]
           ,[descripcion_larga]
           ,[habilitado]
           ,[id_usuario]
           ,[dvh]
           ,[fecha_modif])
     VALUES
           (@id           
		   ,'Bebida'+ convert(varchar, @id)
           ,'Bebida'+ convert(varchar, @id)
           ,'S'
           ,1
           ,1
           ,SYSDATETIME())
		   
END
GO

