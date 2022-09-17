using System.Security.Cryptography;
using System.Text;

namespace MyEcommerceAuthorize.CrossCutting.Utils;

public static class SecurityUtils
{
    public static string HashSHA1(string plainText) => GetSHA1HashData(plainText);

    private static string GetSHA1HashData(string data)
    {
        SHA1CryptoServiceProvider SHA1 = new();
        var byteV = Encoding.UTF8.GetBytes(data);
        var byteH = SHA1.ComputeHash(byteV);

        SHA1.Clear();

        return Convert.ToBase64String(byteH);
    }
}