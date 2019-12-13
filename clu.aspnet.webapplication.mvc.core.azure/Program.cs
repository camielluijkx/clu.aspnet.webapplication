using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace clu.aspnet.webapplication.mvc.core.azure
{
    class Program
    {
        private static async void testBlobStorage()
        {
            const string connectionString = "<REPLACE WITH YOUR CONNECTION STRING>";
               
            //Get a reference to Storage Account.         
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //Get a reference to a container and create the container if it does not exist.
            CloudBlobContainer container = blobClient.GetContainerReference("mydemocontainer");
            await container.CreateIfNotExistsAsync();

            //Get a reference to the blob. The blob gets created if it is not present.
            CloudBlockBlob blob = container.GetBlockBlobReference("hello.txt");

            await blob.UploadTextAsync("Hello World");
        }

        private static void testRedisCache()
        {
            ConfigurationOptions config = new ConfigurationOptions();

            //Replace CACHENAME with the DNS Name you provided while creating the cache.
            config.EndPoints.Add("<CACHENAME>.redis.cache.windows.net");
            config.Password = "<Redis cache key from management portal>";
           
            var cm = ConnectionMultiplexer.Connect(config);
            var db = cm.GetDatabase();

            // You now have a connection to the cache. You can now use this connection, to add data to the cache or // to retrieve it. Some examples are:
            db.StringSet("key", "value");
            var key = db.StringGet("key");
        }

        private static async Task<string> testGetToken(string authority, string resource, string scope)
        {
            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential("CLIENT_ID", "CLIENT_KEY");
            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);

            if (result == null)
                throw new InvalidOperationException("Failed to obtain the JWT token");

            return result.AccessToken;
        }

        private static async void testGetSecret()
        {
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(testGetToken));

            // Once the client is created, you can invoke any of the get methods to get the necessary keys / secrets.Sample code as follows:
            var sec = await kv.GetSecretAsync("<SECRET_IDENTIFIER>");
        }

        static void Main(string[] args)
        {
            testBlobStorage();
            testRedisCache();
            testGetSecret();
        }
    }
}