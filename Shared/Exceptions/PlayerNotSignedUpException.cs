namespace Shared.Exceptions
{
    public class PlayerNotSignedUpException : Exception
    {
        public PlayerNotSignedUpException(string message) : base(message)
        {
        }
    }
}
