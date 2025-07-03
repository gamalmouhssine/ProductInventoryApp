# Product Inventory Management App (WinForms, C#)

A simple yet structured desktop application built with **WinForms** and **C#** using **ADO.NET** and **SQL Server**. The app allows users to manage an inventory of products, demonstrating clean code principles, SOLID architecture, and extensible design patterns.

## Tech Stack

WinForms (.NET Framework)
SQL Server
ADO.NET (No ORMs)
OOP & SOLID Principles
Repository Pattern

---

## Architecture Overview

```text
ProductInventoryApp/
│
├── Models/            → Product entity
├── Data/              → ADO.NET DbManager & ProductRepository
├── Services/          → Business logic layer
├── Forms/             → WinForms UI (MainForm)
├── Program.cs         → Entry point
└── App.config         → DB connection string

---

## Setup Instructions

### Clone the Repository

```bash
git clone https://github.com/gamalmouhssine/ProductInventoryApp.git
cd ProductInventoryApp

### Configure the Connection String

```bash
<connectionStrings>
	<add name="DefaultConnection"
		 connectionString="Data Source=DESKTOP;Initial Catalog=InventoryDB;User ID=sa;Password=******;TrustServerCertificate=True;"
		 providerName="System.Data.SqlClient" />
</connectionStrings>
