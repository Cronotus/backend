namespace Service.Contracts
{
    public interface IServiceManager
    {
        IProfileService ProfileService { get; }
        IEventService EventService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
