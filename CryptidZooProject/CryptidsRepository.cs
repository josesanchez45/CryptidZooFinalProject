using CryptidZooProject.Models;
using System.Data;
using Dapper;

namespace CryptidZooProject
{
    public class CryptidsRepository : ICryptidsRepository
    {
        private readonly IDbConnection _conn;
        public CryptidsRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Cryptids> GetAllCryptids()
        {
            return _conn.Query<Cryptids>("SELECT * FROM cryptid;");
        }
    }
}
