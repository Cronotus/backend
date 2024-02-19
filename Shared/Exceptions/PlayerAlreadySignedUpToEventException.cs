
namespace Shared.Exceptions
{
    public class PlayerAlreadySignedUpToEventException : Exception
    {
        public PlayerAlreadySignedUpToEventException(string message) : base(message)
        {
        }
    }
}
