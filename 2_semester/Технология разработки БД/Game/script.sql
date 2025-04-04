USE [master]
GO
/****** Object:  Database [MMORPG]    Script Date: 24.02.2025 13:19:08 ******/
CREATE DATABASE [MMORPG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MMORPG', FILENAME = N'D:\DB\MSSQL16.GLO2024\MSSQL\DATA\MMORPG.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MMORPG_log', FILENAME = N'D:\DB\MSSQL16.GLO2024\MSSQL\DATA\MMORPG_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MMORPG] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MMORPG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MMORPG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MMORPG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MMORPG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MMORPG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MMORPG] SET ARITHABORT OFF 
GO
ALTER DATABASE [MMORPG] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MMORPG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MMORPG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MMORPG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MMORPG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MMORPG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MMORPG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MMORPG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MMORPG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MMORPG] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MMORPG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MMORPG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MMORPG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MMORPG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MMORPG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MMORPG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MMORPG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MMORPG] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MMORPG] SET  MULTI_USER 
GO
ALTER DATABASE [MMORPG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MMORPG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MMORPG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MMORPG] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MMORPG] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MMORPG] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MMORPG] SET QUERY_STORE = ON
GO
ALTER DATABASE [MMORPG] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MMORPG]
GO
/****** Object:  Table [dbo].[Characters]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Characters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nickname] [nvarchar](50) NOT NULL,
	[Level] [int] NOT NULL,
	[Origin] [nvarchar](30) NOT NULL,
	[Sex] [nvarchar](10) NOT NULL,
	[id_player] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Discription] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enemy]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enemy](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Features] [nvarchar](100) NOT NULL,
	[Level] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[id_item] [int] NOT NULL,
	[id_char] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_item] ASC,
	[id_char] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
	[Features] [nvarchar](70) NOT NULL,
	[Discription] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[List]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[List](
	[id_class] [int] NOT NULL,
	[id_character] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_class] ASC,
	[id_character] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Level] [int] NOT NULL,
	[Discription] [nvarchar](200) NOT NULL,
	[Biom] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NPC]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NPC](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [int] NOT NULL,
	[Origin] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](25) NOT NULL,
	[Password] [nvarchar](25) NOT NULL,
	[IP] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](35) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionCharecter]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionCharecter](
	[id_location] [int] NOT NULL,
	[id_character] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_location] ASC,
	[id_character] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionEnemy]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionEnemy](
	[id_enemy] [int] NOT NULL,
	[id_location] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_location] ASC,
	[id_enemy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionNPC]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionNPC](
	[id_NPC] [int] NOT NULL,
	[id_location] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_NPC] ASC,
	[id_location] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Qest]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Task] [nvarchar](100) NOT NULL,
	[Reward] [nvarchar](30) NOT NULL,
	[id_NPC] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Discription] [nvarchar](100) NOT NULL,
	[Effect] [nvarchar](50) NOT NULL,
	[id_class] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specifications]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specifications](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HP] [int] NOT NULL,
	[MP] [int] NOT NULL,
	[id_character] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusQuest]    Script Date: 24.02.2025 13:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusQuest](
	[id_character] [int] NOT NULL,
	[id_qest] [int] NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_qest] ASC,
	[id_character] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Characters]  WITH CHECK ADD FOREIGN KEY([id_player])
REFERENCES [dbo].[Players] ([ID])
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD FOREIGN KEY([id_char])
REFERENCES [dbo].[Characters] ([ID])
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD FOREIGN KEY([id_item])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[List]  WITH CHECK ADD FOREIGN KEY([id_character])
REFERENCES [dbo].[Characters] ([ID])
GO
ALTER TABLE [dbo].[List]  WITH CHECK ADD FOREIGN KEY([id_class])
REFERENCES [dbo].[Class] ([ID])
GO
ALTER TABLE [dbo].[PositionCharecter]  WITH CHECK ADD FOREIGN KEY([id_character])
REFERENCES [dbo].[Characters] ([ID])
GO
ALTER TABLE [dbo].[PositionCharecter]  WITH CHECK ADD FOREIGN KEY([id_location])
REFERENCES [dbo].[Locations] ([ID])
GO
ALTER TABLE [dbo].[PositionEnemy]  WITH CHECK ADD FOREIGN KEY([id_enemy])
REFERENCES [dbo].[Enemy] ([ID])
GO
ALTER TABLE [dbo].[PositionEnemy]  WITH CHECK ADD FOREIGN KEY([id_location])
REFERENCES [dbo].[Locations] ([ID])
GO
ALTER TABLE [dbo].[PositionNPC]  WITH CHECK ADD FOREIGN KEY([id_location])
REFERENCES [dbo].[Locations] ([ID])
GO
ALTER TABLE [dbo].[PositionNPC]  WITH CHECK ADD FOREIGN KEY([id_NPC])
REFERENCES [dbo].[NPC] ([ID])
GO
ALTER TABLE [dbo].[Qest]  WITH CHECK ADD FOREIGN KEY([id_NPC])
REFERENCES [dbo].[NPC] ([ID])
GO
ALTER TABLE [dbo].[Skills]  WITH CHECK ADD FOREIGN KEY([id_class])
REFERENCES [dbo].[Class] ([ID])
GO
ALTER TABLE [dbo].[Specifications]  WITH CHECK ADD FOREIGN KEY([id_character])
REFERENCES [dbo].[Characters] ([ID])
GO
ALTER TABLE [dbo].[StatusQuest]  WITH CHECK ADD FOREIGN KEY([id_character])
REFERENCES [dbo].[Characters] ([ID])
GO
ALTER TABLE [dbo].[StatusQuest]  WITH CHECK ADD FOREIGN KEY([id_qest])
REFERENCES [dbo].[Qest] ([ID])
GO
USE [master]
GO
ALTER DATABASE [MMORPG] SET  READ_WRITE 
GO
