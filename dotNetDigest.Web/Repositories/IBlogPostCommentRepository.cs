﻿using dotNetDigest.Web.Models.Domain;

namespace dotNetDigest.Web.Repositories
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);
        Task<IEnumerable<BlogPostComment>> GetAllAsync(Guid blogPostId);
    }
}
