# Product Catalog Application (ASP.NET Core MVC)

A modern, responsive **Product Catalog Application** built with **ASP.NET Core MVC Architecture** and **Bootstrap 5**.

---

## 🌟 Features

- **Product Catalog Grid**: Browse products with clean card layouts, pricing, ratings, and stock badges.
- **Search & Filter**: Real-time keyword search, category filtering, and sorting (Price, Name, Rating).
- **CRUD Functionality**: Full capabilities to Create, Read, Update, and Delete products with data validation.
- **Architecture**: Clean separation of concerns adhering to the classic MVC pattern:
  - **Models**: Strongly typed entities with data annotations (`[Required]`, `[Range]`, `[StringLength]`).
  - **Views**: Razor views (`.cshtml`) styled with modern Bootstrap 5 and Bootstrap Icons.
  - **Controllers**: Thin controllers handling requests and routing.
  - **Services**: Decoupled repository/service layer providing in-memory data persistence.
- **Visual Studio 2022 Ready**: Includes `ProductCatalogApp.sln` for one-click opening and debugging.

---

## 🏗️ Project Architecture

```
ProductCatalogApp/
│── Controllers/
│   ├── HomeController.cs        # Landing page dashboard & stats
│   └── ProductController.cs     # Catalog CRUD, search & filter actions
│── Models/
│   ├── Product.cs               # Core entity model with validation
│   ├── ProductCatalogViewModel.cs # ViewModel for search & filter
│   ├── HomeDashboardViewModel.cs # ViewModel for landing metrics
│   └── ErrorViewModel.cs        # Error tracking
│── Services/
│   ├── IProductService.cs       # Contract for catalog operations
│   └── ProductService.cs        # In-memory service with rich seed data
│── Views/
│   ├── Home/
│   │   ├── Index.cshtml         # Dashboard with metrics & top items
│   │   └── Privacy.cshtml
│   ├── Product/
│   │   ├── Index.cshtml         # Catalog browsing & filter grid
│   │   ├── Details.cshtml       # Comprehensive product view
│   │   ├── Create.cshtml        # Form to add products
│   │   ├── Edit.cshtml          # Form to update products
│   │   └── Delete.cshtml        # Confirmation delete screen
│   └── Shared/
│       ├── _Layout.cshtml       # Common responsive navigation & footer
│       └── _ValidationScriptsPartial.cshtml
│── wwwroot/
│   ├── css/site.css             # Custom styles & card hover effects
│   └── js/site.js
│── Program.cs                   # DI setup and request pipeline
│── ProductCatalogApp.csproj     # .NET 9.0 project definition
└── ProductCatalogApp.sln        # Visual Studio 2022 Solution
```

---

## 🚀 How to Run in Visual Studio 2022

1. Navigate to `D:\.net\ProductCatalogApp`.
2. Double-click **`ProductCatalogApp.sln`** to open the project in **Visual Studio 2022**.
3. In Visual Studio, ensure the startup project is set to `ProductCatalogApp`.
4. Press **`F5`** (Debug) or **`Ctrl + F5`** (Run without debugging).
5. Visual Studio will launch your default browser (Chrome) pointing to the running application!

---

## 💻 How to Run via Command Line

```bash
cd D:\.net\ProductCatalogApp
dotnet run
```
Then open your browser at the displayed URL (e.g., `http://localhost:5149` or `https://localhost:7166`).

---

## 🌐 Uploading to GitHub using Chrome & Visual Studio 2022

### Step 1: Create a New Repository in Chrome
1. Open **Google Chrome** and go to [https://github.com/new](https://github.com/new).
2. Enter Repository name: `ProductCatalogApp` (or your preferred name).
3. Choose **Public** or **Private**.
4. **Leave "Add a README file" and ".gitignore" unchecked** (since we already created them).
5. Click **Create repository**.
6. Copy the repository URL (e.g. `https://github.com/<your-username>/ProductCatalogApp.git`).

### Step 2: Push to GitHub from Terminal / Visual Studio
Open PowerShell in `D:\.net\ProductCatalogApp` and run:

```bash
git remote add origin https://github.com/<your-username>/ProductCatalogApp.git
git branch -M main
git push -u origin main
```
*Note: If prompted, Chrome will open to authenticate your GitHub account!*
