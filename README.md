Ticketing Microservice
This is a simple ticketing system implemented in .NET Core using a Clean Architecture and CQRS pattern.

🔧 Technologies
ASP.NET Core Web API
Entity Framework Core
SQL Server
MediatR
JWT Authentication
🚀 Getting Started
1. Clone the repo:
git clone https://github.com/amkhani6925/TicketingSystem

2. Apply Migrations

dotnet ef database update -p Ti.Infrastructure -s Ticket.API

3. Run the app

dotnet run --project Ticket.API

4. API Test
Use Postman to test /api/auth/login and then call protected routes with the JWT token.

--------------------------------
Post
http://localhost:5071/api/v1/User/CreateUser
raw body
{
    "FullName":"test admin",
    "Email": "admin@gmail.com",
    "Password":"1234",
    "Role":1
}
----
{
    "FullName":"test employee",
    "Email": "employee@gmail.com",
    "Password":"12345",
    "Role":2
}
----
result:
{
    "id": "98d2659a-b6fb-4d1c-68f4-08ddd3348758",
    "message": "کاربر با موفقیت ایجاد شد"
}
-----
Post
http://localhost:5071/api/v1/Authentication/login
body
{  
    "UserName":"employee@gmail.com",
    "Password" : "12345"
}
result:
{
    "userName": "employee@gmail.com",
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI5OGQyNjU5YS1iNmZiLTRkMWMtNjhmNC0wOGRkZDMzNDg3NTgiLCJ1bmlxdWVfbmFtZSI6ImVtcGxveWVlQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkVtcGxveWVlIiwiZXhwIjoxNzU0MzAxMzAxLCJpc3MiOiJUaWNrZXRpbmdTeXN0ZW1BcGkiLCJhdWQiOiJUaWNrZXRpbmdTeXN0ZW1BcHAifQ.K1EP9v1i680SR3ttHiD2cUoTbtOLDo3qlTj6HEHyuzc",
    "loginTime": "2025-08-04T08:55:01.2127574Z"
}
-----
Post     ( employee Only)
http://localhost:5071/api/v1/Ticket/CreateTicket

Header:
key   Authorization
value Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI5OGQyNjU5YS1iNmZiLTRkMWMtNjhmNC0wOGRkZDMzNDg3NTgiLCJ1bmlxdWVfbmFtZSI6ImVtcGxveWVlQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkVtcGxveWVlIiwiZXhwIjoxNzU0MzAxMzAxLCJpc3MiOiJUaWNrZXRpbmdTeXN0ZW1BcGkiLCJhdWQiOiJUaWNrZXRpbmdTeXN0ZW1BcHAifQ.K1EP9v1i680SR3ttHiD2cUoTbtOLDo3qlTj6HEHyuzc

body
{
  "title": "عنوان تیکت",
  "description": "توضیحات تیکت",
  "Status":1,
  "priority": 2,
  "createdByUserID": "98d2659a-b6fb-4d1c-68f4-08ddd3348758"
}
result
{
    "id": "c95c57bb-21d1-4c3a-6f26-08ddd334b7e7",
    "message": "تیکت با موفقیت ایجاد شد"
}


----- Project Structure
Ticket.API — Entry point

Ti.Application — CQRS + Business Logic

Ti.Infrastructure — Data Access (EF Core)

Ti.Domain — Entities & Interfaces

