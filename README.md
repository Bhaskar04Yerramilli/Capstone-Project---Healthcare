# Healthcare Analytics Platform

A secure and scalable Healthcare Management System developed using ASP.NET Core MVC, ASP.NET Core Web API, Entity Framework Core, SQL Server, Bootstrap, and JWT Authentication.

---

# Project Overview

The Healthcare Analytics Platform is a web-based healthcare management application designed to manage patients, doctors, appointments, authentication, and healthcare analytics efficiently through a centralized system.

The project was developed as part of the **WIPRO NGA – .NET Full Stack Training Program** to demonstrate full-stack development concepts, layered architecture, secure authentication, REST APIs, database integration, and analytics reporting.

---

# Features

## Authentication & Authorization

* User Registration
* User Login
* JWT Authentication
* Protected APIs
* Role-Based Authorization

## Patient Management

* Add Patient
* Edit Patient
* Delete Patient
* Search Patients
* View Patient Records

## Doctor Management

* Add Doctor
* Edit Doctor
* Delete Doctor
* Search Doctors
* Manage Specializations

## Appointment Management

* Schedule Appointments
* Update Appointment Details
* Delete Appointments
* Search Appointments

## Reports & Analytics

* Dashboard Statistics
* Total Patients Count
* Total Doctors Count
* Total Appointments Count
* Bar Chart Visualization
* Pie Chart Visualization

## API Features

* RESTful APIs
* CRUD Operations
* Swagger Documentation
* JWT-Based Security

---

# Technologies Used

| Technology            | Purpose                     |
| --------------------- | --------------------------- |
| ASP.NET Core MVC      | Frontend Development        |
| ASP.NET Core Web API  | Backend API Development     |
| C#                    | Programming Language        |
| Entity Framework Core | ORM & Database Operations   |
| SQL Server            | Database                    |
| JWT Authentication    | Security & Authorization    |
| Bootstrap             | Responsive UI Design        |
| Chart.js              | Analytics & Visualization   |
| Swagger               | API Documentation & Testing |
| Visual Studio 2022    | Development Environment     |

---

# Project Architecture

The project follows Layered Architecture for better scalability and maintainability.

```text id="o6hplm"
HealthcareAnalytics.Web
HealthcareAnalytics.API
HealthcareAnalytics.Service
HealthcareAnalytics.Data
HealthcareAnalytics.Core
HealthcareAnalytics.Tests
```

## Layer Description

### HealthcareAnalytics.Web

Frontend MVC application containing Razor Views, Controllers, Bootstrap UI, and user interaction logic.

### HealthcareAnalytics.API

REST API layer handling HTTP requests, JWT Authentication, and API endpoints.

### HealthcareAnalytics.Service

Business logic layer responsible for processing application operations and validations.

### HealthcareAnalytics.Data

Database access layer containing DbContext, Entity Framework Core operations, and repositories.

### HealthcareAnalytics.Core

Contains entities, models, DTOs, and interfaces shared across the application.

### HealthcareAnalytics.Tests

Contains testing-related project structure for validation and future unit testing.

---

# System Workflow

```text id="2k4b5g"
User
 ↓
MVC Frontend
 ↓
API Layer
 ↓
Service Layer
 ↓
Data Layer
 ↓
SQL Server Database
```

---

# Database Tables

The project uses SQL Server database with Entity Framework Core.

## Main Tables

* Users
* Patients
* Doctors
* Appointments

## Relationships

* One Patient → Multiple Appointments
* One Doctor → Multiple Appointments

---

# JWT Authentication Flow

1. User registers and logs into the system.
2. Credentials are validated.
3. JWT token is generated.
4. Token is returned to frontend.
5. Protected APIs validate the token before processing requests.

JWT Authentication improves security and prevents unauthorized access.

---

# API Endpoints

## Authentication APIs

* POST `/api/Auth/register`
* POST `/api/Auth/login`

## Patients APIs

* GET `/api/Patients`
* POST `/api/Patients`
* PUT `/api/Patients/{id}`
* DELETE `/api/Patients/{id}`

## Doctors APIs

* GET `/api/Doctors`
* POST `/api/Doctors`
* PUT `/api/Doctors/{id}`
* DELETE `/api/Doctors/{id}`

## Appointments APIs

* GET `/api/Appointments`
* POST `/api/Appointments`
* PUT `/api/Appointments/{id}`
* DELETE `/api/Appointments/{id}`

---

# Reports & Analytics

The project includes an analytics dashboard displaying:

* Total Patients
* Total Doctors
* Total Appointments
* Bar Charts
* Pie Charts

Chart.js was used for graphical visualization of healthcare statistics.

---

# Security Features

* JWT Authentication
* Authorization Middleware
* Protected APIs
* Role-Based Authorization
* Secure Login System

---

# Testing

Testing performed:

* CRUD Operation Testing
* API Testing using Swagger
* Database Connectivity Testing
* Authentication Validation
* Frontend Functionality Testing

---

# Screenshots Included

* Home Page
* Patients Module
* Doctors Module
* Appointments Module
* Login & Registration
* Reports Dashboard
* Swagger API Testing
* SQL Database Tables

---

# How to Run the Project

## Prerequisites

* Visual Studio 2022
* SQL Server
* .NET SDK

---

## Steps

### 1. Clone Repository

```bash id="8w77y3"
git clone <repository-url>
```

### 2. Open Solution

Open solution file in Visual Studio 2022.

### 3. Configure Database

Update connection string inside:

```text id="ynk9jc"
appsettings.json
```

### 4. Apply Database Migrations

```bash id="z8tycs"
Update-Database
```

### 5. Run Application

Set:

```text id="3jkfjv"
HealthcareAnalytics.Web
```

as Startup Project and run the application.

---

# Future Enhancements

* Cloud Deployment using Azure
* Mobile Application
* AI-Based Healthcare Analytics
* Online Consultation System
* Email & SMS Notifications
* Advanced Reporting Dashboard

---

# Learning Outcomes

Through this project, the following concepts were learned:

* ASP.NET Core MVC
* Web API Development
* Entity Framework Core
* SQL Server Integration
* JWT Authentication
* Layered Architecture
* RESTful APIs
* Dependency Injection
* CRUD Operations
* Frontend & Backend Integration

---

# Author

## Subrahmanya Bala Bhaskar Yerramilli

WIPRO NGA – .NET Full Stack Training Program
