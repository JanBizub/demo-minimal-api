#nowarn "20"

open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection

type Employee = { Id: int; Name: string }
type Car = { Id: int; Make: string }

[<RequireQualifiedAccess>]
module EmployeeRepository =
    let getById employeeId = { Id = employeeId; Name = "Gopnik" }

    let getAll () =
        [ { Id = 1; Name = "Gopnik" }
          { Id = 2; Name = "Vatnik" }
          { Id = 3; Name = "Slav" }
          { Id = 4; Name = "Babushka" }
          { Id = 5; Name = "Gopnica" } ]
    
[<RequireQualifiedAccess>]
module CarRepository =
    let getById employeeId = { Id = employeeId; Make = "Gopnik" }

    let getAll () =
        [ { Id = 1; Make = "BMW" }
          { Id = 2; Make = "Mercedes" }
          { Id = 3; Make = "Honda" }
          { Id = 4; Make = "GAZ" } ]
        
        
let registerEmployeeApis (app: WebApplication) =
    app.MapGet("api/employee/{id}", Func<int, Employee>(fun id -> id |> EmployeeRepository.getById))
    app.MapGet("api/employee", Func<Employee list>(fun () -> EmployeeRepository.getAll ()))
    
let registerCarApis (app: WebApplication) =
    app.MapGet("api/car/{id}", Func<int, Car>(fun id -> id |> CarRepository.getById))
    app.MapGet("api/car", Func<Car list>(fun () -> CarRepository.getAll ()))


[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    // Swagger ---------------------------------------------------------------------------------------------------------
    builder.Services.AddEndpointsApiExplorer()
    builder.Services.AddSwaggerGen()
    let app = builder.Build()

    app.MapGet("/", Func<string>(fun () -> "Hello World!")) |> ignore
    
    app |> registerEmployeeApis
    app |> registerCarApis
    
    // Swagger ---------------------------------------------------------------------------------------------------------
    app.UseSwagger()
    app.UseSwaggerUI()
    app.Run()

    0 // Exit code

