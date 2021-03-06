USE [master]
GO
/****** Object:  Database [CCards]    Script Date: 7/18/2018 6:52:09 PM ******/
CREATE DATABASE [CCards]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CCards', FILENAME = N'C:\Program Files\Microsoft SQL Server 2012\MSSQL11.SQL2012\MSSQL\DATA\CCards.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CCards_log', FILENAME = N'C:\Program Files\Microsoft SQL Server 2012\MSSQL11.SQL2012\MSSQL\DATA\CCards_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CCards] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CCards].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CCards] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CCards] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CCards] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CCards] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CCards] SET ARITHABORT OFF 
GO
ALTER DATABASE [CCards] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CCards] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CCards] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CCards] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CCards] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CCards] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CCards] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CCards] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CCards] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CCards] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CCards] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CCards] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CCards] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CCards] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CCards] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CCards] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CCards] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CCards] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CCards] SET RECOVERY FULL 
GO
ALTER DATABASE [CCards] SET  MULTI_USER 
GO
ALTER DATABASE [CCards] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CCards] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CCards] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CCards] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CCards', N'ON'
GO
USE [CCards]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCardDetails]    Script Date: 7/18/2018 6:52:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetCardDetails] 
	@CardNo int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT cd.CardNo, cd.Expiry from CardDetails cd where cd.CardNo = @CardNo;
END


GO
/****** Object:  Table [dbo].[CardDetails]    Script Date: 7/18/2018 6:52:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardDetails](
	[CardNo] [nvarchar](16) NOT NULL,
	[Expiry] [nvarchar](6) NOT NULL,
 CONSTRAINT [PK_CardDetails] PRIMARY KEY CLUSTERED 
(
	[CardNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [CCards] SET  READ_WRITE 
GO
