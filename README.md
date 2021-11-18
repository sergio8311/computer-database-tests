# Computer Database Tests
### This is a simple test project which runs tests against https://computer-database.herokuapp.com/computers web application
## Technologies and tools:
- .Net Core 3.1
- nUnit as a test runner
- Selenium 4 as a web driver
- Page Object Model pattern for encapsulating elements and methods in the test project
## Framework and Patterns:
**_Framework_**
- **Core** project - mostly common Models, Helper methods, etc.
- **UI.Tests** project - here the Tests layer, Page objects layer, Driver initialization, and helpers for the UI tests
- Potentially API tests project could be added to the current solution

**_Patterns_**
- For the UI test framework has been chosen Page Object Model pattern. It allows encapsulating locators and page methods into separate objects. It enhances test maintenance, scalability and reduces code duplication
