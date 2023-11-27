USE [master]
GO
/****** Object:  Database [ZadKyrs]    Script Date: 20.10.2020 15:07:30 ******/
CREATE DATABASE [ZadKyrs]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ZadKyrs', FILENAME = N'D:\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ZadKyrs.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ZadKyrs_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ZadKyrs_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ZadKyrs] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ZadKyrs].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ZadKyrs] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ZadKyrs] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ZadKyrs] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ZadKyrs] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ZadKyrs] SET ARITHABORT OFF 
GO
ALTER DATABASE [ZadKyrs] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ZadKyrs] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ZadKyrs] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ZadKyrs] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ZadKyrs] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ZadKyrs] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ZadKyrs] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ZadKyrs] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ZadKyrs] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ZadKyrs] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ZadKyrs] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ZadKyrs] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ZadKyrs] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ZadKyrs] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ZadKyrs] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ZadKyrs] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ZadKyrs] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ZadKyrs] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ZadKyrs] SET  MULTI_USER 
GO
ALTER DATABASE [ZadKyrs] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ZadKyrs] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ZadKyrs] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ZadKyrs] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ZadKyrs] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ZadKyrs] SET QUERY_STORE = OFF
GO
USE [ZadKyrs]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 20.10.2020 15:07:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupId] [int] NOT NULL,
	[GroupNum] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupStudent]    Script Date: 20.10.2020 15:07:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupStudent](
	[GroupId] [int] NOT NULL,
	[Login] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GroupStudent] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Speciality]    Script Date: 20.10.2020 15:07:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Speciality](
	[SpecialityId] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Speciality] PRIMARY KEY CLUSTERED 
(
	[SpecialityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAnswer]    Script Date: 20.10.2020 15:07:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAnswer](
	[TaskID] [int] NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Answer] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_StudentAnswer] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC,
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 20.10.2020 15:07:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[FirstName] [varchar](50) NOT NULL,
	[SecondName] [varchar](50) NOT NULL,
	[FamalyName] [varchar](50) NOT NULL,
	[GroupId] [int] NOT NULL,
	[Login] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 20.10.2020 15:07:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[TaskID] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[About] [varchar](1000) NOT NULL,
	[SpecialityId] [int] NOT NULL,
	[RightAnswer] [varchar](1000) NOT NULL,
	[GroupId] [int] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 20.10.2020 15:07:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[FirstName] [varchar](50) NOT NULL,
	[SecondName] [varchar](50) NOT NULL,
	[FamalyName] [varchar](50) NOT NULL,
	[SpecialityID] [int] NOT NULL,
	[Login] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20.10.2020 15:07:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](40) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_GroupStudent_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_GroupStudent_Groups]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_GroupStudent_Students] FOREIGN KEY([Login])
REFERENCES [dbo].[Students] ([Login])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_GroupStudent_Students]
GO
ALTER TABLE [dbo].[StudentAnswer]  WITH CHECK ADD  CONSTRAINT [FK_StudentAnswer_Students] FOREIGN KEY([Login])
REFERENCES [dbo].[Students] ([Login])
GO
ALTER TABLE [dbo].[StudentAnswer] CHECK CONSTRAINT [FK_StudentAnswer_Students]
GO
ALTER TABLE [dbo].[StudentAnswer]  WITH CHECK ADD  CONSTRAINT [FK_StudentAnswer_Task] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Task] ([TaskID])
GO
ALTER TABLE [dbo].[StudentAnswer] CHECK CONSTRAINT [FK_StudentAnswer_Task]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([GroupId])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Groups]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Users] FOREIGN KEY([Login])
REFERENCES [dbo].[Users] ([Login])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Users]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Speciality] FOREIGN KEY([SpecialityId])
REFERENCES [dbo].[Speciality] ([SpecialityId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Speciality]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Speciality] FOREIGN KEY([SpecialityID])
REFERENCES [dbo].[Speciality] ([SpecialityId])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Speciality]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Users] FOREIGN KEY([Login])
REFERENCES [dbo].[Users] ([Login])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Users]
GO
USE [master]
GO
ALTER DATABASE [ZadKyrs] SET  READ_WRITE 
GO
