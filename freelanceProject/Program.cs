using freelanceProject.DTO;
using freelanceProject.Model;
using freelanceProject.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

namespace freelanceProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string ConnectionStrings = builder.Configuration.GetConnectionString("CS");
            // Add services to the container.
            builder.Services.AddDbContext<EntityContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(ConnectionStrings);
            });

            builder.Services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRepository<Blog>, BlogRepository>();
            builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IHomeInfoRepository, HomeInfoRepository>();
            builder.Services.AddScoped<IRepository<Partner>, PartnerRepository>();
            builder.Services.AddScoped<IRepository<User>, UserRepository>();

            builder.Services.AddScoped<IAuthRepository, AuthRepository>();

            builder.Services.AddIdentity<User, IdentityRole>(options => options.Password.RequireDigit = true)
                .AddEntityFrameworkStores<EntityContext>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                 .AddJwtBearer(o =>
                 {
                     o.RequireHttpsMetadata = false;
                     o.SaveToken = false;
                     o.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidIssuer = builder.Configuration["JWT:Issuer"],
                         ValidAudience = builder.Configuration["JWT:Audience"],
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                     };
                 });


            builder.Services.AddCors(corsOptions => {
                corsOptions.AddPolicy("MyPolicy", policyBuilder =>
                {
                    policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}