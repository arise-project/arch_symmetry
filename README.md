# Architecture symmetry

## Overview

The .NET Generator App is a prototype application designed to automate the creation of services and interfaces from a specified C# class model. The generated components are then added to the .NET Dependency Injection (DI) container, providing a seamless integration for dependency management.

## Features

- **Model-Based Service Generation:** The app reads a C# class model and automatically generates service classes and interfaces based on the defined properties.

- **Dependency Injection Integration:** Services and interfaces are added to the .NET DI container, ensuring proper dependency management and injection.

- **Customizable:** Users can define their own C# class models, allowing flexibility in generating services based on specific requirements.

## Prerequisites

- **.NET SDK:** Ensure that you have the .NET SDK installed on your machine. If not, you can download it [here](https://dotnet.microsoft.com/download).

## Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/yourusername/service-generator-dotnet.git
    ```

2. **Navigate to the project directory:**

    ```bash
    cd service-generator-dotnet
    ```

3. **Build the App:**

    ```bash
    dotnet build
    ```

## Usage

1. **Prepare Model:**
    - Create a C# class file with the required properties.

2. **Run the App:**

    ```bash
    dotnet run -- --modelPath YourModel.cs
    ```

    - Replace `YourModel.cs` with the path to your C# class model file.

3. **Generated Services:**
    - The app will generate service classes and interfaces based on the provided C# class model and add them to the .NET DI container.

## Example

```bash
dotnet run -- --modelPath MyModel.cs


[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/epirogov)
