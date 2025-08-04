Microservice Ticketing System

پروژه میکروسرویس تیکتینگ

این پروژه یک سیستم مدیریت تیکت است که با استفاده از Clean Architecture و CQRS pattern پیاده‌سازی شده است.

# پیش‌نیازها

- .NET 8.0 SDK
- SQL Server (LocalDB یا SQL Server Express)
- Visual Studio 2022 یا VS Code

# نحوه اجرای پروژه

مرحله 1: تنظیم دیتابیس
1. SQL Server را اجرا کنید
2. یک دیتابیس جدید با نام `Ticket` ایجاد کنید
3. connection string را در فایل `Ticket.API/appsettings.json` بررسی کنید:


{
  "ConnectionStrings": {
    "TicketConnection": "Server=.;Initial Catalog=Ticket;Persist Security Info=False;User ID=sa;Password=123456;TrustServerCertificate=True"
  }
}


مرحله 2: اجرای Migration ها
cd Ticket.API
dotnet ef database update

مرحله 3: اجرای پروژه
dotnet run

پروژه روی آدرس `http://localhost:5071` اجرا خواهد شد.

مرحله 4: دسترسی به Swagger UI
بعد از اجرای پروژه، به آدرس زیر بروید:
https://localhost:5071

-----نحوه seed کردن دیتابیس

روش 1: استفاده از API
برای ایجاد تیکت‌های نمونه، از endpoint زیر استفاده کنید:

```bash
POST http://localhost:5071/api/v1/Ticket/CreateTicket
Content-Type: application/json

{
  "title": "مشکل در سیستم",
  "description": "سیستم کند کار می‌کند",
  "priority": 2,
  "createdByUserID": "550e8400-e29b-41d4-a716-446655440000"
}
```

روش 2: استفاده از SQL Script

```sql
-- ایجاد تیکت‌های نمونه
INSERT INTO Ti.Tickets (Id, Title, Description, Status, Priority, CreatedByUserID, AssignedToUserId, CreatedAt, UpdatedAt)
VALUES 
('550e8400-e29b-41d4-a716-446655440001', 'مشکل در لاگین', 'کاربر نمی‌تواند وارد سیستم شود', 1, 3, '550e8400-e29b-41d4-a716-446655440000', NULL, GETDATE(), NULL),
('550e8400-e29b-41d4-a716-446655440002', 'درخواست ویژگی جدید', 'نیاز به قابلیت گزارش‌گیری داریم', 1, 2, '550e8400-e29b-41d4-a716-446655440000', NULL, GETDATE(), NULL),
('550e8400-e29b-41d4-a716-446655440003', 'بگ در صفحه اصلی', 'صفحه اصلی درست نمایش داده نمی‌شود', 2, 1, '550e8400-e29b-41d4-a716-446655440000', '550e8400-e29b-41d4-a716-446655440001', GETDATE(), NULL);
```

---- API Endpoints

1. ایجاد تیکت جدید
```http
POST /api/v1/Ticket/CreateTicket
Content-Type: application/json

{
  "title": "عنوان تیکت",
  "description": "توضیحات تیکت",
  "priority": 2,
  "createdByUserID": "550e8400-e29b-41d4-a716-446655440000"
}
```

 2. دریافت تیکت‌های کاربر
```http
GET /api/v1/Ticket/GetUserTickets?userId=550e8400-e29b-41d4-a716-446655440000
```

 3. دریافت همه تیکت‌ها
```http
GET /api/v1/Ticket/GetAllTickets
```

 4. تخصیص و تغییر وضعیت تیکت
```http
PUT /api/v1/Ticket/AssignTicket
Content-Type: application/json

{
  "ticketId": "550e8400-e29b-41d4-a716-446655440001",
  "status": 2,
  "assignedToUserId": "550e8400-e29b-41d4-a716-446655440001"
}
```

 5. آمار تیکت‌ها بر اساس وضعیت
```http
GET /api/v1/Ticket/TicketCountByStatus
```

---- فرضیات و تصمیمات

 1. معماری پروژه
- **Clean Architecture**: استفاده از لایه‌های Domain، Application، Infrastructure و API
- **CQRS Pattern**: جداسازی Commands و Queries
- **MediatR**: برای پیاده‌سازی CQRS
- **Entity Framework Core**: برای ORM

 2. مدل داده
- **Ticket Entity**: شامل فیلدهای Title، Description، Status، Priority، CreatedByUserID، AssignedToUserId
- **Status Enum**: Open (1)، InProgress (2)، Closed (3)
- **Priority Enum**: Low (1)، Medium (2)، High (3)

 3. تصمیمات فنی
- استفاده از GUID برای ID ها
- Audit fields (CreatedAt، UpdatedAt) در BaseEntity
- استفاده از Swagger برای مستندات API
- عدم نیاز به Authentication در این مرحله (قابل اضافه شدن)

 ساختار پروژه

```
microservice-tickting/
├── Ticket.API/                 # لایه API
│   ├── Controllers/           # کنترلرها
│   ├── Program.cs            # تنظیمات برنامه
│   └── appsettings.json      # تنظیمات
├── Ti.Application/            # لایه Application
│   ├── Features/             # Commands و Queries
│   └── Contracts/            # Interfaces
├── Ti.Domain/                # لایه Domain
│   ├── Entities/             # موجودیت‌ها
│   └── Enums/               # Enum ها
└── Ti.Infrastructure/        # لایه Infrastructure
    ├── Persistence/          # DbContext
    ├── Repositories/         # Repository ها
    └── DbConfiguration/      # Entity Configurations
```

---- تست API

 با استفاده از Postman
POST http://localhost:5071/api/v1/Ticket/CreateTicket

raw json:
{
  "title": "عنوان تیکت",
  "description": "توضیحات تیکت",
  "priority": 2,
  "createdByUserID": "550e8400-e29b-41d4-a716-446655440000"
}

