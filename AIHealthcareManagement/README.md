# 🏥 AI Healthcare Management System

### Group 24

A web-based **AI Healthcare Management System** developed as a group project to provide an integrated platform for managing healthcare-related information and workflows.

The application provides modules for managing **doctors, patients, appointments, medical records, prescriptions**, and an **AI-assisted symptom assessment feature** through a centralized web application.

The project is developed using **ASP.NET Core MVC, C#, .NET 8, Entity Framework Core, Razor Views, and relational database technologies**.

---

# 📌 Project Overview

Healthcare management often involves maintaining information related to patients, doctors, appointments, prescriptions, and medical records across multiple workflows.

The **AI Healthcare Management System** is designed to centralize these healthcare operations into a single web-based platform.

The system provides functionality for:

- Doctor Management
- Patient Management
- Appointment Management
- Medical Records
- Prescription Management
- AI-Assisted Symptom Assessment
- Centralized healthcare information management
- Database-driven application workflows
- User-friendly web interface

The application follows the **Model-View-Controller (MVC)** architectural pattern.

---

# 🎯 Project Objective

The objective of this project is to develop a centralized healthcare management platform capable of handling major healthcare-related workflows through a single application.

The system aims to provide an organized approach for managing:

- Patient information
- Doctor profiles
- Doctor specialization and availability
- Appointment scheduling
- Medical history and records
- Prescriptions and medicines
- AI-assisted symptom analysis
- Healthcare-related workflows
- Secure and structured data management

---

# 👥 Team Members

| S. No. | Enrollment No. | Member Name |
|-------:|----------------|-------------|
| 1 | IN26009636 | Ritika Raghuvanshi |
| 2 | IN260011823 | Prasiddhi Jain |
| 3 | IN26011978 | Priyansh Bansal |
| 4 | IN26009739 | Harshali Panchal |
| 5 | IN26009756 | Nishant Sharma |
| 6 | IN26011855 | Vishesh Kumar Jain |
| 7 | IN26010908 | Kamal Laxman Balwani |

---

# 🤝 Team Contributions

## 1. Ritika Raghuvanshi — ID: IN26009636

**Status:** ✅ Completed

**Contribution**
- Carried out requirement analysis and initial project workflow planning.
- Defined functional requirements and module-level responsibilities.
- Coordinated requirements for the Patient and Doctor Management modules.
- Supported integration planning between Patient, Doctor, and Appointment modules.

**Project Area**
- Requirement Analysis
- Healthcare Workflow Planning
- Module Requirement Coordination

## 2. Prasiddhi Jain — ID: IN260011823

**Status:** ✅ Completed

**Contribution**
- Worked on database structure and entity relationship design for the system.
- Supported Entity Framework Core integration and database-related implementation.
- Helped define relationships between Patients, Doctors, Appointments, Medical Records, and Prescriptions.
- Contributed to database-level review and validation.

**Project Area**
- Database Design
- Entity Relationships
- Entity Framework Core Support

## 3. Priyansh Bansal — ID: IN26011978

**Status:** ✅ Completed

**Contribution**
- Implemented the Doctor Management module, including profile, specialization, and availability details.
- Defined doctor-related functionality and data structure.
- Supported integration of Doctor Management with the Appointment module.
- Contributed to doctor-related data and workflow integration.

**Project Area**
- Doctor Management
- Doctor Profiles and Availability
- Appointment Integration Support

## 4. Harshali Panchal — ID: IN26009739

**Status:** ✅ Completed

**Contribution**
- Set up and configured the ASP.NET Core MVC project, including Entity Framework Core and SQL Server integration.
- Implemented the Patient Management module with full CRUD (Create, Read, Update, Delete) functionality.
- Set up and managed the GitHub repository, including source code push and version control.
- Tested Patient module functionality and supported integration of other project modules.

**Project Area**
- Project Setup and Database Integration
- Patient Management
- GitHub Repository Management
- Testing and Module Integration

## 5. Nishant Sharma — ID: IN26009756

**Status:** ✅ Completed

**Contribution**
- Implemented the Appointment Management module and scheduling workflow.
- Defined patient-doctor appointment relationships.
- Worked on appointment status handling and related logic.
- Integrated appointments with the Patient and Doctor modules.

**Project Area**
- Appointment Management
- Appointment Scheduling
- Appointment Status Handling

## 6. Vishesh Kumar Jain — ID: IN26011855

**Status:** ✅ Completed

