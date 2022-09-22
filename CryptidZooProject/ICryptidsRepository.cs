using CryptidZooProject.Models;

namespace CryptidZooProject
{
    public interface ICryptidsRepository
    {
        public IEnumerable<Cryptids> GetAllCryptids();

    }
}
