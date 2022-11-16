# Minimal API in F#

## There is a problem with F# functions in minimal API:
https://github.com/fsharp/fslang-suggestions/issues/1145 -> https://github.com/fsharp/fslang-suggestions/issues/1083

## Create a project command:
dotnet new web --output MiniApi -lang F# -n MiniApi

## Checklist: 
- Use SWAGGER
- Dependency Injection (use https://www.sqlite.org/index.html)
- Access HttpContext
- Serve Content HTML, css, js
- AZURE AD AUTH (Create separate project for that)
- Serialization