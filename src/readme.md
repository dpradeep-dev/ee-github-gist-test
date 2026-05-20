# GitHub Gists API

Simple ASP.NET Core API that returns publicly available GitHub gists for a given user.

---

## Prerequisites

- .NET SDK 10.0 or later
- Docker (optional)

Verify installation:

```bash
dotnet --version
docker --version
```

---

## Project Structure

```text
equal-experts-sedate-orderly-sensational-miracle-4e948fcfa4aa/
│
├── src/
│   ├── api/
│   └── tests/
│
├── Dockerfile
└── README.md
```

---

## Run the API Locally

From the project root:

```bash
dotnet restore
dotnet build
dotnet run --project src/Api
```

The API will start on:

```text
http://localhost:5182
```

Example using curl:

```bash
curl http://localhost:5000/octocat
```

---

## Run Automated Tests

From the project root:

```bash
dotnet test
```

The test validates that the API successfully returns public gists for the GitHub user `octocat`.

---

## Build and Run with Docker

### Build Docker Image

```bash
docker build -t github-gists-api .
```

### Run Container

```bash
docker run -p 8080:8080 github-gists-api
```

The API will be available at:

```text
http://localhost:8080/octocat
```

---

## API Endpoint

### Get Public Gists

```http
GET /{username}
```

Example:

```http
GET /octocat
```

Response:

```json
[
  {
    "id": "123456",
    "description": "Example gist",
    "html_url": "https://gist.github.com/..."
  }
]
```

---

## Design Notes

- Built using ASP.NET Core Minimal API
- Uses GitHub public REST API
- Uses `HttpClientFactory` for HTTP calls
- Includes automated test
- Dockerized for easy execution
