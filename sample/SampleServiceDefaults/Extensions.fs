namespace Microsoft.Extensions.Hosting

open System.Runtime.CompilerServices
open Microsoft.Extensions.DependencyInjection

type Extensions =
    
    [<Extension>]
    static member AddServiceDefaults<'Builder when 'Builder :> IHostApplicationBuilder>(builder: 'Builder) =

        builder.Services.AddServiceDiscovery() |> ignore
        
        builder.Services.ConfigureHttpClientDefaults(fun http ->
            http.AddServiceDiscovery() |> ignore)
        |> ignore
