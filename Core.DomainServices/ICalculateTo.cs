namespace Core.DomainServices
{
    public interface ICalculateTo
    {
        double Calculate<T>(T obj);
    }
}