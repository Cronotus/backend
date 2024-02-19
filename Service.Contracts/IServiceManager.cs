namespace Service.Contracts
{
    public interface IServiceManager
    {
        IProfileService ProfileService { get; }
        IEventService EventService { get; }
        IAuthenticationService AuthenticationService { get; }
        IOrganizerService OrganizerService { get; }
        ISportService SportService { get; }
        IPlayerService PlayerService { get; }
        IPlayerOnEventService PlayerOnEventService { get; }
    }
}
