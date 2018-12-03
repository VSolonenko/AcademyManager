using System.Collections.Generic;
using System.Linq;


namespace AcademyManager.Data.LocalFileData
{
    class ProvidersFactory : IProvidersFactory
    {
        private readonly IEnumerable<object> _providers;
        public ProvidersFactory(ILoginInfoesProvider loginInfoesProvider, IUsersProvider usersProvider)
        {
            _providers = new List<IRepository<object>>() {
                (IRepository<object>)loginInfoesProvider,
                (IRepository<object>)usersProvider
            };
        
            
        }
        public bool TryGet<T>(out T provider) where T : class, IRepository<T>
        {
            foreach(var prov in _providers) {
                var type = prov.GetType();
                if (type.IsGenericType && type.GenericTypeArguments.Any(i => i.FullName == typeof(T).FullName)) 
                {
                    provider = (T)prov;
                    return true;
                }
            }
            provider = default(T);
            return false;
        }
    }
}
