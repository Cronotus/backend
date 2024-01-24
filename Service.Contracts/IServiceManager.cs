namespace Service.Contracts
{
    public interface IServiceManager
    {
        IProfileService ProfileService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
