using Microsoft.AspNetCore.Cors.Infrastructure;
using PostAndComment.CoreLayer.Src.Repository;
using PostAndComment.CoreLayer.Src.Service;

namespace PostAndReaction
{
    public static class DiConfig
    {
        public static void DependencyInjection(this IServiceCollection services)
        {
            UseRepository(services);
            UserService(services);
        }
        private static void UseRepository(this IServiceCollection services)
        {
            services.AddScoped<UserRepositoryInterface, UserRepository>();
            services.AddScoped<PostRepositoryInterface, PostRepository>();
            services.AddScoped<CommentRepositoryInterface, CommentRepository>();


        }
        private static void UserService(this IServiceCollection services)
        {
            services.AddScoped<UserServiceInterface, UserService>();
            services.AddScoped<PostServiceInterface, PostService>();
            services.AddScoped<CommentServiceInterface, CommentService>();
           
        }
    }
}
