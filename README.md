# JewelQuote

A C# desktop application for generating and managing jewellery quotations, built with a clean layered architecture.

## Features

- Generate itemised jewellery quotes with pricing
- Dual database support — Microsoft Access and SQL Server
- Layered architecture separating UI, business logic, and data access
- Version 2 with improved structure and maintainability

## Tech stack

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat&logo=microsoftsqlserver&logoColor=white)

## Architecture
```
JewelQuote/
├── InterfaceLayer/     # UI and presentation layer
├── ModelLayer/         # Business logic and domain models
├── AccessDBLayer/      # Data access — Microsoft Access
├── SQLServerDBLayer/   # Data access — SQL Server
└── JewelQuote_ver2/    # Latest version of the application
```

## Getting started
```bash
git clone https://github.com/gaurravi11/JewelQuote.git
cd JewelQuote
```

Open `JewelQuote_ver2.sln` in Visual Studio and build the solution.

## Usage

1. Launch the application
2. Add jewellery items with weight, rate, and making charges
3. Generate and save the quotation

## Author

**Ravi Gaur** — [LinkedIn](https://www.linkedin.com/in/ravigaur11/) · [GitHub](https://github.com/gaurravi11)
