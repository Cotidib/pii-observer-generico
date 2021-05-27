namespace Observer
{
    public interface IObserver <T>
    {
        void Update(T value);
    }
}