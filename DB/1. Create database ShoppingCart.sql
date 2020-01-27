CREATE DATABASE [ShoppingCart]
GO


ALTER DATABASE [ShoppingCart] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShoppingCart].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ShoppingCart] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ShoppingCart] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ShoppingCart] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ShoppingCart] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ShoppingCart] SET ARITHABORT OFF 
GO

ALTER DATABASE [ShoppingCart] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ShoppingCart] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ShoppingCart] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ShoppingCart] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ShoppingCart] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ShoppingCart] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ShoppingCart] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ShoppingCart] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ShoppingCart] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ShoppingCart] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ShoppingCart] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ShoppingCart] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ShoppingCart] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ShoppingCart] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ShoppingCart] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ShoppingCart] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ShoppingCart] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ShoppingCart] SET RECOVERY FULL 
GO

ALTER DATABASE [ShoppingCart] SET  MULTI_USER 
GO

ALTER DATABASE [ShoppingCart] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ShoppingCart] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ShoppingCart] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ShoppingCart] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [ShoppingCart] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ShoppingCart] SET  READ_WRITE 
GO
