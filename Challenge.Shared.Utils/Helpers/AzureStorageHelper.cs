namespace Challenge.Shared.Utils.Helpers
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Newtonsoft.Json;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public static class AzureStorageHelper
    {
        #region Blob storage

        public async static Task<T> DownloadBlob<T>(string storageConnectionString, string containerName, string blobName)
        {
            var container = InitializeBlobContainer(storageConnectionString, containerName);
            await container.CreateIfNotExistsAsync().ConfigureAwait(false);

            var blockBlob = container.GetBlockBlobReference(blobName);
            using (var memoryStream = new MemoryStream())
            {
                var text = await blockBlob.DownloadTextAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(text);
            }
        }

        public static async Task UploadPAIToBlob(string storageConnectionString, string containerName, string blobName, string jsonContent, string paiCache)
        {
            var container = InitializeBlobContainer(storageConnectionString, containerName);
            await container.CreateIfNotExistsAsync().ConfigureAwait(false);

            var blockBlob = container.GetBlockBlobReference(blobName);
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonContent)))
            {
                await blockBlob.UploadFromStreamAsync(stream).ConfigureAwait(false);
            }
        }

        private static CloudBlobContainer InitializeBlobContainer(string storageConnectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            return container;
        }

        #endregion
    }
}
