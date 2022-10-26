
# generate rest API client

# cleanup
sudo rm -rf ./clients

# generate source code
docker run `
    --rm `
    -v ${PWD}:/local `
    openapitools/openapi-generator-cli `
    generate `
    -i /local/swagger.json `
    -g csharp-netcore `
    -o /local/clients/generated `
    --additional-properties packageName=TaskiumRestAPI `
    --additional-properties targetFramework=netstandard2.0 `
    --library httpclient

# docker generate it as root we need to change the ownership
sudo chown -R $env:USER ./clients

# build the lib
Set-Location ./clients/generated
dotnet build

# copy the artifact
cp ./src/TaskiumRestAPI/bin/Debug/netstandard2.0/TaskiumRestAPI.dll ../../

Set-Location -
