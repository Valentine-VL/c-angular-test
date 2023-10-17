# Angular and .NET Core Web Application

## Introduction

This repository contains a simple web application built using Angular (frontend) and .NET Core (backend). The application allows users to view a list of items, add new items and calculate factorials concurrently.

## Prerequisites

Before getting started, ensure that you have the following software and tools installed on your system:

- Node.js and npm (Node Package Manager)
- Angular CLI
- .NET Core SDK

## Installation and Setup

Follow these steps to set up and run the web application on your local machine:

### Clone the Repository

```bash
git clone https://github.com/Valentine-VL/c-angular-test.git
cd angular-dotnet-app
```
#### Navigate to backend, build and run server:
```bash
cd ItemListAPi
dotnet build
dotnet run
cd ..
```

#### Navigate to frontend, install dependencies and run server:
```bash
cd items-list-app
npm install
ng serve
```

After these steps the application should be accessible in your web browser at http://localhost:4200.




