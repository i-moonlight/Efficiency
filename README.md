# Efficiency

This is a personal project that aims to develop a multiplatform webapp to serve as a dashboard, where a retail store's manager or supervisor can watch over his sellers' performance.

This project is currently in development using Angular 15, ASP.NET CORE 6 and MySQL.

| :placard: Vitrine.Dev |     |
| -------------  | --- |
| :sparkles: Nome        | **Efficiency**
| :label: Front-End | Angular 15, Typescript, Bootstrap, CSS
| :label: Back-End | ASP.NET Core 6, C#, MySQL
| :rocket: API         | https://localhost:7280 **follow instructions bellow**
| :rocket: Front-End         | http://localhost:4200 **follow instructions bellow**

<!-- Inserir imagem com a #vitrinedev ao final do link -->
## Screenshots
![](https://i.imgur.com/Bz9CX86.png#vitrinedev)


## Original Design

The original design of this tool was made using [Figma](https://www.figma.com/) to wireframe everything and the font combination was made with [FontJoy](https://fontjoy.com/)

Take a look at the design project [Here](https://www.figma.com/file/eJeiDWUWPk2pyjQLgjrANP/Efficiency?t=49xESy1iYdPTynAV-0)


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
  https://localhost:7280/swagger/index.html
```

Or access it via other tool of your liking such as:

- [Postman](https://www.postman.com/downloads/)
- [Insomnia](https://insomnia.rest/download)


## API Documentation

### User
##### Get All

```http
  GET /user
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `` | `` | It recieves no arguments (for now) |

##### Get one user

```http
  GET /user/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The user's identification key |

##### Sign user in

```http
  POST /login
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `request`      | `LoginRequest` | **Mandatory**. User's login request object (for now) from the body of the request containing the user's e-mail and password |

##### Sign user up

```http
  POST /signup
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `userDTO`      | `PostUserDTO` | **Mandatory**. User's POST data transfer object (for now) from the body of the request containing the user's e-mail, password, first and last names, username, role, phone number and the company's id reference |

##### Update user information

```http
  PUT /user
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `userDTO`      | `PutUserDTO` | **Mandatory**. User's PUT data transfer object from the body of the request containing the user's id, e-mail, password, first and last names, role, phone number and the company's id reference |

##### Delete user

```http
  PUT /user/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. User's identification key |
