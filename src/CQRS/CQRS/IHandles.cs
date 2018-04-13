namespace CQRS
{
    public interface IHandles<T>
    {
        void Handle(T message);
    }
}