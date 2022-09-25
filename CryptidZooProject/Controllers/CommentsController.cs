using CryptidZooProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptidZooProject.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsRepository repo;

        public CommentsController(ICommentsRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var comments = repo.GetComments();
            return View(comments);
        }
        public IActionResult ViewComment(int id)
        {
            var comment = repo.GetComment(id);
            return View(comment);
        }
        public IActionResult UpdatecComment(int id)
        {
            Comments comm = repo.GetComment(id);
            if (comm == null)
            {
                return View("CommentNotFound");
            }
            return View(comm);
        }
        public IActionResult UpdateCommentToDatabase(Comments comm)
        {
            repo.UpdateComment(comm);

            return RedirectToAction("ViewComment", new { id = comm.CommentId });
        }
        public IActionResult InsertProduct()
        {
            var comm = repo.AssignCommentID();
            return View(comm);
        }
        public IActionResult InsertCommentToDatabase(Comments commentToInsert)
        {
            repo.InsertComment(commentToInsert);
            return RedirectToAction("Index");
        }

    }
}
