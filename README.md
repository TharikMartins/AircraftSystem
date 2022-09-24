# AircraftSystem

FrontEnd : Angular 14
BackEnd : .NET Core 3.1 com Entity Framework Core


## Web

Para rodar o projeto web é necessário entrar dentro da pasta AircraftSystem\src\Aircraft.Web\web e rodar os seguintes comandos:

```sh
cd {repositorio}/AircraftSystem\src\Aircraft.Web\web
npm i
ng serve
```

A aplicação está escutando em http://localhost:4200

## API

Para rodar o projeto de api é necessário entrar dentro da pasta AircraftSystem\src\Aircraft.API e rodar os seguintes comandos:

```sh
cd {repositorio}/AircraftSystem\src\Aircraft.API
dotnet build
dotnet run
```

A aplicação está escutando em http://localhost:5000.

O projeto de API possui SWAGGER para a documentação dos endpoint. Para acessar o swagger http://localhost:5000/swagger/index.html

## Repositório 

É necessário rodar o comando ```update-database``` dentro do Package Manage Console para criar as estruturas do banco de dados.

![image](https://user-images.githubusercontent.com/31320174/192117426-6be26dd5-c2c3-421e-8fb8-6858aa4b7f9c.png)

