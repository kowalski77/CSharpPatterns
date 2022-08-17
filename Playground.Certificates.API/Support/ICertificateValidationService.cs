using System.Security.Cryptography.X509Certificates;

namespace Playground.Certificates.API.Support;
public interface ICertificateValidationService
{
    bool ValidateCertificate(X509Certificate2 clientCertificate);
}