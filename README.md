# Trillo Backend - Hotel Booking System API

[Tutorial Document](https://ella0110.github.io/)

This project is a **backend RESTful API** designed for a hotel booking system, implemented using **C# and ASP.NET Core**, and utilizing **SQL Server** as the database. The API provides essential services such as booking management, room availability, and customer records.

## Features

- **ASP.NET Core and C#**: The entire backend is built using ASP.NET Core to ensure scalability and maintainability.
- **EF Core ORM**: Simplified data access and manipulation with Entity Framework Core.
- **SQL Server**: Handles the relational database, ensuring efficient data storage and retrieval.
- **Swagger Documentation**: Provides clear API documentation, allowing easy testing and exploration of the endpoints.
- **Dockerized Setup**: The API and SQL Server are containerized for local testing with Docker Compose.
- **AWS ECS Deployment**: The entire backend stack is deployed to AWS ECS, ensuring cloud scalability and high availability.

## Project Setup

1. **Clone the Repository**
    
    Start by cloning the repository to your local machine.
    
    ```bash
    
    git clone git@github.com:Ella0110/TrilloBackend.git
    ```
    
2. **Install Dependencies**
    
    Install dependencies with [Tutorial](https://ella0110.github.io/)
    
3. **Database Setup**
    
    The project uses **SQL Server** for database management, and you can manage the database using **Beekeeper**.
    
4. **Run with Docker Compose**
    
    To facilitate easy local testing, both the API and the SQL Server database are bundled using Docker Compose.
    
5. **Testing and API Documentation**
    
    Use Swagger to interact with and test the API. Navigate to the following URL after running the project:
    
    ```bash
    http://localhost:port/swagger/index.html
    ```
    
6. **Deployment to AWS ECS**
    
    After local testing, the backend is deployed to **AWS ECS**. The containerized services, including the API and SQL Server, are configured for deployment on the cloud, ensuring the system runs efficiently.
