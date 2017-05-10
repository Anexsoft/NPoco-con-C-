using NPoco;

namespace Persistence
{
    public class DbContext
    {
        public static Database GetInstance()
        {
            return new Database("NPocoExample");
        }
    }
}
