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
            //JWT Token Id.Token.Azure

            string azureIdTokenJWT = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6ImJXOFpjTWpCQ25KWlMtaWJYNVVRRE5TdHZ4NCJ9.eyJ2ZXIiOiIyLjAiLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vOTE4ODA0MGQtNmM2Ny00YzViLWIxMTItMzZhMzA0YjY2ZGFkL3YyLjAiLCJzdWIiOiJBQUFBQUFBQUFBQUFBQUFBQUFBQUFJMXFSeDVHclNpV005ckR6VVUyajFBIiwiYXVkIjoiZDliYWQxMTQtYTU2Yi00Y2ZlLWE0NGQtZGE1MDA1MzQ2NzkyIiwiZXhwIjoxNjM3ODM0MDQ1LCJpYXQiOjE2Mzc3NDczNDUsIm5iZiI6MTYzNzc0NzM0NSwidGlkIjoiOTE4ODA0MGQtNmM2Ny00YzViLWIxMTItMzZhMzA0YjY2ZGFkIiwibm9uY2UiOiJhenVyZSIsImFpbyI6IkRaTGVtT3lKWkE0NlhveE9jd0dSUDRNc1hoanBrcHFOYW9NbGp6NFdLenlPTTRLbjBpMVh6SjFUdyFjOTRYV09YKkoxZ1NkZ3FweEdIQmJVVU9oeXJ0SUV5bVpGM29NenA4cEU1QmZwTEN5UVlGQ043ZjQwNFhuc040aipQMEo3RGlGV2puMERGQ3RCcGpkdmZpYnE0MU9pOCpXcGdrY1oqaVl5cWp0bFZnclpzdVJUQlBXNkRCU1FZZzNoIW8xQkVnJCQifQ.ps0I7Aa1cuEcG0HC_B5LGTrMCLNgxjGRDkmKa1wC10EKdkfCwbo0eCafIrmcrw_DwvQaU0M0uvZPRzOJKYfOl7Jl2U_6fdkF2d2akSJixrR4J7g3bDpt5KssseqMiGepZeG5UNPWK6bKUL-AkVYW433eIwazgaNrmFu2KGohEuQOeddW2zUYhr6vVrGMREffld7EsRNx6LxyPo6-SJ8FJyJqO9KThq_AB4d8KWKjAdpyX9GGYATCQVWLi9fwl2UU3cpldXInogQbkRvFJgLXl2K9ePg__WlSrIXf1oIuxqipLAQjNuSVCYRFXYqPeeyfTwjWhksknBO3BfIwyUNvsw";


            string[] partsJWT = azureIdTokenJWT.Split(".".ToCharArray()); // split method JWT token

            var headerJWT = partsJWT[0]; // header from JWT token
            var payloadJWT = partsJWT[1]; // payload from JWT token
            var signatureJWT = partsJWT[2]; // signature from Jwt token

            

            byte[] bytesToSign = getBytes(string.Join(".", headerJWT, payloadJWT));  // output JSON UTF8

            byte[] secret = getBytes("secret"); // output secret key

        }

        private static byte[] getBytes(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        private static string Base64UrlEncode(byte[] input)
        {
            var output = Convert.ToBase64String(input);
            output = output.Split('=')[0];
            output = output.Replace('+', '-');
            output = output.Replace('/', '_');
            return output;

        }

    }  
}
