namespace DesignPatterns.Proxy.CachedRepository
{
	public abstract class Repository<T>
    {
        public abstract T GetById(int id);
    }
}