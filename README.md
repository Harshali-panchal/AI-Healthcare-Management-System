# AI Healthcare Management System

## Group 24

An AI-powered healthcare management system designed to provide a centralized platform for patients, doctors, and administrators. The system aims to simplify patient management, appointment scheduling, medical record handling, prescriptions, reminders, notifications, and AI-assisted symptom analysis.

---

## Project Overview

The **AI Healthcare Management System** is a web-based healthcare management application developed using ASP.NET Core and Entity Framework Core.

The system is designed around three major user roles:

- Patient
- Doctor
- Administrator

The application provides a structured platform for managing healthcare-related information while integrating AI-assisted functionality for preliminary symptom analysis.

---

## Technology Stack

### Frontend
- HTML5
- CSS3
- Bootstrap
- Razor Views

### Backend
- ASP.NET Core
- C#
- .NET 8
- MVC Architecture

### Database
- Microsoft SQL Server
- Entity Framework Core
- Entity Framework Core Migrations

### Development Tools
- Visual Studio
- Git
- GitHub

---

## Key Features

### User Management
- User registration and management
- Role-based access
- Patient, Doctor and Administrator profiles
- Account status management

### Patient Management
- Patient profile creation
- Patient information management
- Date of birth and gender details
- Blood group information
- Address and allergy information
- Chronic condition details
- Emergency contact information
- Patient CRUD operations

### Doctor Management
- Doctor profile management
- Specialization details
- Qualification and license information
- Years of experience
- Consultation fee
- Doctor availability

### Appointment Management
- Doctor and patient appointment management
- Appointment date and time
- Appointment status
- Reason for visit
- Appointment updates

### Medical Records & Prescriptions
- Medical record management
- Diagnosis and consultation notes
- Prescription management
- Medicine name, dosage and frequency
- Treatment duration and instructions

### AI Symptom Analysis
- Patient symptom input
- AI-assisted preliminary analysis
- Urgency level
- Confidence score
- Model version tracking

### Reminders & Notifications
- Appointment reminders
- Medication reminders
- Follow-up reminders
- In-app notifications
- Email/SMS notification support planned

### Security & Audit
- Role-based access
- User security information
- Audit logging
- Tracking of important system actions

---

# Team Members

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

# Individual Contributions

## 1. Ritika Raghuvanshi

### Contribution
- Requirement analysis and project planning
- Healthcare system workflow analysis
- Patient and doctor module planning
- Functional requirements discussion
- Coordination of module integration

### Current Work
- Requirement refinement
- Module coordination
- Reviewing overall project workflow

---

## 2. Prasiddhi Jain

### Contribution
- Database and data-model planning
- Healthcare entities and relationships
- Database structure analysis
- Support for Entity Framework Core integration

### Current Work
- Database-related implementation
- Reviewing relationships between system entities
- Supporting database integration

---

## 3. Priyansh Bansal

### Contribution
- Doctor management module planning
- Doctor profile functionality
- Doctor specialization and availability requirements
- Support for appointment-related functionality

### Current Work
- Doctor management module
- Doctor availability
- Appointment management

---

## 4. Harshali Panchal

### Contribution
- ASP.NET Core MVC implementation
- Entity Framework Core integration
- ApplicationDbContext configuration
- Patient Management module
- Patient CRUD implementation
- SQL Server database integration
- Testing patient data insertion and retrieval
- GitHub repository management and project integration

### Completed Work
- Patient Create functionality
- Patient data successfully stored in SQL Server
- Patient data successfully displayed from SQL Server
- Patient CRUD structure implemented
- Database connection and Entity Framework Core integration configured

### Current Work
- Complete CRUD verification
- Integration of remaining modules
- Testing and debugging

---

## 5. Nishant Sharma

### Contribution
- Appointment management planning
- Appointment workflow
- Patient-doctor appointment relationships
- Appointment status handling

### Current Work
- Appointment module implementation
- Appointment scheduling workflow
- Appointment testing

---

## 6. Vishesh Kumar Jain

### Contribution
- Medical records and prescription module planning
- Medical record structure
- Prescription workflow
- Medicine and dosage information handling

### Current Work
- Medical Records module
- Prescription management
- Integration with patient and doctor data

---

## 7. Kamal Laxman Balwani

### Contribution
- AI-assisted symptom analysis planning
- AI integration research
- Reminders and notification requirements
- Testing and documentation support

### Current Work
- AI symptom analysis
- AI integration
- Reminder and notification functionality
- Testing and documentation

---

# Current Project Progress

## Completed

- ASP.NET Core MVC project setup
- .NET 8 configuration
- Entity Framework Core integration
- SQL Server database integration
- Database models scaffolded
- ApplicationDbContext configured
- Patient Management module implemented
- Patient Create functionality implemented
- Patient data successfully stored in SQL Server
- Patient data successfully retrieved and displayed
- Git repository initialized
- Project uploaded to GitHub
- Project README and team contribution documentation prepared

## In Progress

- Complete Patient CRUD verification
- Doctor Management
- Appointment Management
- Medical Records
- Prescription Management
- AI Symptom Analysis
- AI Integration
- Authentication and Role-Based Access
- Reminders and Notifications
- UI improvements
- Testing and documentation

---

# Database Design

The system uses Microsoft SQL Server with Entity Framework Core.

Major database entities include:

- Roles
- Users
- Patients
- Doctors
- DoctorAvailability
- Administrators
- Appointments
- MedicalRecords
- Prescriptions
- AISymptomAssessments
- Reminders
- Notifications
- AuditLogs

The database uses primary keys, foreign keys, relationships and indexes to maintain data consistency and support efficient queries.

---

# Current Working Module: Patient Management

The Patient Management module is currently functional.

Implemented functionality includes:

- Creating a patient
- Storing patient information in SQL Server
- Viewing patient records
- Editing patient information
- Deleting patient records
- Displaying patient information in the MVC view

Patient information includes:

- Full Name
- Date of Birth
- Gender
- Blood Group
- Address
- Allergies
- Chronic Conditions
- Emergency Contact Name
- Emergency Contact Phone

---

# Project Structure

```text
AIHealthcareManagement
│
├── Controllers
│   ├── HomeController.cs
│   └── PatientsController.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Models
│   ├── Patient.cs
│   ├── Doctor.cs
│   ├── Administrator.cs
│   ├── Appointment.cs
│   ├── MedicalRecord.cs
│   ├── Prescription.cs
│   ├── AISymptomAssessment.cs
│   └── ...
│
├── Views
│   ├── Home
│   ├── Patients
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Details.cshtml
│   │   ├── Delete.cshtml
│   │   └── Index.cshtml
│   └── Shared
│
├── wwwroot
│
├── AIHealthcareDatabase.sql
├── appsettings.json
├── Program.cs
└── README.md
