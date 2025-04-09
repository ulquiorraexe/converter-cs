# Unit Converter Console App (C#)

This is a console-based Unit Converter application written in C#. It allows users to convert between different units of temperature, distance, length, and volume.

## Features

- Temperature conversions:
  - Fahrenheit to Celsius
  - Celsius to Fahrenheit
- Distance conversions:
  - Miles to Kilometers
  - Kilometers to Miles
- Length conversions:
  - Feet to Centimeters
  - Centimeters to Feet
- Volume conversions:
  - Gallons to Liters
  - Liters to Gallons
- Tracks the number of times the application has been used
- Allows continuous conversions until the user exits

## How It Works

- The application presents a menu with 8 conversion options and an option to exit.
- The user selects a conversion option.
- The program prompts for a numerical input value.
- It performs the conversion using the appropriate converter class implementing the `IConverter` interface.
- The result is displayed in the console.
- The usage counter is incremented after each successful conversion.
- The loop continues until the user chooses to exit the program.

## Technologies Used

- C# (.NET Console Application)
- Interfaces and Abstraction
- Object-Oriented Programming Principles

## Project Structure

- `IConverter`: Interface defining `Convert` and `ConvertBack` methods for unit conversions.
- `TemperatureConverter`, `DistanceConverter`, `LengthConverter`, `VolumeConverter`: Concrete classes implementing the conversion logic for each type.
- `Program`: The main class handling user interaction, input validation, menu logic, and output display.

## How to Run

- Create a new Console App project in Visual Studio or any C# IDE.
- Copy and paste the provided code into your `Program.cs` file.
- Build and run the project.
- Follow the console instructions to perform conversions.
