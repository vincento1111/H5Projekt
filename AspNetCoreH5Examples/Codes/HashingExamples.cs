using System.Security.Cryptography;
using System.Text;

namespace AspNetCoreH5Examples.Codes;

public class HashingExamples : IHashingExamples
{
    public string MD5Hash(string valueToHash)
    {
        byte[] valueAsBytes = ASCIIEncoding.ASCII.GetBytes(valueToHash);
        byte[] hasedMD5 = MD5.HashData(valueAsBytes);
        string hashedValueAsString = Convert.ToBase64String(hasedMD5);
        return hashedValueAsString;
    }

    public string BcryptHash(string valueToHash)
    {
        string hashed = BCrypt.Net.BCrypt.HashPassword(valueToHash, BCrypt.Net.SaltRevision.Revision2Y);
        return hashed;
    }
}

