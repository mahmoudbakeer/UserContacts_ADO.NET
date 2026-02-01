# UsersContacts_ADO.NET  
### Contacts Management System using ADO.NET (3-Tier Architecture – Learning Project)

---

## Project Overview

**UsersContacts_ADO.NET** is a learning-focused .NET project that demonstrates how to build a **Contacts Management System** using **C#, ADO.NET, and SQL Server**, following the principles of the **3-Tier Architecture**.

The main purpose of this project is to understand how layered architectures work in practice, how data flows between layers, and how to use **ADO.NET** correctly for database access.  
The project uses a **Console Application** as a testing environment to validate Business Logic and Data Access functionality.

This is an educational project intended to build a solid foundation for more advanced .NET applications.

---

## Architecture Overview

The solution follows the classic **Three-Tier Architecture**, where each layer has a clear and independent responsibility.

### 1. Presentation Layer (Test Console)

- Implemented as a **Console Application**
- Used only for testing and validating functionality
- Handles user input and displays output
- Calls methods from the Business Logic Layer
- Contains the `Main` method acting as a test harness
- Does **not** directly access the database

> Note: This is a testing console, not a real UI layer.

---

### 2. Business Logic Layer (BLL)

- Contains domain entities such as:
  - `clsContact`
  - `clsCountry`
- Implements business operations like:
  - Find
  - Save (Insert / Update)
  - Delete
  - IsExist
- Acts as an abstraction between the Presentation Layer and the Data Access Layer
- Keeps business rules separate from database logic

This layer represents **application behavior and rules**.

---

### 3. Data Access Layer (DAL)

- Uses **ADO.NET** components:
  - `SqlConnection`
  - `SqlCommand`
  - `SqlDataReader`
  - `ExecuteScalar`
- Responsible only for database communication
- Uses parameterized SQL queries to prevent SQL injection
- Returns raw data to the Business Logic Layer

This layer represents **database interaction only**.

---

## Current Features

### Contacts
- Insert new contacts
- Retrieve contacts by ID
- Update existing contacts
- Delete contacts
- Check if a contact exists
- Retrieve and display all contacts

### Countries
- Insert new countries
- Retrieve countries by ID or name
- Update country information
- Delete countries
- Check if a country exists

All features are tested through the console application.

---

## Technologies Used

- C#
- .NET
- ADO.NET
- SQL Server
- Console Application

---

## Project Structure

UsersContacts_ADO.NET
│
├── DataAccessLayer
│   └── Handles SQL queries and database operations
│
├── BusinessLogicLayer
│   └── Contains domain entities and business rules
│
└── PresentationLayer
    └── Console-based test application (Main method)

---

## How It Works

1. The Console application requests an operation.
2. The Business Logic Layer processes the request.
3. The Data Access Layer executes the SQL query.
4. Data is returned and mapped to domain objects.
5. The result is displayed in the console.

This flow mirrors real enterprise applications, without a graphical UI.

---

## Purpose of the Project

This project is intended to:

- Build a strong understanding of **ADO.NET**
- Practice **3-Tier Architecture** principles
- Learn proper separation of concerns
- Prepare for advanced .NET topics such as:
  - ASP.NET Web API
  - MVC
  - Repository Pattern
  - Clean Architecture
  - Unit and Integration Testing

---

## Future Improvements

- Add validation rules
- Centralize error handling
- Implement logging
- Replace Console UI with WinForms, WPF, or Web API
- Apply Repository and Service patterns
- Add automated tests

---

## Author

Mahmoud Bakir
