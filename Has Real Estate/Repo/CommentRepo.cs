
using System;

namespace Has_Real_Estate.Repo
{
    public class CommentRepo : ICommentRepo
    {
        private readonly ApplicationDbContext _context;

        public CommentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Comment comment)
        {
            _context.Comments.Add(comment);
            return _context.SaveChanges();
        }

        public Comment GetById(int commentId)
        {
            var comment = _context.Comments.Include(x=>x.Estate)
                                            .SingleOrDefault(c => c.Id == commentId);
            if (comment == null)
            {
                return null;
            }
            return comment;
        }

        public int RemoveComment(int commentId)
        {
            var comment = GetById(commentId);
            if (comment == null)
            {
                return 0;
            }
            _context.Comments.Remove(comment);
            return _context.SaveChanges();
        }
    }
}
