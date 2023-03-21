# Efficiency

This is a personal project that aims to develop a multiplatform webapp to serve as a dashboard, where a retail store's manager or supervisor can watch over his sellers' performance.

This project is currently in development using Angular 14, ASP.NET CORE 6 and MySQL.

| :placard: Vitrine.Dev |                                                      |
| --------------------- | ---------------------------------------------------- |
| :sparkles: Nome       | **Efficiency**                                       |
| :label: Front-End     | Angular 14, Typescript, Bootstrap, CSS               |
| :label: Back-End      | ASP.NET Core 6, C#, MySQL                            |
| :rocket: API          | http://localhost:5280 **follow instructions bellow** |
| :rocket: Front-End    | http://localhost:4200 **follow instructions bellow** |

<!-- Inserir imagem com a #vitrinedev ao final do link -->

## Screenshots

![](https://i.imgur.com/Bz9CX86.png#vitrinedev)

## Original Design

The original design of this tool was made using [Figma](https://www.figma.com/) to wireframe everything and the font combination was made with [FontJoy](https://fontjoy.com/)

Take a look at the design project [Here](https://www.figma.com/file/eJeiDWUWPk2pyjQLgjrANP/Efficiency---UI?node-id=0%3A1&t=doC8QosDWmOj2OBq-1)

## Installing prerequisites

Install Node.JS 16.19.0

```bash
  https://nodejs.org/download/release/v16.19.0/
```

Install .Net 6 LTS SDK

```bash
  https://dotnet.microsoft.com/en-us/download
```

Install Git Bash

```bash
  https://git-scm.com/downloads
```

Install MySQL

```bash
  https://dev.mysql.com/downloads/mysql/
```

**Suggestion** Install Microsoft's Visual Studio Code

```bash
  https://code.visualstudio.com/
```

## Running the front-end locally

Clone project

```bash
  git clone https://github.com/MarceloCFerraz/Efficiency.git
```

Enter on the project's directory

```bash
  cd Efficiency/front-end/
```

Install dependencies

```bash
  npm i
```

Build

```bash
  ng build
```

Run server

```bash
  ng serve -o
```

## Running the API locally

Clone project (if you haven't already)

```bash
  git clone https://github.com/MarceloCFerraz/Efficiency.git
```

Enter on the project's directory

```bash
  cd Efficiency/back-end/
```

Install Entity Framework tool to your .net installation

```bash
  dotnet tool install --global dotnet-ef
```

Create the database

```bash
  dotnet ef database update
```

Build

```bash
  dotnet build
```

Start the API server

```bash
  dotnet run
```

Access the API through Swagger

```bash
  http://localhost:5280/swagger/index.html
```

Or access it via other tool of your liking such as:

-   [Postman](https://www.postman.com/downloads/)
-   [Insomnia](https://insomnia.rest/download)

## API Documentation

### User

##### Get All

```http
  GET /user
```

| Parameter | Type | Description                        |
| :-------- | :--- | :--------------------------------- |
| ``        | ``   | It recieves no arguments (for now) |

##### Get one user

```http
  GET /user/${ID}
```

| Parameter | Type  | Description                                  |
| :-------- | :---- | :------------------------------------------- |
| `ID`      | `int` | **Mandatory**. The user's identification key |

##### Sign user in

```http
  POST /login
```

| Parameter | Type           | Descrição                                                                                                                   |
| :-------- | :------------- | :-------------------------------------------------------------------------------------------------------------------------- |
| `request` | `LoginRequest` | **Mandatory**. User's login request object (for now) from the body of the request containing the user's e-mail and password |

##### Sign user up

```http
  POST /signup
```

| Parameter | Type          | Description                                                                                                                                                                                                    |
| :-------- | :------------ | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `userDTO` | `PostUserDTO` | **Mandatory**. User's POST data transfer object (for now) from the body of the request containing the user's e-mail, password, first and last names, username, role, phone number and the Store's ID reference |

##### Update user information

```http
  PUT /user
```

| Parameter | Type         | Description                                                                                                                                                                                   |
| :-------- | :----------- | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `userDTO` | `PutUserDTO` | **Mandatory**. User's PUT data transfer object from the body of the request containing the user's ID, e-mail, password, first and last names, role, phone number and the Store's ID reference |

##### Delete user

```http
  PUT /user/${ID}
```

| Parameter | Type  | Description                              |
| :-------- | :---- | :--------------------------------------- |
| `ID`      | `int` | **Mandatory**. User's identification key |
