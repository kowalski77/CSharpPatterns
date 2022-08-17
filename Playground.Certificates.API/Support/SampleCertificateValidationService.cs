using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Playground.Certificates.API.Support;

public class SampleCertificateValidationService : ICertificateValidationService
{
    public bool ValidateCertificate(X509Certificate2 clientCertificate)
    {
        // Don't hardcode passwords in production code.
        // Use a certificate thumbprint or Azure Key Vault.
        var expectedCertificate = CreateCertificate();

        return clientCertificate.Thumbprint == expectedCertificate.Thumbprint;
    }

    private static X509Certificate2 CreateCertificate()
    {
        var assembly = typeof(SampleCertificateValidationService).GetTypeInfo().Assembly;

        using var stream = assembly.GetManifestResourceStream("playground.pfx");
        if (stream is not null)
        {
            return new X509Certificate2(ReadStream(stream), "1234");
        }
        
        throw new InvalidOperationException("Could not retrieve the certificate from assembly");
    }

    private static byte[] ReadStream(Stream input)
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
}
