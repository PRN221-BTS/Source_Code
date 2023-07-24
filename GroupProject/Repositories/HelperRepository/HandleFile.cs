using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Repositories.HelperRepository
{
    public record FireBaseFile
    {
        public string URL { get; set; } = default!;
        public string FileName { get; set; } = default!;
    }
    public static class HandleFile
    {
        private static FirebaseStorage _storage;
        // Vulnurable Data
        private static string API_KEY = "AIzaSyD1q_xUeRm6hLCBMWrP9ho9nncmxqo8o68";
        private static string Bucket = "prn221-save-image.appspot.com";
        private static string AuthEmail = "mandayngu@gmail.com";
        private static string AuthPassword = "0902388458Tr";
        public static async Task<FireBaseFile> UploadFileAsync(this IFormFile fileUpload)
        {
            if (fileUpload.Length > 0)
            {
                var fs = fileUpload.OpenReadStream();
                var auth = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
                var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
                var cancellation = new FirebaseStorage(
                    Bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true

                    }
                    ).Child("assets").Child(fileUpload.FileName)
                    .PutAsync(fs, CancellationToken.None);
                try
                {
                    var result = await cancellation;

                    return new FireBaseFile
                    {
                        FileName = fileUpload.FileName,
                        URL = result
                    };
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }

            }
            else throw new Exception("File is not existed!");
        }

        public static async Task<bool> RemoveFileAsync(this string fileName)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
            var loginInfo = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
            var storage = new FirebaseStorage(Bucket, new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(loginInfo.FirebaseToken),
                ThrowOnCancel = true
            });
            await storage.Child("assets").Child(fileName).DeleteAsync();
            return true;

        }

        public static async Task DownLoadFileFromFirebaseStorage()
        {

            //var storage = new FirebaseStorage(Bucket);
            //   string filePath = "361647231_749351753860449_7378132952161517896_n.jpg";

            //   storage.Child("assets").Child(filePath);
            //   string localFilePath = "C:\\Users\\VO MINH MAN\\Downloads";
            // var firebaseStorageReference = storage.Child("assets").Child(filePath);
            //       FileStream fileStream = new FileStream(localFilePath, FileMode.Create);
            //     await storage.Child(filePath).GetDownloadUrlAsync();
            //   fileStream.Close();
            //string downloadURL =  await firebaseStorageReference.GetDownloadUrlAsync();
            // using (var httpClient = new HttpClient())
            // {
            //     var fileBytes = await httpClient.GetByteArrayAsync(downloadURL);
            //     // Process the downloaded file bytes as needed
            // }
            //
            var storage = new FirebaseStorage(Bucket);
            var storageRef = storage.Child("assets").Child("361647231_749351753860449_7378132952161517896_n.jpg");

            string rootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Downloads");
            Directory.CreateDirectory(rootPath);

            string localFilePath = Path.Combine(rootPath, "imageName.txt");

            using (var stream = File.OpenWrite(localFilePath))
            {
           //     await storageRef.StreamDownloadAsync(stream);
                await storageRef.GetDownloadUrlAsync();
            }

        }
    }
}