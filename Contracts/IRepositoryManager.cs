namespace Contracts
{
    public interface IRepositoryManager
    {
        IProfileRepository Profile { get; }
        IEventRepository Event { get; }
        IOrganizerRepository Organizer { get; }
        ISportRepositry Sport { get; }
        IPlayerRepository Player { get; }
        void Save();
        Task SaveAsync();
    }
}
