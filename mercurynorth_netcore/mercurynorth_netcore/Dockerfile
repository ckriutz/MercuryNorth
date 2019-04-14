#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

# We will use this handy Linux image here for our build image. 
FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine AS build
WORKDIR /app


# Lets do a restore of the NuGet packages, and then restore the app in a container.
COPY mercurynorth_netcore.csproj ./
RUN dotnet restore "mercurynorth_netcore.csproj"
COPY . .
RUN dotnet publish "mercurynorth_netcore.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .
ENTRYPOINT ["dotnet", "mercurynorth_netcore.dll"]