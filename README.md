# Selenium C# Test Automation Project - DemoQA (with SpecFlow)

This repository contains a C# test automation project using Selenium WebDriver and SpecFlow to automate tests for the DemoQA website with behavior-driven development (BDD) approach.

## Prerequisites
Before setting up and running this project, ensure that you have the following prerequisites:

- Visual Studio (or any other C# IDE) installed on your machine.
- .NET Core SDK installed on your machine.
- Selenium WebDriver for C# installed.
- SpecFlow NuGet package installed in the project.
- ExtentReports NuGet package installed in the project.

## Installation
1. Clone this repository to your local machine or download the source code as a ZIP file.
2. Open the solution file (SpecFlowDemoQA.sln) in Visual Studio.
3. Restore the NuGet packages to ensure all dependencies are installed.

## Project Structure
The project structure is organized as follows:
- Features: This directory contains the feature files written in the Gherkin language, which describe the behavior of the tests in a human-readable format.
- Pages: This directory contains page classes that represent the different pages of the DemoQA website. Each page class provides methods and properties to interact with the elements on that page.
- StepDefinitions: This directory contains step definition files, which map the steps defined in the feature files to the actual test code. Each step definition file corresponds to a feature file and contains the implementation of the step methods.
- Helper: This directory contains utility classes, such as the ExtentReport class responsible for managing the ExtentReports instance and the WebDriverFactory class responsible for creating an instance of the WebDriver.

## Executing Tests
To execute the tests:

1. Build the solution in Visual Studio.
2. Open the Test Explorer in Visual Studio (Test -> Windows -> Test Explorer).
3. Click on the Run All Tests button in the Test Explorer to execute all tests. (Alternatively, you can run individual tests or groups of tests.)
4. View the test execution results in the Test Explorer.

## Reporting
The project uses ExtentReports to generate detailed test reports. The reporting functionality is already integrated into the project using the ExtentReport class. The ExtentReports report will be generated automatically after test execution.

To access the generated report, navigate to the project's output directory and locate the TestResults folder. Open the HTML report file in any web browser to view the detailed test report.
