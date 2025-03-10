open Aspire.Hosting

let args = System.Environment.GetCommandLineArgs()[1..]
let builder = DistributedApplication.CreateBuilder(args)

// Declare your resources here!

builder.Build().Run()
