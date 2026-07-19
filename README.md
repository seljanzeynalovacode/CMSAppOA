# CMSAppOA - Content Management System (Onion Architecture)

A decoupled, scalable, and maintainable Content Management System (CMS) backend built with .NET Web API following the principles of **Onion Architecture**. This project emphasizes a strict separation of concerns, ensuring the core business logic remains independent of external frameworks, databases, and UI layers.

---

## 🏗️ Architecture Overview

The project is structured using the **Onion Architecture** pattern to achieve loose coupling and high testability. The dependencies flow inwards toward the Domain core:

1. **Core Layer**:
   - `CMSAppOA.Domain`: The innermost core containing domain entities and repository abstractions (interfaces). It has zero external dependencies.
   - `CMSAppOA.Contract`: Defines Data Transfer Objects (DTOs) and service interfaces to establish a contract for data exchange between layers.
   - `CMSAppOA.Application`: Implements the business logic services and handles object mapping (e.g., AutoMapper profiles).
   
2. **Infrastructure Layer**:
   - `CMSAppOA.Infrastructure`: Implements cross-cutting concerns such as notifications (e.g., SMTP Email Service).
   - `CMSAppOA.Persistance`: Handles data access by implementing the repository interfaces using Entity Framework Core, DbContext, Fluent API configurations, and database migrations.

3. **Presentation Layer**:
   - `CMSAppOA.WebApi`: The entry point of the application containing REST API controllers, configuration settings, and request pipelines.

---

## 📂 Project Structure

```text
Solution 'CMSAppOA' (6 projects)
🗀 core
 └── 🗁 CMSAppOA.Application
      ├── Dependencies
      ├── 🗀 Mapper
      │    └── CustomProfile.cs
      └── 🗀 Services
           ├── CustomerService.cs
           ├── OrderItemService.cs
           ├── OrderService.cs
           └── ProductService.cs
 └── 🗁 CMSAppOA.Contract
      ├── Dependencies
      ├── 🗀 DTOs
      │    ├── BaseDto.cs
      │    ├── CustomerDto.cs
      │    ├── OrderDto.cs
      │    ├── OrderItemDto.cs
      │    └── ProductDto.cs
      └── 🗀 Services
           ├── ICustomerService.cs
           ├── INotificationService.cs
           ├── IOrderItemService.cs
           ├── IOrderService.cs
           └── IProductService.cs
 └── 🗁 CMSAppOA.Domain
      ├── Dependencies
      ├── 🗀 Entities
      │    ├── BaseEntity.cs
      │    ├── Customer.cs
      │    ├── Order.cs
      │    ├── OrderItem.cs
      │    └── Product.cs
      └── 🗀 Repository
           └── IGenericRepository.cs
🗀 infrasturucture
 └── 🗁 CMSAppOA.Infrasturucture
      ├── Dependencies
      └── 🗀 Services
           └── NotificationService.cs (SMTP-based notification service)
 └── 🗁 CMSAppOA.Persistance
      ├── Dependencies
      ├── 🗀 Configurations
      │    ├── OrderConfiguration.cs
      │    └── OrderItemConfiguration.cs
      ├── 🗀 Data
      │    └── CMSAppDbContext.cs
      ├── 🗀 Migrations
      └── 🗀 Repository
           └── GenericRepository.cs
🗀 presentation
 └── 🗁 CMSAppOA.WebApi
      ├── Controllers
      │    ├── CustomersController.cs
      │    ├── OrderItemsController.cs
      │    ├── OrdersController.cs
      │    └── ProductsController.cs
      ├── 🗀 Logs
      │    └── log-20260719.txt (Serilog Output)
      ├── appsettings.json
      └── Program.cs
```
## 🛠️ Built With
- Framework: .NET 8 / .NET Core Web API
- Database & ORM: Entity Framework Core with Fluent API configurations.
- Object Mapping: AutoMapper (configured via CustomProfile.cs to map between Entities and DTOs seamlessly).
- Logging: Serilog — configured to write structured logs automatically into rolling text files inside the Logs/ directory.
- Notifications: SMTP Service — integrated via NotificationService.cs under the Infrastructure layer to handle automated email alerts and notifications.

## 🚀 Future Roadmap
- This project serves as a robust baseline and will be actively expanded with the following enterprise-level features:
- Authentication & Authorization: Secure the endpoints using ASP.NET Core Identity and JWT (JSON Web Tokens) with role-based policies.
- Unit & Integration Testing: Implement robust testing coverage using xUnit, Moq, and FluentAssertions for the Application and Domain layers.
- Frontend Integration: Build a modern, highly interactive UI dashboard using a modern framework (such as React, Angular, or Blazor).
- Dockerization: Containerize the API and Database using Docker and Docker Compose for easy deployment.

## ⚙️ Getting Started
Prerequisites
.NET SDK (v8.0 or newer)
Visual Studio 2022 or VS Code

## Installation & Run Steps

1. **Clone the repository:**

```bash
    git clone https://github.com/seljanzeynalovacode/CMSAppOA 
    cd CMSAppOA
```

2. **Configure Database Connection & SMTP:**
   Open `presentation/CMSAppOA.WebApi/appsettings.json` and adjust the connection strings along with the SMTP mail settings to match your local environment.

3. **Apply Database Migrations:**
   Navigate to the project directory and run:

```bash
    dotnet ef database update --project presentation/CMSAppOA.WebApi --startup-project presentation/CMSAppOA.WebApi
```

4. **Run the Application:**

```bash
    dotnet run --project presentation/CMSAppOA.WebApi
```

   Once started, you can explore the API endpoints via the Swagger UI dashboard (typically available at `http://localhost:5000/swagger` or specified ports).

## 🤝 Collaboration & Support

Contributions, issues, and feature requests are welcome! Feel free to check the issues page if you want to contribute.

If you like this project or find it helpful for learning Onion Architecture, show your support by doing the following:

1. 🍴 **Fork** the repository to your own account to start experimenting.
2. ⭐ **Star** this repository to help others discover it on GitHub.
3. 🔔 **Follow** my GitHub profile to stay updated with my latest open-source projects and enhancements!
