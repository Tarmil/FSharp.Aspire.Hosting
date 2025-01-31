open System
open System.Net.Http
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

type WebService(http: HttpClient) =
    member this.GetAsync() =
        task {
            let! response = http.GetAsync("/")
            return! response.Content.ReadAsStringAsync()
        }

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    builder.AddServiceDefaults()
    builder.Services.AddHttpClient<WebService>(fun client ->
        client.BaseAddress <- Uri "https+http://service") |> ignore

    let app = builder.Build()

    app.MapGet("/", Func<WebService, Task<string>>(fun http ->
        task {
            let! response = http.GetAsync()
            return $"Retrieved from web service: {response}"
        }))
    |> ignore

    app.Run()

    0 // Exit code

