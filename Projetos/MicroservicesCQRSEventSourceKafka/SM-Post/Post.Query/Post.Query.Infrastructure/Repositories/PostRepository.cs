using Microsoft.EntityFrameworkCore;
using Post.Query.Domain.Entities;
using Post.Query.Domain.Repositories;
using Post.Query.Infrastructure.DataAccess;

namespace Post.Query.Infrastructure.Repositories
{
  public class PostRepository : IPostRepository
  {
    private readonly DatabaseContextFactory _contextFactory;

    public PostRepository(DatabaseContextFactory contextFactory)
    {
      _contextFactory = contextFactory;
    }

    public async Task CreateAsync(PostEntity post)
    {
      using var context = _contextFactory.CreateDbContext();
      context.Posts.Add(post);
      await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid postId)
    {
      using var context = _contextFactory.CreateDbContext();
      var post = await GetByIdAsync(postId);

      if (post == null) return;
      context.Posts.Remove(post);
      await context.SaveChangesAsync();
    }

    public async Task<PostEntity> GetByIdAsync(Guid postId)
    {
      using var context = _contextFactory.CreateDbContext();
      return await context
        .Posts
        .Include(_ => _.Comments)
        .FirstOrDefaultAsync(_ => _.PostId == postId);
    }

    public async Task<List<PostEntity>> ListAllAsync()
    {
      using var context = _contextFactory.CreateDbContext();
      return await context
        .Posts
        .Include(_ => _.Comments)
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<List<PostEntity>> ListByAuthorAsync(string author)
    {
      using var context = _contextFactory.CreateDbContext();
      return await context
        .Posts
        .Include(_ => _.Comments)
        .Where(_ => _.Author.Contains(author))
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<List<PostEntity>> ListWithCommentsAsync()
    {
      using var context = _contextFactory.CreateDbContext();
      return await context
        .Posts
        .Include(_ => _.Comments)
        .Where(_ => _.Comments != null && _.Comments.Count > 0)
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<List<PostEntity>> ListWithLikesAsync(int numberOfLikes)
    {
      using var context = _contextFactory.CreateDbContext();
      return await context
        .Posts
        .Include(_ => _.Comments)
        .Where(_ => _.Likes >= numberOfLikes)
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task UpdateAsync(PostEntity post)
    {
      using var context = _contextFactory.CreateDbContext();
      context.Posts.Update(post);

      await context.SaveChangesAsync();
    }
  }
}