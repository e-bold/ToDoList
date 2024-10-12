# Weather-Integrated To-Do List Application V2

## Project Overview
This application is a weather-integrated to-do list app designed to help users organize their tasks efficiently, with an added layer of customization based on local weather data. By leveraging real-time weather information, the app helps users prioritize their activities based on current conditions. The app offers two types of user accounts: a **Basic** version and a **Premium** version, which includes additional features such as gamification and progress tracking.

This project was developed as part of a group project for LaunchCode Web-Development bootcamp. Click [here](https://github.com/Git-Global-Liftoff/one2Do) to view the original version of the project. This version was enhanced by me to implement bonus features and hidden menu.

## Features
- **User Authentication & Account Management**: Users can register, log in, and manage their accounts with full CRUD functionality.
- **Two User Types**:
  - **Basic Users**: Create and manage personalized to-do lists.
  - **Premium Users**: Access additional features like (e.g., persistent weather data) and progress tracking for task completion.
- **To-Do List Management**: Full CRUD operations on to-do lists, allowing users to create, read, update, and delete tasks.
- **Weather Integration**: Real-time weather data is fetched using the [OpenWeatherMap API](https://openweathermap.org/api), helping users prioritize tasks based on current weather conditions.
- 
## Bonus Features
- **Photo Gallery (Extra Feature)**: Users can upload, view, and delete images, which can be associated with their profile or to-do lists.
- **Admin Dashboard (Extra Feature)**: A hidden admin interface for managing registered users and overseeing user data.

## Tech Stack
- **Backend**: ASP.NET Core MVC (C#)
- **Views**: Razor Pages
- **Database**: SQL Server (Relational database to store user data and to-do lists)
- **API Integrations**:
  - **OpenWeatherMap API**: Provides weather data to the app ([OpenWeatherMap API](https://openweathermap.org/api)).
