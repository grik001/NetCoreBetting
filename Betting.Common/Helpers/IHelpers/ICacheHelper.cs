namespace Betting.Common.Helpers.IHelpers
{
    public interface ICacheHelper
    {
        T GetData<T>(string key);
        void SetData<T>(string key, T data);
    }
}