**Contribution**
- Implemented the Medical Records and Prescription Management modules.
- Worked on diagnosis and consultation notes structure.
- Handled medicine, dosage, frequency, and treatment duration details.
- Integrated Medical Records and Prescription data with Patient, Doctor, and Appointment information.

**Project Area**
- Medical Records
- Prescription Management
- Healthcare Data Integration

## 7. Kamal Laxman Balwani — ID: IN26010908

**Status:** ✅ Completed

**Contribution**
- Worked on AI-assisted Symptom Analysis, including research and integration planning.
- Implemented the AI Symptom Assessment functionality.
- Contributed to reminders and notifications requirements.
- Supported testing and documentation for the AI module.

**Project Area**
- AI Symptom Assessment
- AI Integration
- Reminders and Notifications
- Testing and Documentation

---

# 🛠️ Technology Stack

## Backend

- C#
- ASP.NET Core MVC
- .NET 8

## Database and ORM

- Entity Framework Core
- SQL Server
- PostgreSQL for cloud deployment support

## Frontend

- HTML
- CSS
- Bootstrap
- Razor Views

## Development and Deployment Tools

- Visual Studio
- Git
- GitHub
- SQL Server Management Studio

---

# 🏗️ System Architecture

The project follows the **ASP.NET Core MVC Architecture**.

```text
                    ┌──────────────────────┐
                    │      Web Browser     │
                    └──────────┬───────────┘
                               │
                               ▼
                    ┌──────────────────────┐
                    │   ASP.NET Core MVC   │
                    │                      │
                    │    Controllers       │
                    │    Razor Views       │
                    │    Models            │
                    └──────────┬───────────┘
                               │
                               ▼
                    ┌──────────────────────┐
                    │ Entity Framework Core│
                    └──────────┬───────────┘
                               │
                               ▼
                    ┌──────────────────────┐
                    │   Relational Database│
                    │ SQL Server/PostgreSQL│
                    └──────────────────────┘
```

---

# 📂 Main Modules

## 👨‍⚕️ Doctor Management

The Doctor Management module provides functionality related to doctor information and profiles.

Features include:

- Doctor profile management
- Doctor information display
- Specialization details
- Doctor availability-related functionality
- Doctor data integration with the application

## 👥 Patient Management

The Patient Management module handles patient-related healthcare information.

Features include:

- Patient information management
- Patient profile creation
- Patient listing
- Patient details
- Editing patient information
- Deleting patient records
- Database storage and retrieval

Patient-related information includes:

- Full Name
- Date of Birth
- Gender
- Blood Group
- Address
- Allergies
- Chronic Conditions
- Emergency Contact Name
- Emergency Contact Phone
- Created Date

## 📅 Appointment Management

The Appointment module manages doctor-patient appointment workflows.

Features include:

- Appointment scheduling
- Doctor-patient appointment association
- Appointment information management
- Appointment status handling
- Healthcare scheduling workflow

## 📋 Medical Records

The Medical Records module is designed to maintain patient healthcare information.

Features include:

- Patient medical record management
- Healthcare history storage
- Medical information organization
- Record-based healthcare workflow

## 💊 Prescription Management

The Prescription module manages prescription-related information.

Features include:

- Prescription information management
- Medicine details
- Dosage-related information
- Treatment instructions
- Prescription data organization

## 🤖 AI Symptom Assessment

The AI Symptom Assessment module provides an AI-assisted approach for analyzing symptoms entered by users.

The module is designed to:

- Accept symptom-related information
- Process healthcare symptoms
- Provide AI-assisted assessment
- Support preliminary symptom analysis
- Display healthcare-related guidance through the application

This feature is intended for project demonstration and educational purposes and is not a replacement for professional medical diagnosis.

---

# 🗄️ Database Design

The system is designed around major healthcare-related entities.

Current and planned entities include:

- Users
- Roles
- Patients
- Doctors
- Doctor Availability
- Administrators
- Appointments
- Medical Records
- Prescriptions
- AI Symptom Assessments
- Reminders
- Notifications
- Audit Logs

Entity relationships and foreign keys are used to maintain consistency between healthcare modules.

---

# 📸 Application Dashboard

The application provides a centralized dashboard for accessing major healthcare modules.

Available sections include:

- Home
- Doctors
- Patients
- Appointments
- Medical Records
- Prescriptions
- AI Assessment

The dashboard acts as the main navigation point for the healthcare management system.