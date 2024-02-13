
namespace Shared.Exceptions
{
    public class PlayerAlreadyExistsException : Exception
    {
        public PlayerAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
