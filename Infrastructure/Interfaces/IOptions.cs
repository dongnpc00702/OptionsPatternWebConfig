namespace ExampleInject.Infrastructure.Interfaces
{
    public interface IOptions<out T>
    {
        T Value { get; }
    }
}