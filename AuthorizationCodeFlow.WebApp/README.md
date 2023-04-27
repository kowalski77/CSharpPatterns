# ASP.NET Core Web Application with Local and OAuth Authentication

This repository contains an example of an ASP.NET Core web application in C# that demonstrates the use of local and OAuth authentication, as well as authorization policies.

## Highlights
1. The application uses the Microsoft.AspNetCore.Authentication package to add authentication and authorization.
2. Two types of authentication are configured: a cookie-based one called "local" and another one using OAuth called "ext-oauth-provider". The OAuth authentication uses a mock OAuth provider available at "https://oauth.mocklab.io".
3. The application defines two authorization policies: "userPolicy", which requires local authentication, and "fullaccessPolicy", which requires authentication through the external OAuth provider.
4. The application has three main routes:
	a. "/weatherforecast": returns a random weather forecast and requires the "fullaccessPolicy" authorization policy (OAuth authentication).
	b. "/login-local": logs the user in with local authentication, adding the "usr" claim with the value "christian".
	c. "/login-ext": initiates the OAuth authentication flow and, upon successful completion, redirects the user to "/weatherforecast". This route requires the "userPolicy" authorization policy (local authentication).
5.The application also defines a WeatherForecast record that contains weather forecast information, including the date, temperature in Celsius, and a general weather summary.



## Getting Started
1. Clone this repository.
2. Open the project in your preferred IDE (e.g., Visual Studio, Visual Studio Code).
3. Ensure you have the necessary .NET SDKs installed (check the project file for target framework).
4. Run the application using your IDE or the dotnet run command.