namespace Servire.Services.Dal.Interfaces
{
    public interface IAdapter<T> where T : class
    {
        T Get(object[] values);
    }
}