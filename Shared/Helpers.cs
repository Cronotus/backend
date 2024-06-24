namespace Shared
{
    public static class Helpers
    {
        public static string ExtractFileNameFromProfilePictureUri(string profilePictureUri)
        {
            return profilePictureUri.Split("/").Last();
        }
    }
}
