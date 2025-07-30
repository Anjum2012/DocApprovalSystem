DocumentAccessApproval
Overview
**DocumentAccessApproval** is a structured and maintainable application designed to manage and approve access requests for internal documents based on user roles. It enables:

- Users to request access to documents.
- Approvers to review and make decisions.
- Role-based authorization to control access and responsibilities.

Features
- Access Requests: Users can submit access requests for documents, specifying reason and access type (Read/Edit).
- Approval Workflow: Approvers can approve or reject access requests with comments.
- User Roles: Supports roles like User, Approver, and Admin.
- View Status: Users can track the status of their access requests.
- Clean Architecture: Follows a layered approach (API, Application, Domain, Infrastructure).
- AutoMapper Integration Smooth mapping between domain models and DTOs.
- Role-Based Authorization: Implemented using JWT Bearer Authentication
---
Project Structure
├── Api # Web API project
├── Application # Business logic (DTOs, AutoMapping)
├── Domain # Entities and enums
├── Infrastructure (EF Core with code first approach and Repositories)
├── Tests # Unit tests (MSTest/NUnit)
└── README.md # Project documentation

Getting Started
Prerequisites
•	.NET 6.0 or later
•	Visual Studio IDE
Setup
1.	Clone the repository
2.	Open the solution in Visual Studio.
3.	Build the project to restore dependencies.
Running the Application
1.	Configure the database connection in the appsettings.json file.
2.	Run the migration
3.	Run the application using Visual Studio's Run button or dotnet run in the terminal.
---
Feature
Submit access request (Read/Edit) with reason and document ID
User can view request status by userid
Approver can approve/reject with comments
Clean layered architecture (API, Application, Domain, Infrastructure)
Uses AutoMapper, DTOs, EF Core
Implemented Role based Authrozation using jwtbearer

Technical Stack
ASP.NET Core Web API
EF Core (SQLite or InMemory)
AutoMapper
MSTest
Swagger
