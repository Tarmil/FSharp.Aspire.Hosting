#!/usr/bin/env sh

set -e

ROOTDIR="$PWD"

cd tests

### Generate manifest from the sample project

mkdir -p actual/sample-output
dotnet run \
    --project ../sample/SampleAppHost \
    --launch-profile http \
    -- \
    --publisher manifest \
    --output-path "$PWD/actual/sample-output/aspire-manifest.json"

### Generate manifest from the project template

mkdir -p actual/template-output
if dotnet new list fsharp-aspire-apphost --verbosity quiet; then
    dotnet new uninstall FSharp.Aspire.ProjectTemplates
fi
dotnet new install ../bin/FSharp.Aspire.ProjectTemplates.*.nupkg
rm -rf work
dotnet new fsharp-aspire-apphost -o work/TemplateInstance

cd work/TemplateInstance
dotnet new nugetconfig
dotnet nuget add source -n build-artifact "$ROOTDIR/bin"
dotnet add package FSharp.Aspire.Hosting.AppHost
dotnet run \
    --launch-profile http \
    -- \
    --publisher manifest \
    --output-path "$PWD/../../actual/template-output/aspire-manifest.json"
cd ../..

### Check the generated files

diff -ruw --color expected actual
