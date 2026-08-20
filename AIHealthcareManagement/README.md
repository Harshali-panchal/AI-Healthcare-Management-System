# 🏥 AI Healthcare Management System

### Group 24

A web-based **AI Healthcare Management System** developed as a group project to provide an integrated platform for managing patients, doctors, appointments, medical records, prescriptions, and AI-assisted healthcare features.

The system is being developed using **ASP.NET Core MVC, C#, Entity Framework Core, and Microsoft SQL Server**.

---

## 👥 Team Members

| Enrollment No. | Member Name |
|---|---|
| IN26009636 | Ritika Raghuvanshi |
| IN260011823 | Prasiddhi Jain |
| IN26011978 | Priyansh Bansal |
| IN26009739 | Harshali Panchal |
| IN26009756 | Nishant Sharma |
| IN26011855 | Vishesh Kumar Jain |
| IN26010908 | Kamal Laxman Balwani |

---

## 🎯 Project Objective

The objective of this project is to develop a centralized healthcare management platform that can manage healthcare-related information and workflows through a single web application.

The system is planned to support:

- Patient profile management
- Doctor profile management
- Doctor availability
- Appointment management
- Medical records
- Prescription management
- AI-assisted symptom assessment
- Reminders and notifications
- User roles and access control
- Security and audit logging

---

## 🛠️ Technology Stack

### Backend
- C#
- ASP.NET Core MVC
- .NET 8

### Database
- Microsoft SQL Server
- Entity Framework Core

### Frontend
- HTML
- CSS
- Bootstrap
- Razor Views

### Tools
- Visual Studio
- Git
- GitHub
- SQL Server Management Studio

---

## 🏗️ System Architecture

The project follows an **ASP.NET Core MVC architecture**.

```text
                    ┌──────────────────────┐
                    │      Web Browser     │
                    └──────────┬───────────┘
                               │
                               ▼
                    ┌──────────────────────┐
                    │   ASP.NET Core MVC   │
                    │                      │
                    │ Controllers          │
                    │ Razor Views          │
                    │ Models               │
                    └──────────┬───────────┘
                               │
                               ▼
                    ┌──────────────────────┐
                    │  Entity Framework    │
                    │       Core           │
                    └──────────┬───────────┘
                               │
                               ▼
                    ┌──────────────────────┐
                    │   Microsoft SQL      │
                    │      Server          │
                    └──────────────────────┘
