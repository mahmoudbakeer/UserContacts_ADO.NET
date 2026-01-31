# UsersContacts_ADO.NET
This project is an initial implementation of a 3-Tier Architecture using C# and ADO.NET, designed to demonstrate a clean separation of concerns between data access, business logic, and presentation layers.
# Contacts Management System – 3-Tier Architecture (.NET)

## Description
This project is an initial implementation of a **3-Tier Architecture** using **C# and ADO.NET**, aimed at demonstrating a clean and maintainable separation between the Presentation Layer, Business Logic Layer, and Data Access Layer.

The project focuses on a simple **Contacts Management** domain, where contact data is retrieved from a SQL Server database using structured and secure data access techniques. Although the current implementation is minimal, the architecture is intentionally designed to scale and evolve into a full enterprise-style application.

---

## Architecture Overview

The solution follows the classical **Three-Tier Architecture** pattern:

### 1. Presentation Layer
- Implemented as a **Console Application**
- Responsible only for user interaction and output
- Communicates exclusively with the Business Logic Layer
- Does not access the database directly

### 2. Business Logic Layer (BLL)
- Encapsulates the `Contact` domain entity
- Provides high-level operations such as finding a contact by ID
- Acts as an abstraction layer between the UI and the database
- Ensures separation of business rules from data access logic

### 3. Data Access Layer (DAL)
- Uses **ADO.NET** (`SqlConnection`, `SqlCommand`, `SqlDataReader`)
- Executes parameterized SQL queries to prevent SQL injection
- Responsible solely for database communication
- Returns raw data to the Business Logic Layer

---

## Current Features
- Retrieve contact information by ID
- Display contact details via console output
- Clear separation of concerns using layered architecture
- Secure database access using parameterized queries

---

## Technologies Used
- C#
- .NET
- ADO.NET
- SQL Server
- Console Application

---

## Project Structure
- `DataAccessLayer`  
  Handles all database operations and SQL queries.

- `BuisnessLogicLayer`  
  Contains domain entities and business-related logic.

- `PresentationLayer`  
  Console-based interface for interacting with the application.

---

## How It Works
1. The Presentation Layer requests a contact by ID.
2. The Business Logic Layer processes the request.
3. The Data Access Layer queries the database.
4. The result is mapped to a domain object and returned.
5. The Presentation Layer displays the data.

---

## Future Improvements
- Add Insert / Update / Delete operations
- Introduce validation rules
- Add centralized error handling
- Implement logging
- Replace Console UI with WinForms, WPF, or Web API
- Improve configuration management

---

## Purpose
This project serves as a **foundational example of enterprise application structure in .NET**, emphasizing:
- Maintainability
- Scalability
- Clear responsibility boundaries
- Clean architecture principles

---

## Author
Mahmoud Bakir
