# Use the official .NET 8.0 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file if it exists
COPY *.sln ./

# Copy all project files
COPY Domain/*.csproj ./Domain/
COPY Application/*.csproj ./Application/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY LambdaTask/*.csproj ./LambdaTask/

# Restore dependencies
RUN dotnet restore LambdaTask/LambdaTask.csproj

# Copy everything else and build
COPY Domain/ ./Domain/
COPY Application/ ./Application/
COPY Infrastructure/ ./Infrastructure/
COPY LambdaTask/ ./LambdaTask/

# Build and publish
WORKDIR /src/LambdaTask
RUN dotnet publish -c Release -o /app/publish

# Generate HTTPS certificate during build stage (where SDK is available)
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https -ep /app/publish/aspnetapp.pfx -p development_password_123 --trust

# Use the official .NET 8.0 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Install curl for health checks (optional)
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

# Copy the published app (including the certificate)
COPY --from=build /app/publish .

# Create a non-root user but keep cert accessible
RUN adduser --disabled-password --gecos '' appuser && \
    chown -R appuser /app && \
    chmod 644 /app/aspnetapp.pfx

USER appuser

# Expose both HTTP and HTTPS ports
EXPOSE 80
EXPOSE 443

# Set environment variables for HTTPS
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=development_password_123
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/aspnetapp.pfx

# Set the entry point
ENTRYPOINT ["dotnet", "LambdaTask.dll"]