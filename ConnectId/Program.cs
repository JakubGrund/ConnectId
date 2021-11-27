using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ConnectId
{
    public static class Program
    {
        static void Main(string[] args) 

        {
            // KID Key Azure
            const string kidKeyAzure = "bW8ZcMjBCnJZS-ibX5UQDNStvx4"; 

            // n => modulus from AD.Key Azure
            string modulus = "2a70SwgqIh8U-Shj_VJJGBheEVk2F4ygmMCRtKUAb1jMP6R1j5Mc5xaqhgzlWjckJI1lx4rha1oNLrdg8tJBxdm8V8xZohCOanJ52uAwoc6FFTY3VRLaUZSJ3zCXfuJwy4KvFHJUAuLhLj0hVeq-y10CmRJ1_MPTuNRJLdblSWcXyWYIikIRggQWS04M-QjR7571mX-Lu_eDs8xJVrnNFMVGRmFqf3EFD4QLNjW9JJj0m_prnTv41V_E8AA7MQZ12ip3u5aeOAQqGjVyzdHxvV9laxta6XWaM8QSTIu_Zav1-aDYExp99nCP4Hw0_Oom5vK5N88DB8VM0mouQi8a8Q";

            // e => exponent for RSA from AD.Key Azure
            string exponent = "AQAB";

            //JWT Token Id.Token.Azure
            string azureIdTokenJWT = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6ImJXOFpjTWpCQ25KWlMtaWJYNVVRRE5TdHZ4NCJ9.eyJ2ZXIiOiIyLjAiLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vOTE4ODA0MGQtNmM2Ny00YzViLWIxMTItMzZhMzA0YjY2ZGFkL3YyLjAiLCJzdWIiOiJBQUFBQUFBQUFBQUFBQUFBQUFBQUFJMXFSeDVHclNpV005ckR6VVUyajFBIiwiYXVkIjoiZDliYWQxMTQtYTU2Yi00Y2ZlLWE0NGQtZGE1MDA1MzQ2NzkyIiwiZXhwIjoxNjM3ODM0MDQ1LCJpYXQiOjE2Mzc3NDczNDUsIm5iZiI6MTYzNzc0NzM0NSwidGlkIjoiOTE4ODA0MGQtNmM2Ny00YzViLWIxMTItMzZhMzA0YjY2ZGFkIiwibm9uY2UiOiJhenVyZSIsImFpbyI6IkRaTGVtT3lKWkE0NlhveE9jd0dSUDRNc1hoanBrcHFOYW9NbGp6NFdLenlPTTRLbjBpMVh6SjFUdyFjOTRYV09YKkoxZ1NkZ3FweEdIQmJVVU9oeXJ0SUV5bVpGM29NenA4cEU1QmZwTEN5UVlGQ043ZjQwNFhuc040aipQMEo3RGlGV2puMERGQ3RCcGpkdmZpYnE0MU9pOCpXcGdrY1oqaVl5cWp0bFZnclpzdVJUQlBXNkRCU1FZZzNoIW8xQkVnJCQifQ.ps0I7Aa1cuEcG0HC_B5LGTrMCLNgxjGRDkmKa1wC10EKdkfCwbo0eCafIrmcrw_DwvQaU0M0uvZPRzOJKYfOl7Jl2U_6fdkF2d2akSJixrR4J7g3bDpt5KssseqMiGepZeG5UNPWK6bKUL-AkVYW433eIwazgaNrmFu2KGohEuQOeddW2zUYhr6vVrGMREffld7EsRNx6LxyPo6-SJ8FJyJqO9KThq_AB4d8KWKjAdpyX9GGYATCQVWLi9fwl2UU3cpldXInogQbkRvFJgLXl2K9ePg__WlSrIXf1oIuxqipLAQjNuSVCYRFXYqPeeyfTwjWhksknBO3BfIwyUNvsw";



            string[] partsJWT = azureIdTokenJWT.Split(".".ToCharArray()); // split JWT token - three parts

            var headerJWT = partsJWT[0]; // header from JWT token
            var payloadJWT = partsJWT[1]; // payload from JWT token
            var signatureJWT = partsJWT[2]; // signature from Jwt token Base64URLEncoded

            

            byte[] bytesToSign = GetBytes(string.Join(".", headerJWT, payloadJWT));  // output JSON UTF8

            byte[] secret = GetBytes("secret");  // output JSON UTF8


            
        }

        private static byte[] GetBytes(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        public static RSAParameters SetPublicKey(string modulus, string exponent)
        {
            RSAParameters result = new RSAParameters();
            result.Modulus = Base64UrlDecode(modulus);
            result.Exponent = Base64UrlDecode(exponent);

            return result;
        }

        static byte[] Base64UrlDecode(string input)
        {
            string output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding
            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0: break; // No pad chars in this case
                case 2: output += "=="; break; // Two pad chars
                case 3: output += "="; break; // One pad char
                default:
                    throw new System.Exception(
             "String is illegal!");
            }
            return Convert.FromBase64String(output); // Standard base64 decoder
        }

    }  
}
