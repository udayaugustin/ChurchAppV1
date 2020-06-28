using SQLite;

namespace HRApp
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

