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
            _conn.Execute("UPDATE commentsection SET DisplayName = @name, Comment = @comment WHERE CommentId = @id",
             new { name = comm.DisplayName, comment = comm.Comment, id = comm.CommentId });
        }
        public void InsertComment(Comments commentToInsert)
        {
            _conn.Execute("INSERT INTO commentsection (DisplayName, Comment, CommentID) VALUES (@Name, @Comment, @CommentID);",
                new { Name = commentToInsert.DisplayName, Comment = commentToInsert.Comment, CommentID = commentToInsert.CommentId });
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
        public void DeleteComment(Comments comment)
        {
            _conn.Execute("DELETE FROM commentsection WHERE CommentId = @id;", new { id = comment.CommentId });
            _conn.Execute("DELETE FROM commentsection WHERE DisplayName = @name;", new { name = comment.DisplayName});
            _conn.Execute("DELETE FROM commentsection WHERE Comment = @comm;", new { comm = comment.Comment});
        }
    }
}
