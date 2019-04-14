#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

# We will use this handy Linux image here for our base image. 
FROM mcr.microsoft.com/dotnet/core/sdk:2.2.203 AS base
WORKDIR /app


# Lets do a restore of the NuGet packages, and then build the app in a container.
COPY mercurynorth_netcore.csproj ./
RUN dotnet restore "mercurynorth_netcore.csproj"
COPY . .
RUN dotnet build "mercurynorth_netcore.csproj" -c Release -o /app

# Now publish the resulting app.
FROM build AS publish
RUN dotnet publish "mercurynorth_netcore.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "mercurynorth_netcore.dll"]