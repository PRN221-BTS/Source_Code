using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;

namespace Repositories.HelperRepository
{
    public record FireBaseFile
    {
        public string URL { get; set; } = default!;
        public string FileName { get; set; } = default!;
    }
    public static class FireBaseUtility
    {
        // Vulnurable Data
        private static string API_KEY = "AIzaSyD1q_xUeRm6hLCBMWrP9ho9nncmxqo8o68";
        private static string Bucket = "https://console.firebase.google.com/project/prn221-save-image/storage/prn221-save-image.appspot.com/files";
        private static string AuthEmail = "comsuonhocmon@example";
        private static string AuthPassword = "bunbohue";
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
    }
}