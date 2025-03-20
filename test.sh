#!/usr/bin/env sh

set -e

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
dotnet add work/TemplateInstance package FSharp.Aspire.Hosting.AppHost \
    -s "$(dirname $PWD)/bin"
dotnet run \
    --project work/TemplateInstance \
    --launch-profile http \
    -- \
    --publisher manifest \
    --output-path "$PWD/actual/template-output/aspire-manifest.json"

### Check the generated files

diff -ruw --color expected actual
