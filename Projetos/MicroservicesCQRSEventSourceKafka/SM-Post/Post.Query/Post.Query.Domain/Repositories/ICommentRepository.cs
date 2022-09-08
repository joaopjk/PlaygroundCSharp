using Post.Query.Domain.Entities;

namespace Post.Query.Domain.Repositories
{
  public interface ICommentRepository
  {
    Task CreateAsync(CommentEntity commet);
    Task UpdateAsync(CommentEntity comment);
    Task<CommentEntity> GetByIdAsync(Guid commentId);
    Task DeleteAsync(Guid commentId);
  }
}