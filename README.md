

# 🚀 DevHireAI

> **AI-Powered Recruitment Platform built with ASP.NET Core 10, Clean Architecture, SQL Server, Docker, and JWT Authentication.**

DevHireAI is a modern recruitment platform that streamlines the hiring process for recruiters and candidates using AI-powered resume analysis, secure authentication, and scalable backend architecture.

---

# 📖 Project Overview

DevHireAI is designed to simplify recruitment by providing a secure and intelligent platform where:

* Candidates can register, upload resumes, and apply for jobs.
* Recruiters can create companies, post jobs, and review applications.
* AI analyzes resumes to provide insights.
* Secure JWT authentication protects all APIs.
* Docker support enables consistent deployment.

The project follows **Clean Architecture** to ensure maintainability, scalability, and separation of concerns.

---

# ✨ Features

## Authentication

* User Registration
* Login
* JWT Authentication
* Refresh Token
* Logout
* Email Verification
* Role-based Authorization

---

## User

* User Profile
* Get Current User
* Admin User Management

---

## Company

* Create Company
* View Companies
* Delete Company

---

## Job

* Create Job
* View Jobs
* Search Jobs
* Delete Job

---

## Job Applications

* Apply for Job
* View Applied Jobs
* Recruiter Application Management

---

## Resume

* Upload Resume
* View Resume
* Delete Resume

---

## AI

* AI Resume Analysis
* PDF Resume Parsing

---

## Security

* JWT Authentication
* Refresh Tokens
* Role-Based Authorization
* Global Exception Middleware
* Password Hashing

---

## Infrastructure

* SQL Server
* Entity Framework Core
* Docker
* Docker Compose
* Serilog Logging
* Health Checks

---

# 🏗 Architecture

```text
Client
   │
   ▼
ASP.NET Core API
   │
   ▼
Application Layer
   │
   ▼
Domain Layer
   │
   ▼
Infrastructure Layer
   │
   ▼
SQL Server
```

Architecture Pattern:

* Clean Architecture
* Repository Pattern
* Dependency Injection
* Service Layer
* SOLID Principles

---

# 🛠 Tech Stack

## Backend

* ASP.NET Core 10
* C#
* Entity Framework Core
* SQL Server

## Authentication

* JWT
* Refresh Tokens

## Validation

* FluentValidation

## Logging

* Serilog

## Documentation

* Swagger / OpenAPI

## AI

* AI Resume Analysis
* PDF Parser

## DevOps

* Docker
* Docker Compose
* GitHub Actions (CI)

---

# 📂 Folder Structure

```text
DevHireAI
│
├── DevHireAI.API
├── DevHireAI.Application
├── DevHireAI.Domain
├── DevHireAI.Infrastructure
├── DevHireAI.Shared
│
├── docker-compose.yml
├── README.md
└── DevHireAI.slnx
```

---


# 🏷️ GitHub Badges

Place these directly below your project title.

```markdown
![.NET](https://img.shields.io/badge/.NET-10.0-purple?style=for-the-badge&logo=.net)

![C#](https://img.shields.io/badge/C%23-Language-239120?style=for-the-badge&logo=c-sharp)

![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-red?style=for-the-badge&logo=microsoftsqlserver)

![Docker](https://img.shields.io/badge/Docker-Containerization-2496ED?style=for-the-badge&logo=docker)

![GitHub Actions](https://img.shields.io/badge/GitHub-Actions-2088FF?style=for-the-badge&logo=githubactions)

![Swagger](https://img.shields.io/badge/Swagger-API-85EA2D?style=for-the-badge&logo=swagger)

![JWT](https://img.shields.io/badge/JWT-Authentication-black?style=for-the-badge&logo=jsonwebtokens)

![License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge)

![Build](https://img.shields.io/badge/Build-Passing-brightgreen?style=for-the-badge)

![Version](https://img.shields.io/badge/Version-v1.0-blue?style=for-the-badge)
```

---

# 📋 Table of Contents

```markdown
## 📚 Table of Contents

- Project Overview
- Features
- Architecture
- Tech Stack
- Folder Structure
- Installation
- Configuration
- Docker
- API Documentation
- Authentication
- Health Checks
- Logging
- Screenshots
- Roadmap
- Contributing
- License
- Author
```

