# UserLedgerSimulation

[![.NET](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/) [![PostgreSQL](https://img.shields.io/badge/PostgreSQL-15-blue)](https://www.postgresql.org/) [![Docker](https://img.shields.io/badge/Docker%20Compose-3.x-blue)](https://docs.docker.com/compose/)

A containerized ASP.NET Core 8 Web API that simulates a basic casino ledger system.  
Supports user registration, multi-currency balance tracking, and a complete ledger of every transaction.  
Built with PostgreSQL database, automated EF Core migrations, optional pgAdmin interface, and Swagger UI.

---

## Architecture

This application uses Docker Compose to orchestrate multiple services:

- **webapp**: .NET 8.0 web application (main service)  
- **migration**: EF Core migration service (runs pending migrations on startup)  
- **db**: PostgreSQL 15 (Alpine) database  
- **pgadmin**: Optional pgAdmin interface for database administration  

---
## Key Models

### Balance

```csharp
public class Balance : BaseEntity
{
    /// <summary>
    /// Stored as the smallest currency unit (e.g. cents for USD, tetri for GEL).
    /// </summary>
    public int Amount { get; set; } = 0;
    public Currency Currency { get; set; } = Currency.GEL;

    public Guid UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; } = null!;

    public ICollection<LedgerEntry>? LedgerEntries { get; set; }
}
```

### LedgerEntry

```csharp
public class LedgerEntry : BaseEntity
{
    /// <summary>
    /// Stored as the smallest currency unit (e.g. cents for USD, tetri for GEL).
    /// </summary>
    public int Amount { get; set; }
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    public TransactionDescription TransactionDescription { get; set; }

    public Guid BalanceId { get; set; }
    public Balance Balance { get; set; } = null!;

    public Guid? GameId { get; set; }
    public Game? Game { get; set; }
}
```
## Example Game Play Flow

1. **User logs in** and receives JWT token
2. **Checks balance**: `GET /api/Balances/USD` → Returns current USD balance
3. **If insufficient funds**: `POST /api/Balances/add` → Adds $100 USD
4. **Browses games**: `GET /api/games` → Gets list of available games
5. **Plays game**: `POST /api/games/play` with gameId, amount: 10, currency: "USD"
6. **System processes**: Deducts $10, runs game, adds winnings if any
7. **User checks updated balance**: `GET /api/Balances/USD`

## Supported Currencies
- **GEL** (Georgian Lari)
- **USD** (US Dollar) 
- **EUR** (Euro)
---
## Prerequisites

- Docker and Docker Compose installed
- .NET 8.0 SDK (for local development)
- Git

## Quick Start

### 1. Environment Setup

Copy the example environment file and customize it:

```bash
cp .env.example .env
```

Edit the `.env` file with your preferred settings:

```bash
# Required: Change the database password
DB_PASSWORD=your_secure_password_here

# Optional: Customize ports and other settings
APP_PORT=5010
APP_HTTPS_PORT=5011
PGADMIN_EMAIL=your-email@example.com
PGADMIN_PASSWORD=your_admin_password
```

### 2. Start the Application

```bash
# Build and start all services
docker-compose up --build

# Or run in background
docker-compose up --build -d
```

### 3. Access the Application

- **Web Application**: 
  - HTTP: http://localhost:5010
  - HTTPS: https://localhost:5011
- **API Documentation (Swagger)**: https://localhost:5011/swagger/index.html
- **pgAdmin** (optional): http://localhost:8080
- **PostgreSQL Database**: localhost:5432



## Environment Variables

### Application Settings

| Variable | Default | Description |
|----------|---------|-------------|
| `APP_NAME` | `dotnet-app` | Application and container name prefix |
| `APP_PORT` | `5010` | HTTP port for the web application |
| `APP_HTTPS_PORT` | `5011` | HTTPS port for the web application |
| `ASPNETCORE_ENVIRONMENT` | `Development` | ASP.NET Core environment |

### Database Settings

| Variable | Default | Description |
|----------|---------|-------------|
| `DB_HOST` | `db` | Database hostname (use service name for Docker) |
| `DB_NAME` | `myappdb` | PostgreSQL database name |
| `DB_USER` | `postgres` | PostgreSQL username |
| `DB_PASSWORD` | `your_secure_password_here` | PostgreSQL password (**CHANGE THIS**) |
| `DB_PORT` | `5432` | PostgreSQL port |
| `DB_CONTAINER_NAME` | `postgres-db` | PostgreSQL container name |
| `POSTGRES_VERSION` | `15-alpine` | PostgreSQL Docker image version |

### pgAdmin Settings (Optional)

| Variable | Default | Description |
|----------|---------|-------------|
| `PGADMIN_EMAIL` | `admin@example.com` | pgAdmin login email |
| `PGADMIN_PASSWORD` | `admin_password_here` | pgAdmin login password |
| `PGADMIN_PORT` | `8080` | pgAdmin web interface port |
| `PGADMIN_CONTAINER_NAME` | `pgadmin` | pgAdmin container name |

### Migration Settings

| Variable | Default | Description |
|----------|---------|-------------|
| `RUN_MIGRATIONS` | `true` | Whether to run database migrations on startup |

## Services Details

### Migration Service

The migration service automatically runs Entity Framework Core migrations when the application starts. It:

- Waits for the database to be healthy
- Runs all pending migrations
- Exits after successful completion
- Blocks the web application from starting until migrations are complete

### Web Application

The main .NET 8.0 web application:

- Runs on ports 5010 (HTTP) and 5011 (HTTPS)
- Includes development SSL certificate
- Connects to PostgreSQL database
- Starts only after successful migrations

### Database

PostgreSQL 15 Alpine with:

- Health checks to ensure readiness
- Persistent data storage via Docker volumes

### pgAdmin (Optional)

Web-based PostgreSQL administration:

- Access at http://localhost:8080
- Login with credentials from environment variables
- Need to supply new Server and use db .env variables for access



## File Structure

```
├── docker-compose.yml          # Docker Compose configuration
├── .env                       # Environment variables (create from .env.example)
├── .env.example              # Environment variables template
├── LambdaTask/
│   ├── Dockerfile            # Main application Dockerfile
│   └── Dockerfile.migration  # Migration service Dockerfile
└── README.md                # This file
```

## Troubleshooting

### Database Connection Issues

1. Ensure PostgreSQL container is healthy:
   ```bash
   docker-compose ps
   ```

2. Check database logs:
   ```bash
   docker-compose logs db
   ```

3. Verify connection string in application logs:
   ```bash
   docker-compose logs webapp
   ```

### Migration Issues

1. Check migration service logs:
   ```bash
   docker-compose logs migration
   ```

2. Manually run migrations:
   ```bash
   docker-compose run --rm migration
   ```

### Port Conflicts

If default ports are in use, update the `.env` file:

```bash
APP_PORT=5020
APP_HTTPS_PORT=5021
DB_PORT=5433
PGADMIN_PORT=8081
```