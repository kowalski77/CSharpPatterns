extern alias TargetApi;

using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using ProgramAPI = TargetApi::Program;

namespace DataRetrieval.Client;

public class FindBenchmark
{
    private const string url = "https://localhost:7206/people/{0}/bb664af4-0957-4cd6-9279-0030da7e3fb3";

    private static HttpClient httpClient = default!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var factory = new WebApplicationFactory<ProgramAPI>()
            .WithWebHostBuilder(configuration =>
            {
                configuration.ConfigureLogging(builder => builder.ClearProviders());
            });

        httpClient = factory.CreateClient();
    }

    [Benchmark(Baseline = true)]
    public async Task GetResponseTimeV1()
    {
        var response = await httpClient.GetAsync(string.Format(url, "v1"));
    }

    [Benchmark]
    public async Task GetResponseTimeV2()
    {
        var response = await httpClient.GetAsync(string.Format(url, "v2"));
    }
}
