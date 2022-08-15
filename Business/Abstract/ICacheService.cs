namespace Bussines.Abstract
{
    public interface ICacheService
    {
        void SetString(string key, string value);
        void SetList(string key, int[] arrayNumbers);
        string GetValue(string key);
    }
}
