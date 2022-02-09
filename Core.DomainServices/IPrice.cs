using Core.Domain.Behaviour;
namespace Core.DomainServices
{
    public interface IPrice
    {
        double Calculate<T>(Calculable<T> entity);
    }
}