namespace Shared.Exceptions
{
    public class NoProfileCoverPictureException : Exception
    {
        // use when client wants to delete profile cover picture but they don't have one
        public NoProfileCoverPictureException(string message) : base(message)
        {
        }
    }
}
