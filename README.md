# 🐾 PetConnect

**PetConnect** is a full-stack web application built using ASP.NET Core MVC architecture. It connects **pet owners**, **veterinarians**, **shelter owners**, and **administrators**, providing features like adoptions, appointments, pet health records, and role-based access control.

---

## 🛠️ Features

### 🔐 User Authentication & Roles
- Secure login and registration using **ASP.NET Core Identity**.
- System supports four roles:
  - **Admin**
  - **Customer**
  - **Doctor**
  - **Shelter Owner**
- Each role has a unique dashboard and access permissions.
- Role management and protection via `[Authorize]` attributes.

### 👥 User Registration & Profile Management
- Registration for **Doctors** with required information and validations.
- Admin handles approval or rejection of newly registered Doctors.
- Display and update user profiles with uploaded profile pictures.

### 🐾 Pet Management
- Add, edit, and delete pets (by Shelter Owners).
- Customers can view pet cards, including image, type, breed, and category.
- Upload pet images with validations.
- Customers can request **adoptions** for available pets.
- Admin reviews and approves pet submissions.

### 🏷️ Category & Breed Management
- Manage and validate **categories** and **breeds** for pets.
- Categories and breeds are used when creating or editing pet profiles.

### 📩 Adoption Requests
- **Customers** can submit adoption requests for pets.
- **Admins** can review, accept, or reject these requests.

### 🩺 Doctor Management
- Display a full list of **Doctors** with details and profile view.
- Admin approval system for newly registered doctors.
- Doctors can access assigned pet profiles and medical records.

### 🧑‍💼 Admin Dashboard
- Full admin access to manage:
  - Users and roles
  - Pet entries and images
  - Doctor approvals
  - Adoption requests
  - Category and breed definitions

---

## 🧱 Architecture

### ✅ 3-Tier Architecture using MVC

1. **Presentation Layer (PL)**  
   - ASP.NET Core MVC Controllers and Razor Views  
   - HTML, CSS, JS, Bootstrap, jQuery  

2. **Business Logic Layer (BLL)**  
   - Services handling business rules (e.g. `AdoptionService`, `DoctorService`, `PetService`)  
   - DTOs for secure data transfer  

3. **Data Access Layer (DAL)**  
   - Entity Framework Core for DB access  
   - Repository & Unit of Work Patterns  
   - SQL Server database  

---

## 🧩 Technologies Used

| Component        | Technology                         |
|------------------|-------------------------------------|
| Backend          | ASP.NET Core 8.0                    |
| Frontend         | HTML, CSS, JS, Bootstrap, jQuery    |
| Database         | SQL Server                          |
| ORM              | Entity Framework Core               |
| Authentication   | ASP.NET Core Identity               |
| Mapping          | AutoMapper                          |
| Architecture     | MVC, 3-Tier Architecture            |

---

## 🔁 Application Flow

1. **User Registration & Authentication**  
   - Users register and log in securely via Identity.
   - Roles are assigned by Admin where needed (e.g., Doctor, Shelter Owner).

2. **Role-Based Dashboards**  
   - Role-specific access: Customer, Doctor, Shelter Owner, Admin.

3. **Pet and Adoption Flow**
   - Shelter Owner adds a pet → Admin reviews/approves → Customer views and requests adoption → Admin handles request.

4. **Doctor Onboarding**
   - Doctor registers → Admin approves → Profile becomes visible → Can view pets and update medical records.

5. **Data Processing**
   - Frontend forms use validation.
   - Backend services handle logic in BLL → DAL persists to SQL Server via EF Core.
