Project Description

This project represents the creation of a secure portal for users of the soundyard.club distribution platform. The application was developed using ASP.NET MVC 5 and utilizes Bootstrap 4 for the admin interface and dashboard.

The project includes the following features:

1. User authentication via FBA (Forms-based Authentication) with stored credentials in an SQL database (using ASP.NET Identity).
2. Role management for controlling user permissions.
3. Internal pages (Dashboard, Report, Administration) available only after login.
4. SMTP server for sending activation emails upon registration.
5. Anonymous registration form for new users (first name, last name, email address).

Features
1. FBA Authentication

    Users can register and log in to the system.
    After registration, an activation email is sent for email verification.

2. Admin & Dashboard

    The application contains an administrative interface (Dashboard) based on the Bootstrap 4 template.
    The Dashboard page displays the Agreement value for the currently logged-in user.

3. User and Role Management

    A standard role system is implemented.
    Each role is extended with an Agreement property.

4. Database

    Uses a local SQL Express database named sy_club.
    A database backup is available for easy recovery.
