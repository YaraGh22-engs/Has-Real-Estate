namespace Has_Real_Estate.Repo.IRepo
{
    public interface ICommentRepo
    {
        int Add(Comment comment);
        Comment GetById(int commentId);
        int RemoveComment(int id);
    }
}
