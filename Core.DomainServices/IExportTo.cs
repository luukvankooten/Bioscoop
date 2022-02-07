namespace Core.DomainServices
{
    public interface IExportTo
    {
        bool Export<T>(T obj);
    }
}