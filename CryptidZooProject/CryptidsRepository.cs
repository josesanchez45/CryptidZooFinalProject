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
        public Cryptids GetCryptid(int id)
        {
            return _conn.QuerySingle<Cryptids>("SELECT * FROM cryptid WHERE CreatureId = @id", new { id = id });
        }
    }
}
