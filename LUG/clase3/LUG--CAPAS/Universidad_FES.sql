USE [master]
GO
/****** Object:  Database [Universidad_FES]    Script Date: 16/9/2018 20:45:56 ******/
CREATE DATABASE [Universidad_FES]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Universidad_FES', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Universidad_FES.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Universidad_FES_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Universidad_FES_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Universidad_FES] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Universidad_FES].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Universidad_FES] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Universidad_FES] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Universidad_FES] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Universidad_FES] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Universidad_FES] SET ARITHABORT OFF 
GO
ALTER DATABASE [Universidad_FES] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Universidad_FES] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Universidad_FES] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Universidad_FES] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Universidad_FES] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Universidad_FES] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Universidad_FES] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Universidad_FES] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Universidad_FES] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Universidad_FES] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Universidad_FES] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Universidad_FES] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Universidad_FES] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Universidad_FES] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Universidad_FES] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Universidad_FES] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Universidad_FES] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Universidad_FES] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Universidad_FES] SET  MULTI_USER 
GO
ALTER DATABASE [Universidad_FES] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Universidad_FES] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Universidad_FES] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Universidad_FES] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Universidad_FES] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Universidad_FES]
GO
/****** Object:  Table [dbo].[ALUMNO]    Script Date: 16/9/2018 20:45:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ALUMNO](
	[ID] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Fecha_Nacimiento] [numeric](18, 0) NOT NULL,
	[Sexo] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[EditarALUMNO]    Script Date: 16/9/2018 20:45:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EditarALUMNO]
@ID int ,@Nombre nvarchar(50), @Apellido nvarchar(50), @FechaNacimiento numeric, @Sexo nvarchar(50)
as
begin 
update ALUMNO set
Nombre = @Nombre,
Apellido=@Apellido,
Fecha_Nacimiento = @FechaNacimiento,
Sexo=@Sexo

where ID = @ID
end 
GO
/****** Object:  StoredProcedure [dbo].[EliminarALUMNO]    Script Date: 16/9/2018 20:45:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EliminarALUMNO]
@ID int
as
begin
delete from ALUMNO 
where ID=@ID

end
GO
/****** Object:  StoredProcedure [dbo].[InsertarALUMNOS]    Script Date: 16/9/2018 20:45:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertarALUMNOS]

@Nombre nvarchar(50), @Apellido nvarchar(50), @Fecha_Nacimiento numeric, @Sexo int
as
begin 
declare @id int
set @id =  isnull( (select max(ID) from ALUMNO),0  ) +1

insert into ALUMNO
values ( @id,@Nombre,@Apellido,@Fecha_Nacimiento,@Sexo)
end 
GO
/****** Object:  StoredProcedure [dbo].[ListarALUMNO]    Script Date: 16/9/2018 20:45:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ListarALUMNO]
as
begin 
select ID, Nombre, Apellido,Fecha_Nacimiento,Sexo from ALUMNO
end 
GO
USE [master]
GO
ALTER DATABASE [Universidad_FES] SET  READ_WRITE 
GO
