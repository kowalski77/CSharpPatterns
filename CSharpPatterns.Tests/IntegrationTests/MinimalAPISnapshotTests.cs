using System.Net.Http.Json;
using Playground.Minimal.API;

namespace CSharpPatterns.Tests.IntegrationTests;

[UsesVerify]
public class MinimalAPISnapshotTests : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient httpClient;

    public MinimalAPISnapshotTests(TestWebApplicationFactory factory)
    {
        this.httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task Rename()
    {
        // Act
        var response = await this.httpClient.GetAsync($"/todos");

        // Assert
        var result = await response.Content.ReadFromJsonAsync<List<TodoItem>>();
        await Verify(new
        {
            response,
            result
        });
    }
}