using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

Console.WriteLine("Press key to start...");
Console.ReadKey();

const string privateKey = "private-rsa-key.key";

using var privateKeyRsa = RSA.Create();
privateKeyRsa!.ImportFromPem(File.ReadAllText(privateKey));

SecurityKey key = new RsaSecurityKey(privateKeyRsa);

Claim[] claims = new[]
{
    new Claim("AppId", "12345"),
    new Claim("roles", "Admin")
};

JwtSecurityToken securityToken = new(
    "cert-auth.com",
    "JwtBearerCertAuth.API",
    claims,
    expires: DateTime.Now.AddMinutes(10),
    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.RsaSha256));

var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

Console.WriteLine(token);

using HttpClient client = new();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

var response = await client.GetAsync(new Uri("https://localhost:7132/WeatherForecast")).ConfigureAwait(false);
response.EnsureSuccessStatusCode();

var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
Console.WriteLine(content);
Console.ReadKey();