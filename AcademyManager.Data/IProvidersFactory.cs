

namespace AcademyManager.Data
{
    public interface IProvidersFactory
    {
        bool TryGet<T>(out T provider) where T : class, IRepository<T>;
    }
}
