using System.Reflection;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Press a key to start...");
Console.ReadKey();

var assembly = Assembly.GetExecutingAssembly();

using var stream = assembly.GetManifestResourceStream("Playground.Certificates.Client.Cert.localtest.pfx");
if(stream is null)
{
    throw new InvalidOperationException("Certificate not loaded");
}

var cert = new X509Certificate2(ReadStream(stream), "pa55w0rd!");

var handler = new HttpClientHandler();
handler.ClientCertificates.Add(cert);

var client = new HttpClient(handler);

var request = new HttpRequestMessage
{
    RequestUri = new Uri("https://localhost:7017/WeatherForecast"),
    Method = HttpMethod.Get
};

var response = await client.SendAsync(request);
response.EnsureSuccessStatusCode();

var content = await response.Content.ReadAsStringAsync();
Console.WriteLine(content);


static byte[] ReadStream(Stream input)
{
    var buffer = new byte[16 * 1024];
    using var ms = new MemoryStream();
    int read;
    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
    {
        ms.Write(buffer, 0, read);
    }

    return ms.ToArray();
}


