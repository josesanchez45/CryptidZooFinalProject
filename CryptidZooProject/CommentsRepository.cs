using CryptidZooProject.Models;
using System.Data;
using Dapper;

namespace CryptidZooProject
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly IDbConnection _conn;
        public CommentsRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        
        public IEnumerable<Comments> GetComments()
        {
            return _conn.Query<Comments>("SELECT * FROM commentsection;");
        }
        public Comments GetComment(int id)
        {
            return _conn.QuerySingle<Comments>("SELECT * FROM commentsection WHERE CommentId = @id", new { id = id });
        }
        public void UpdateComment(Comments comm)
        {
            _conn.Execute("UPDATE commentsection SET DisplayName = @name, Comment = @comment WHERE Cryptid = @cryptid",
             new { name = comm.DisplayName, comment = comm.Comment, cryptid = comm.Cryptid });
        }
        public void InsertComment(Comments commentToInsert)
        {
            _conn.Execute("INSERT INTO commentsection (NAME, Comment, commentID) VALUES (@name, @price, @CommentID);",
                new { name = commentToInsert.DisplayName, comment = commentToInsert.Comment, commentID = commentToInsert.CommentId });
        }

        public IEnumerable<CommentIds> GetAllCommentIds()
        {
            return _conn.Query<CommentIds>("SELECT * FROM commenttag;");
        }

        public Comments AssignCommentID()
        {
            var commentIdList = GetAllCommentIds();
            var comment = new Comments();
           comment.CommentIds = commentIdList;
            return comment; 
        }
    }
}
