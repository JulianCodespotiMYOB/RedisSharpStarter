using MyRedisApp.Models;

namespace MyRedisApp.Interfaces
{
    public interface IDatabaseService
    {
        bool Set(ValueModel model);
        string Get(string key);
        bool Delete(string key);
    }
}