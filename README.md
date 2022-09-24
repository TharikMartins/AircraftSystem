# AircraftSystem

FrontEnd : Angular 14
BackEnd : .NET Core 3.1

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
