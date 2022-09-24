using CryptidZooProject.Models;

namespace CryptidZooProject
{
    public interface ICommentsRepository
    {
        public IEnumerable<Comments> GetComments();
        public Comments GetComment(int id);

        public void UpdateComment(Comments comm);
     
      
    }
}
