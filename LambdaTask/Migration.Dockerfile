# Use the official .NET 8.0 SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Install EF Core tools
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Copy solution file if it exists
COPY *.sln ./

# Copy all project files
COPY Domain/*.csproj ./Domain/
COPY Application/*.csproj ./Application/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY LambdaTask/*.csproj ./LambdaTask/

# Restore dependencies
RUN dotnet restore LambdaTask/LambdaTask.csproj

# Copy everything else
COPY Domain/ ./Domain/
COPY Application/ ./Application/
COPY Infrastructure/ ./Infrastructure/
COPY LambdaTask/ ./LambdaTask/

# Build the solution to ensure all assemblies exist
RUN dotnet build LambdaTask/LambdaTask.csproj --configuration Debug --no-restore

# Create migration script
RUN echo '#!/bin/bash\n\
echo "Starting database migration..."\n\
\n\
# Wait for database to be ready and apply migrations\n\
max_attempts=30\n\
attempt=1\n\
\n\
while [ $attempt -le $max_attempts ]; do\n\
    echo "Migration attempt $attempt/$max_attempts..."\n\
    \n\
    if dotnet ef database update --startup-project /src/LambdaTask --project /src/Infrastructure --verbose; then\n\
        echo "Database migration completed successfully!"\n\
        echo "All migrations applied, including seed data."\n\
        exit 0\n\
    else\n\
        echo "Migration failed, retrying in 10 seconds..."\n\
        sleep 10\n\
        attempt=$((attempt + 1))\n\
    fi\n\
done\n\
\n\
echo "Migration failed after $max_attempts attempts"\n\
exit 1' > /src/migrate.sh

RUN chmod +x /src/migrate.sh

# Set working directory back to src for migration
WORKDIR /src

# Set the entry point to run migrations
ENTRYPOINT ["/bin/bash", "/src/migrate.sh"]