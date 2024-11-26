using LoyaltyService.Domain;
using LoyaltyService.Settings;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using Container = Microsoft.Azure.Cosmos.Container;

namespace LoyaltyService.Infrastructure;

public class CosmosDb() : IFamilyRepository
{
    private readonly Container _familiyContainer;
    private const string CustomerId = "CUS12345";

    public CosmosDb(IOptions<CosmosDbSettings> cosmosDbSettings) : this()
    {
        var settings = cosmosDbSettings.Value;
        var cosmosClient = new CosmosClient(settings.Account, settings.Key);
        var database = cosmosClient.GetDatabase(settings.DatabaseName);
        _familiyContainer = database.GetContainer(settings.FamiliesContainerName);
    }
    
    public async Task<Family> GetFamily(string id)
    {
        try
        {
            // Partition-Key is used to group documents together across containers
            // DocumentId must be unique for all
            ItemResponse<Family> response = await _familiyContainer.ReadItemAsync<Family>(id, new PartitionKey(CustomerId));
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }
}
