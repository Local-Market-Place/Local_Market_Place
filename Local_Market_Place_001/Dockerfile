# Use the .NET SDK 8.0 image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Publish the application
RUN dotnet publish -c Release -o out

# Use the ASP.NET Core runtime 8.0 image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/out ./

# Expose the port your application will run on
EXPOSE 80

# Set the entry point for the container
ENTRYPOINT ["dotnet", "Local_Market_Place_001.dll"]
