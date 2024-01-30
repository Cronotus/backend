namespace Contracts
{
    public interface IRepositoryManager
    {
        IProfileRepository Profile { get; }
        IEventRepository Event { get; }
        void Save();
        Task SaveAsync();
    }
}
