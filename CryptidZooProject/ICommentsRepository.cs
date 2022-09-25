using CryptidZooProject.Models;

namespace CryptidZooProject
{
    public interface ICommentsRepository
    {
        public IEnumerable<Comments> GetComments();
        public Comments GetComment(int id);

        public void UpdateComment(Comments comm);
        public void InsertComment (Comments commentToInsert);
        public IEnumerable<CommentIds> GetAllCommentIds();
        public Comments AssignCommentID();
        
     
      
    }
}
