# TodoTracker - Sample Aspire Solution

TodoTracker is a sample distributed application built with **.NET Aspire 13.4**, **ASP.NET Core**, **PostgreSQL**, **Entity Framework Core**, and **GraphQL**.

The project demonstrates how Aspire can be used to orchestrate a local development environment for a modern cloud-ready application.

## What This Project Demonstrates

This sample includes several common application architecture concepts:

### Aspire AppHost orchestration

The application uses an Aspire AppHost to coordinate the services and infrastructure resources needed for local development.

The AppHost acts as the entry point for running the application and is responsible for starting related resources, such as the API service and database dependencies.

### ASP.NET Core API

The backend service is built with ASP.NET Core and exposes application functionality through an API layer.

This service contains the application endpoints and integrates with the rest of the system through Aspire-managed configuration and service defaults.

### PostgreSQL database

The application uses PostgreSQL as its relational database.

Aspire is used to simplify working with the database during local development by managing the database resource as part of the application environment.

### Entity Framework Core

Entity Framework Core is used for data access between the ASP.NET Core API and PostgreSQL.

The sample data model includes projects, todo items, tags, and a many-to-many relationship between todo items and tags.

### GraphQL with Hot Chocolate

The API uses Hot Chocolate to expose data through GraphQL.

This allows clients to query only the data they need and explore related entities such as projects, todo items, and tags.

### Service defaults

The project uses shared service defaults for common cloud-native application behavior, including:

- Health checks
- Service discovery
- Resilient HTTP client configuration
- OpenTelemetry logging, metrics, and tracing

These defaults help keep individual services consistent while reducing repeated setup code.

## Prerequisites

This project uses **Aspire 13.4** and targets **.NET 10**.

Follow the official Aspire prerequisite instructions here:

https://aspire.dev/get-started/prerequisites/

At a high level, you will need:

- The .NET SDK required for Aspire 13.4
- A supported container runtime such as Docker Desktop or Podman
- An editor or IDE that supports .NET development
- The Aspire CLI, if you want to run the application with `aspire run`

Refer to the official documentation above for the most up-to-date installation steps for Windows, macOS, and Linux.

## Getting Started

After installing the prerequisites, restore and build the solution:
