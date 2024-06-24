namespace Shared.Exceptions
{
    public class NoProfilePictureException : Exception
    {
        // use when client wants to delete profile picture but they don't have one
        public NoProfilePictureException(string message) : base(message)
        {
        }
    }
}
