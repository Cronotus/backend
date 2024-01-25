# Cronotus Backend Repository

## Prerequisites

- Ensure you have [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) installed on your development machine.
- Clone the repository containing the .NET Web API project.
- Ensure you you have a [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) running on your device.
- While not absolutely neccessary, it is also recommended to have [SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16) as well.

## Creating a secret key environment variable for JWT based authentication:

### 1. Open your terminal in administrator mode

- Navigate to `Start -> Command Prompt -> Run as administrator`

## 2. Creating an environment variable

- ```bash
  setx SECRET "ThisWillBeYourSuperLongAndSuperSecretSecretKeyThatNoOneEverWillGuess123456789!!!!!!!!!" /M
  ```

## Establishing your Microsoft SQL Server Management Studio connection

There are a few that need to be configured here

- Server type: `Database engine`
- Server name: `.`
- Authentication: `Windows Authentication`

## Configuring 'launchSettings.json'

As the project is configured to specific ports by default you will have to follow these settings to be able to run without errors

### Make sure your 'https' profile is configured by the following parameters

- ```json
  "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger/index.html",
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  ```

# Setting Up Local Database Configuration with Entity Framework Migrations

To enable local access to the database configuration, you'll need to run Entity Framework migrations. Follow the step-by-step guide below using Visual Studio 2022.

## Prerequisites

- Ensure you have Visual Studio 2022 installed on your development machine.
- Clone the repository containing the .NET Web API project.

## Step-by-Step Guide:

### 1. Open the Solution in Visual Studio 2022

- Launch Visual Studio 2022.
- Navigate to `File -> Open -> Project/Solution` and select your .NET Web API solution file.

### 2. Open Package Manager Console

- In Visual Studio, go to `View -> Other Windows -> Package Manager Console`.

### 3. Set Default Project

- In the Package Manager Console, make sure the default project is set to the project containing your DbContext. If it's not set, use the following command:
  ```bash
  PM> Set-DefaultProject YourDbContextProjectName
  ```
  Replace `YourDbContextProjectName` with the actual name of the project containing your DbContext.

### 4. Enable Migrations

- Run the following command to enable migrations:
  ```bash
  PM> Enable-Migrations
  ```

### 5. Add Initial Migration

- Create an initial migration to generate the necessary database schema:
  ```bash
  PM> Add-Migration InitialCreate
  ```

### 6. Update Database

- Apply the migration to update the local database:
  ```bash
  PM> Update-Database
  ```

### 7. Verify Database

- Check your local database to ensure the necessary tables and schema have been created.

Now, your local environment is configured with the latest database schema. You can run and test your .NET Web API locally with the updated database configuration.
