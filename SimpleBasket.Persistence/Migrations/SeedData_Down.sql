
ALTER TABLE [dbo].[ProductOption] DROP CONSTRAINT [FK_57]
GO
ALTER TABLE [dbo].[ProductOption] DROP CONSTRAINT [FK_132]
GO
ALTER TABLE [dbo].[ProductDetail] DROP CONSTRAINT [FK_129]
GO
ALTER TABLE [dbo].[Option] DROP CONSTRAINT [FK_51]
GO
ALTER TABLE [dbo].[Basket] DROP CONSTRAINT [FK_135]
GO
ALTER TABLE [dbo].[Basket] DROP CONSTRAINT [FK_109]
GO
/****** Object:  Table [dbo].[ProductOption]    Script Date: 9.01.2021 03:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductOption]') AND type in (N'U'))
DROP TABLE [dbo].[ProductOption]
GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 9.01.2021 03:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductDetail]') AND type in (N'U'))
DROP TABLE [dbo].[ProductDetail]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 9.01.2021 03:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
DROP TABLE [dbo].[Product]
GO
/****** Object:  Table [dbo].[OptionGroup]    Script Date: 9.01.2021 03:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OptionGroup]') AND type in (N'U'))
DROP TABLE [dbo].[OptionGroup]
GO
/****** Object:  Table [dbo].[Option]    Script Date: 9.01.2021 03:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Option]') AND type in (N'U'))
DROP TABLE [dbo].[Option]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9.01.2021 03:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
DROP TABLE [dbo].[Customer]
GO
/****** Object:  Table [dbo].[Basket]    Script Date: 9.01.2021 03:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Basket]') AND type in (N'U'))
DROP TABLE [dbo].[Basket]
GO
USE [master]
GO
/****** Object:  Database [SimpleBasketDb]    Script Date: 9.01.2021 03:57:06 ******/
DROP DATABASE [SimpleBasketDb]
GO
