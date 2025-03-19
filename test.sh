#!/usr/bin/env sh

set -e

### Generate manifest from the sample project

mkdir -p tests/actual/sample-output
dotnet run --project sample/SampleAppHost --launch-profile http -- \
    --publisher manifest --output-path "$PWD/tests/actual/sample-output/aspire-manifest.json"

### Generate manifest from the project template

mkdir -p tests/actual/template-output
if dotnet new list fsharp-aspire-apphost 2>&1 >/dev/null; then
    dotnet new uninstall FSharp.Aspire.ProjectTemplates
fi
dotnet new install bin/FSharp.Aspire.ProjectTemplates.*.nupkg
rm -rf tests/work
dotnet new fsharp-aspire-apphost -o tests/work/TemplateInstance
dotnet run --project tests/work/TemplateInstance --launch-profile http -- \
    --publisher manifest --output-path "$PWD/tests/actual/template-output/aspire-manifest.json"

### Check the generated files

diff -ruw --color tests/expected/ tests/actual/
