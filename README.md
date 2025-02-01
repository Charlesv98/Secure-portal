Project Description

This project represents the creation of a secure portal for users of the soundyard.club distribution platform. The application was developed using ASP.NET MVC 5 and utilizes Bootstrap 4 for the admin interface and dashboard.

The project includes the following features:

    User authentication via FBA (Forms-based Authentication) with stored credentials in an SQL database (using ASP.NET Identity).
    Role management for controlling user permissions.
    Internal pages (Dashboard, Report, Administration) available only after login.
    SMTP server for sending activation emails upon registration.
    Anonymous registration form for new users (first name, last name, email address).

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

Installation
1. Clone the project

Clone this project to your local machine:

git clone https://github.com/YourAccount/soundyard-club.git

2. Set up the database

    Install SQL Express and create a database named sy_club.
    In appsettings.json, configure the connection string to the database.

3. Running the Application

Once the database and SMTP server are configured, you can run the application using Visual Studio.
Technologies

    ASP.NET MVC 5
    Bootstrap 4
    ASP.NET Identity for authentication and user management
    SQL Express for the database
    SMTP server for sending activation emails
