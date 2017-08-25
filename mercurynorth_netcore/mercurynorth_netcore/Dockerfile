# With help from: https://docs.docker.com/engine/examples/dotnetcore/#create-a-dockerfile-for-an-aspnet-core-application

# Oddly enough, what we are doing is creating a container for building...
# Then, taking the results of that build and putting it into the real container.

# Here is the staging container.
FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Now, we build out the runtime image.
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .
RUN dir
ENTRYPOINT ["dotnet", "mercurynorth_netcore.dll"]