---

# 🌟 Why DevHireAI?

```markdown
## 🌟 Why DevHireAI?

Recruitment today involves managing candidates, job postings, resumes, and communication across multiple systems.

DevHireAI centralizes these workflows into a single AI-powered platform, helping recruiters and candidates interact efficiently while following modern software engineering practices.

The project demonstrates enterprise-level backend development using ASP.NET Core, Clean Architecture, SQL Server, JWT Authentication, Docker, and CI/CD.
```

---

# 🎯 Objectives

```markdown
## 🎯 Objectives

- Build a scalable recruitment platform.
- Demonstrate Clean Architecture.
- Implement secure JWT authentication.
- Integrate AI-powered resume analysis.
- Containerize the application using Docker.
- Prepare the project for cloud deployment.
- Follow production-ready development practices.
```

# ⚙ Installation

## Clone Repository

```bash
git clone https://github.com/arvi8080/DevHireAI.git
```

```bash
cd DevHireAI
```

---

## Restore Packages

```bash
dotnet restore
```

---

## Build

```bash
dotnet build
```

---

## Run

```bash
dotnet run --project DevHireAI.API
```

---

# 🐳 Docker & Docker Compose

## Build Image

```bash
docker build -t devhireai .
```

## Start Containers

```bash
docker compose up -d
```

## Stop Containers

```bash
docker compose down
```

---

# 📡 API Endpoints

## Authentication

```
POST /api/Auth/register
POST /api/Auth/login
POST /api/Auth/refresh
POST /api/Auth/logout
GET  /api/Auth/verify-email
```

---

## Users

```
GET /api/User
GET /api/User/{id}
GET /api/User/me
```

---

## Companies

```
POST /api/Company
GET  /api/Company
GET  /api/Company/{id}
DELETE /api/Company/{id}
```

---

## Jobs

```
POST /api/Job
GET /api/Job
GET /api/Job/{id}
DELETE /api/Job/{id}
GET /api/Job/search
```

---

## Job Applications

```
POST /api/JobApplication/apply
GET /api/JobApplication/my
GET /api/JobApplication/job/{jobId}
```

---

## Resume

```
POST /api/Resume/upload
GET /api/Resume/me
DELETE /api/Resume
```

---

## AI

```
POST /api/AI/analyze-resume
```

---

# 🔐 Authentication

DevHireAI uses JWT Authentication.

Protected endpoints require:

```
Authorization: Bearer <JWT_TOKEN>
```

Roles Supported

* Admin
* Recruiter
* Candidate

---

# ❤️ Health Checks

Health endpoint:

```
GET /health
```

Returns application health status.

---

# 📜 Logging

Logging is implemented using Serilog.

Logs include:

* API Requests
* Errors
* Exceptions
* Startup Information

Log files are stored in:

```
Logs/
```

---

# 📷 Screenshots

Add screenshots here.

Example:

```
screenshots/

login.png

dashboard.png

swagger.png

docker.png
```

---

# 🚀 Roadmap

Upcoming Features

* React Frontend
* Azure Deployment
* Redis Caching
* RabbitMQ
* AI Job Recommendation
* Email Notifications
* Interview Scheduling
* Unit Testing
* Integration Testing
* CI/CD Deployment
* Kubernetes
* Monitoring
* Admin Dashboard

---

# 🤝 Contributing

1. Fork Repository

2. Create Feature Branch

```bash
git checkout -b feature-name
```

3. Commit Changes

```bash
git commit -m "Added feature"
```

4. Push

```bash
git push origin feature-name
```

5. Create Pull Request

---

# 📄 License

This project is licensed under the MIT License.

---

# 👨‍💻 Author

**Arvind Prajapati**

B.Tech Computer Engineering

ASP.NET Core Backend Developer

GitHub: https://github.com/arvi8080

LinkedIn: https://linkedin.com/in/yourprofile

---
**Built with ❤️ using ASP.NET Core, Clean Architecture, SQL Server, Docker, and AI.**
