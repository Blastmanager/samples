### Pre-configured HttpClient to the BlastManager API using the host builder

This sample demonstrates how to use the [BmClient](../../src/BmClient.cs) to interact with the BlastManager API.

Setting up HttpClient in [Program.cs](Program.cs) with base uri and authorization header.
```csharp
// Bind the HttpClient to BmClient class in the DI container
builder.Services.AddHttpClient<BmClient>(client =>
{
    client.BaseAddress = new Uri("baseAddress");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
    $"{builder.Configuration["BM:Username"]}:{builder.Configuration["BM:Password"]}");
});
// Or setup a named client that can be created anywhere from the IHttpClientFactory 
builder.Services.AddHttpClient("BlastManagerClient", client =>
{
    client.BaseAddress = new Uri("baseAddress");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
    $"{builder.Configuration["BM:Username"]}:{builder.Configuration["BM:Password"]}");
});
```

Retrieving the client from the DI container
```csharp
public class BmClient
{
    private readonly HttpClient _httpClient;
    
    public BmClient(IHttpClientFactory httpClient) 
    {
        // Retrieve the configured HttpClient 
        
        // Retrieve bind client to BmClient
        _httpClient = httpClient.CreateClient();
        
        // Retrieve a named client
        _httpClient = httpClient.CreateClient("BlastManagerClient");
    }
}