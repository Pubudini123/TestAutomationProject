Overview

This repository contains automated UI tests for the FloAR application using C#, NUnit, Selenium WebDriver, and Protractor. The tests verify login functionality and ensure web application stability.

Technologies Used

    C# - Programming language for test development
    
    NUnit - Unit testing framework for structured test execution
    
    Selenium WebDriver - Browser automation tool
    
    Protractor for Selenium - Supports Angular application testing
    
    ExtentReports - Generates test execution reports
    
    Custom Utility Classes - Manages configuration and reporting functionalities

Project Structure

FloAR.TestAutomation/
│-- Pages/                  # Page Object Model implementation
│-- Tests/                  # Test classes
│-- Utilities/              # Helper methods and utilities
│-- ExtentReports/          # Test reports folder
│-- Drivers/                # WebDriver binaries
│-- TestData/               # Test Data
│-- README.md               # Project documentation

Prerequisites
    
    Install .NET SDK (latest version)
    
    Install Chrome WebDriver for Selenium
    
    Install NUnit Console for test execution
    
    Ensure Node.js and Protractor are installed for Angular testing:
    
      npm install -g protractor
      webdriver-manager update
      

Setup & Installation

    Clone the repository and restore dependencies:
    git clone https://github.com/Pubudini123/TestAutomationProject.git
    dotnet restore

Running the Tests

Run tests using NUnit console:

    dotnet test

    To run tests with ordered execution:
    
    dotnet test --filter "Category=Regression"


Test Reporting

    The framework generates ExtentReports for detailed execution logs. After running the tests, reports can be found at:
    
    FloAR.TestAutomation/ExtentReports/ExtentReports.html

    Open ExtentReports.html in a browser to view test results.
