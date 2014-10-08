
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/08/2014 10:54:24
-- Generated from EDMX file: C:\Users\abbas\Source\Repos\2509-ICT-\RestaurantUnitTest\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Restdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MenuItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Items] DROP CONSTRAINT [FK_MenuItem];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderItemOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItems] DROP CONSTRAINT [FK_OrderItemOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemOrderItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItems] DROP CONSTRAINT [FK_ItemOrderItem];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerCreditCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditCards] DROP CONSTRAINT [FK_CustomerCreditCard];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_CustomerOrder];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CreditCards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditCards];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Items]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Items];
GO
IF OBJECT_ID(N'[dbo].[Menus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Menus];
GO
IF OBJECT_ID(N'[dbo].[OrderItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderItems];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CreditCards'
CREATE TABLE [dbo].[CreditCards] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CardName] nvarchar(max)  NOT NULL,
    [CardType] nvarchar(max)  NOT NULL,
    [CardNumber] smallint  NOT NULL,
    [Customer_PhoneNumber] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [PhoneNumber] nvarchar(15)  NOT NULL,
    [FistName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Picture] nvarchar(max)  NOT NULL,
    [MenuId] int  NOT NULL,
    [TimeStamp] datetime  NULL
);
GO

-- Creating table 'Menus'
CREATE TABLE [dbo].[Menus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrderItems'
CREATE TABLE [dbo].[OrderItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderId] int  NOT NULL,
    [ItemId] int  NOT NULL,
    [Quantity] smallint  NOT NULL,
    [Timestamp] datetime  NOT NULL,
    [UnitPrice] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderTotal] decimal(18,0)  NULL,
    [TimeStamp] datetime  NOT NULL,
    [CustomerPhoneNumber] nvarchar(15)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CreditCards'
ALTER TABLE [dbo].[CreditCards]
ADD CONSTRAINT [PK_CreditCards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [PhoneNumber] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([PhoneNumber] ASC);
GO

-- Creating primary key on [Id] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [PK_Menus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [PK_OrderItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MenuId] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_MenuItem]
    FOREIGN KEY ([MenuId])
    REFERENCES [dbo].[Menus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenuItem'
CREATE INDEX [IX_FK_MenuItem]
ON [dbo].[Items]
    ([MenuId]);
GO

-- Creating foreign key on [OrderId] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK_OrderItemOrder]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderItemOrder'
CREATE INDEX [IX_FK_OrderItemOrder]
ON [dbo].[OrderItems]
    ([OrderId]);
GO

-- Creating foreign key on [ItemId] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK_ItemOrderItem]
    FOREIGN KEY ([ItemId])
    REFERENCES [dbo].[Items]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemOrderItem'
CREATE INDEX [IX_FK_ItemOrderItem]
ON [dbo].[OrderItems]
    ([ItemId]);
GO

-- Creating foreign key on [Customer_PhoneNumber] in table 'CreditCards'
ALTER TABLE [dbo].[CreditCards]
ADD CONSTRAINT [FK_CustomerCreditCard]
    FOREIGN KEY ([Customer_PhoneNumber])
    REFERENCES [dbo].[Customers]
        ([PhoneNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerCreditCard'
CREATE INDEX [IX_FK_CustomerCreditCard]
ON [dbo].[CreditCards]
    ([Customer_PhoneNumber]);
GO

-- Creating foreign key on [CustomerPhoneNumber] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_CustomerOrder]
    FOREIGN KEY ([CustomerPhoneNumber])
    REFERENCES [dbo].[Customers]
        ([PhoneNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder'
CREATE INDEX [IX_FK_CustomerOrder]
ON [dbo].[Orders]
    ([CustomerPhoneNumber]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------