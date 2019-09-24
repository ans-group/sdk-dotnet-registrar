# sdk-dotnet-registrar

This is the official .NET SDK for UKFast Domains

You should refer to the [Getting Started](https://developers.ukfast.io/getting-started) section of the API documentation before proceeding below

## Basic usage

To get started, we'll first instantiate an instance of `IUKFastRegistrarClient`:

```csharp
IUKFastRegistrarClient client = new UKFastRegistrarClient(new ClientConnection("myapikey"));
```

Next, we'll obtain an instance of IDomainOperations to perform operations on domains:

```csharp
var domainOps = client.DomainOperations();
```

Finally, we'll retrieve all domains using the instance of `IDomainOperations`:

```csharp
IList<Domain> domains = await domainOps.GetDomainsAsync();
```

## Operations

All operations available via the SDK are exposed via the client (`IUKFastRegistrarClient`)
