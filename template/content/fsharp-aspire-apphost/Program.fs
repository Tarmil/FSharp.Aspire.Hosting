open Aspire.Hosting

let builder = DistributedApplication.CreateBuilder(System.Environment.GetCommandLineArgs())

// Declare your resources here!

builder.Build().Run()
