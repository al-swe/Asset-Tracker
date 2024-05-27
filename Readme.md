# Asset Management Console Application

## Overview

This console application is designed to manage a database of company assets. 
It allows users to add, edit, view, and remove assets, as well as generate reports on asset data. 
The application is built using C# and Entity Framework for database operations.

## Features

- **Add Asset**: Add new assets to the database with details such as type, brand, model, office, purchase date, cost, and local currency.
- **Edit Asset**: Modify existing asset information.
- **Remove Asset**: Delete assets from the database.
- **View Assets**: Display all assets with sorting options.
- **Generate Reports**: Create reports based on the assets data.

## Project Structure

- **AssetManager.cs**: Contains methods for adding, editing, and removing assets.
- **DisplayList.cs**: Handles displaying the list of assets and their details.
- **ArrowMenu.cs**: Provides a console-based menu navigation system.
- **Header.cs**: (Not shown in the code snippet) Likely contains methods for generating headers used in console displays.
- **MyDbContext.cs**: (Not shown in the code snippet) Represents the Entity Framework database context.
- **Asset.cs**: (Not shown in the code snippet) Represents the Asset model/entity.

## Installation

1. Clone repository:

```Clone the repository
git clone https://github.com/al_swe/MiniProjectCW2122
cd AssetManagement
```

2. Install dependencies:
Ensure you have .NET installed. You can download it from the [official website](https://dotnet.microsoft.com/download).

3. Setup the database:
Configure the connection string in 'MyDbContext.cs' and run migrations to set up the database schema.
```Setup the database
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4. Run the application:
```Run the application
dotnet run
```

## Usage
Upon running the application, you will be presented with a menu with the following options:

**View Assets**: View the list of all assets. You can sort by type or office.
**Add Asset**: Add a new asset by following the prompts.
**Edit Asset**: Edit an existing asset by entering its ID and the new values for its properties.
**Remove Asset**: Remove an asset by entering its ID.
**View Report**: Generate a report based on the assets data.
**Quit**: Exit the application.

## License
This project is licensed under the MIT License.

## Contact
For any inquiries or issues, please contact me.