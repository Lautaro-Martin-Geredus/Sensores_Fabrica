USE [master]
GO
/****** Object:  Database [api_sensores_fabrica]    Script Date: 16/08/2024 13:00:31 ******/
CREATE DATABASE [api_sensores_fabrica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'api_sensores_fabrica', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\api_sensores_fabrica.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'api_sensores_fabrica_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\api_sensores_fabrica_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [api_sensores_fabrica] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [api_sensores_fabrica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [api_sensores_fabrica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET ARITHABORT OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [api_sensores_fabrica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [api_sensores_fabrica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [api_sensores_fabrica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [api_sensores_fabrica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [api_sensores_fabrica] SET  MULTI_USER 
GO
ALTER DATABASE [api_sensores_fabrica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [api_sensores_fabrica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [api_sensores_fabrica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [api_sensores_fabrica] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [api_sensores_fabrica] SET DELAYED_DURABILITY = DISABLED 
GO
USE [api_sensores_fabrica]
GO
/****** Object:  Table [dbo].[Readings]    Script Date: 16/08/2024 13:00:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Readings](
	[Id] [uniqueidentifier] NOT NULL,
	[SensorId] [uniqueidentifier] NOT NULL,
	[ReadingDate] [date] NOT NULL,
	[Value] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sensors]    Script Date: 16/08/2024 13:00:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sensors](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NULL,
	[Unit] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 16/08/2024 13:00:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Password] [int] NOT NULL,
	[Description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Readings] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Sensors] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Readings]  WITH CHECK ADD FOREIGN KEY([SensorId])
REFERENCES [dbo].[Sensors] ([Id])
GO
USE [master]
GO
ALTER DATABASE [api_sensores_fabrica] SET  READ_WRITE 
GO
