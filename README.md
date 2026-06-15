# .NET OData People Client

A .NET 5 console application that queries the public TripPin OData service, maps JSON responses into typed C# models, and presents an interactive people browser.

## Console workflow

The application offers three operations:

1. List people from the TripPin `People` collection.
2. Filter people by exact first name with an OData `$filter` query.
3. Retrieve one person by username and display detailed address and feature data.

```text
Console selection
      |
      v
PeopleBLL builds OData request
      |
      v
shared HttpClient requests JSON
      |
      v
People / Person / Location models
      |
      v
formatted console output
```

## Example requests

```http
GET https://services.odata.org/TripPinRESTierService/People
```

```http
GET https://services.odata.org/TripPinRESTierService/People?$filter=FirstName eq 'Russell'
```

```http
GET https://services.odata.org/TripPinRESTierService/People('russellwhyte')
```

The collection response is mapped from the OData `value` array into `People.Value`; individual responses map directly into `Person`.

## Project structure

```text
Api/ApiHelper.cs       # Shared JSON HttpClient initialization
BLL/PeopleBLL.cs       # OData queries and menu validation
Models/                # Person, collection, city, and location contracts
View/PeopleView.cs     # Console prompts and formatted output
Program.cs             # Application entry point
```

## Run locally

```bash
git clone https://github.com/alirazawatoo/dotnet-webapi-json-client.git
cd dotnet-webapi-json-client
dotnet restore
dotnet run --project dotnet-test-project.csproj
```

The tracked target is `.NET 5`, which is out of support. A compatible SDK/runtime or a deliberate target-framework update is required to run it on a current environment.

## Current boundaries

- The TripPin service is external and its availability and sample data can change.
- Filter input is interpolated directly into an OData expression and is not escaped.
- The shared `HttpClient` has no explicit timeout or cancellation flow.
- Errors are reduced to console messages rather than typed results.
- Generated `obj` artifacts are committed alongside source.
- No automated test project is tracked.

## Next improvements

1. Upgrade to a supported .NET target.
2. Escape or encode OData filter values and construct queries safely.
3. Add cancellation, timeouts, and structured failure messages.
4. Add unit tests with a mocked HTTP handler for all three operations.
