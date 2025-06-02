# Sales Representative Management App

A full-stack web application for managing sales representatives across multiple platforms, built using Angular (frontend) and .NET Core (backend).

---

## 🔧 Tech Stack

- **Frontend:** Angular (latest)
- **Backend:** ASP.NET Core Web API
- **Database:** SQL Server
- **Architecture:** Layered (Model → Repository → Service → Controller)

---

## 📦 Project Structure

### Backend (`/FlourSales-API`) - Visual Studio 
- FluorSalesApp - Contains the solution file .sln 
- `Models/` – Entity classes (e.g., `SalesRepresentative.cs`)
- `Repositories/` – Interfaces & implementations for data access
- `Services/` – Business logic services
- `Controllers/` – API endpoints (e.g., `SalesRepController.cs`)
- `Program.cs` – Startup and middleware config

### Frontend (`/FlourSales-webApp`) - - Visual Studio Code
- `app/components/` – Angular components (`SalesRepsComponent`)
- `app/services/` – Angular service to interact with backend (`SalesRepService`)
- `app.routes.ts` – Angular standalone routing
- `main.ts` – App bootstrap with routing and HttpClient

---

## 🚀 Features

- View list of sales representatives
- Modular service/controller architecture for backend
- Angular standalone components and routing
- RESTful API communication between frontend and backend
- CORS enabled for local development

---

## 🛠️ Getting Started

### Prerequisites
- [.NET 7+ SDK](https://dotnet.microsoft.com/)
- [Node.js & npm](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- SQL Server (local or remote)

### DB Setup

```sqlQuery
---------------------------------------------------------------------------------------------
-- Create the database
IF DB_ID('FluorSalesDb') IS NULL
    CREATE DATABASE FluorSalesDb;
GO

USE [FluorSalesDb];
GO

-- Create the SalesRepresentatives table
SET ANSI_NULLS ON;
GO

SET QUOTED_IDENTIFIER ON;
GO

IF OBJECT_ID('dbo.SalesRepresentatives', 'U') IS NOT NULL
    DROP TABLE dbo.SalesRepresentatives;
GO

CREATE TABLE [dbo].[SalesRepresentatives](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](100) NOT NULL,
    [Email] [nvarchar](256) NULL,
    [Platform] [nvarchar](100) NULL,
    [Region] [nvarchar](100) NULL,
    [IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (
    PAD_INDEX = OFF, 
    STATISTICS_NORECOMPUTE = OFF, 
    IGNORE_DUP_KEY = OFF, 
    ALLOW_ROW_LOCKS = ON, 
    ALLOW_PAGE_LOCKS = ON, 
    OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
) ON [PRIMARY]
) ON [PRIMARY];
GO

ALTER TABLE [dbo].[SalesRepresentatives] ADD  DEFAULT ((1)) FOR [IsActive];
GO

-- Add non-clustered indexes for efficient querying
CREATE NONCLUSTERED INDEX IX_SalesRepresentatives_Platform ON dbo.SalesRepresentatives(Platform);
CREATE NONCLUSTERED INDEX IX_SalesRepresentatives_Region ON dbo.SalesRepresentatives(Region);
CREATE NONCLUSTERED INDEX IX_SalesRepresentatives_IsActive ON dbo.SalesRepresentatives(IsActive);
GO

-- Insert the data
SET IDENTITY_INSERT SalesRepresentatives ON;

INSERT INTO SalesRepresentatives (Id, Name, Email, Platform, Region, IsActive) VALUES
(1, 'Amitabh Bachan', 'rohan@gmail.com', 'Ebay', 'South', 0),
(2, 'Sachin Tendulkar', 'sachin@gmail.com', 'Ebay', 'South', 0),
(3, 'Hrithik Roshan', 'hrithik@gmail.com', 'Amazon', 'South', 1),
(4, 'Shekhar Sharma', 'shekhar@gmail.com', 'Flipkart', 'South', 0),
(5, 'Shilpa Sharma', 'shilpa@gmail.com', 'Amazon', 'North', 1);

SET IDENTITY_INSERT SalesRepresentatives OFF;
GO
