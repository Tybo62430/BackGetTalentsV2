using BackGetTalentsV2.Business.Address;
using BackGetTalentsV2.Business.Category;
using BackGetTalentsV2.Business.Convers;
using BackGetTalentsV2.Business.Message;
using BackGetTalentsV2.Business.Picture;
using BackGetTalentsV2.Business.Review;
using BackGetTalentsV2.Business.Skill;
using BackGetTalentsV2.Business.User;
using BackGetTalentsV2.Business.UserHasConversation;
using BackGetTalentsV2.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackGetTalentsV2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISkillService, SkillService>();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();

            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewService, ReviewService>();

            services.AddScoped<IPictureRepository, PictureRepository>();
            services.AddScoped<IPictureService, PictureService>();

            services.AddScoped<IUserHasConversationRepository, UserHasConversationRepository>();
            services.AddScoped<IUserHasConversationService, UserHasConversationService>();

            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddScoped<IConversationService, ConversationService>();

            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageService>();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackGetTalentsV2", Version = "v1" });
            });

            // Replace with your connection string.
            /*var connectionString = "server=localhost;Port=3306;user=root;password=E93d9aa753;database=gettalents";*/
            //var connectionString = "server=localhost;Port=3306;user=root;password=;database=gettalents";
            var connectionString = "server=localhost;Port=3630;user=root;password=root;database=gettalents";
            //var connectionString = "server=localhost;Port=3306;user=root;password=root;database=gettalents";

            // Replace with your server version and type.
            // Use 'MariaDbServerVersion' for MariaDB.
            // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
            // For common usages, see pull request #1233.
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));

            // Replace 'YourDbContext' with the name of your own DbContext derived class.
            services.AddDbContext<gettalentsContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion,b => b.MigrationsAssembly("BackGetTalentsV2"))
                    .EnableSensitiveDataLogging() // <-- These two calls are optional but help
                    .EnableDetailedErrors()       // <-- with debugging (remove for production).
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackGetTalentsV2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
