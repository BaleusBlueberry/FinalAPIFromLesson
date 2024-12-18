using System.Text;
using DAL.Data;
using DAL.Models;
using FinalAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FinalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<DALContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DALContext") ?? throw new InvalidOperationException("Connection string 'DALContext' not found.")));

            builder.Services.AddScoped<ProductsRepository>();
            builder.Services.AddScoped<CategoryRepository>();

            //add identity services to the di: (enables us to inject UserManager, RoleManager)
            builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options => {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<DALContext>();

            //get jwtSettings from the appsettings json file:
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))

                };
            });

            //JWT {Claims}

            // builder.Services.AddScoped<IRepository<Product>, ProductsRepository>();  
            builder.Services.AddScoped<ProductsRepository>();
            builder.Services.AddScoped<CategoryRepository>();

            //add our Service to the di container
            builder.Services.AddScoped<JwtService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var corsPolicy = "CorsPolicy";

            /*var host = builder.Configuration.GetValue<string>("AllowedHosts") ?? throw new Exception("no valid string at AllowedHosts");*/

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: corsPolicy, policy =>
                {
                    policy.WithOrigins([
                            "http://localhost:3000",
                            "http://localhost:5173",
                            "http://localhost:5174",
                            "https://testwebsite.pleasecuddle.me",
                            /*host*/
                        ])
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            var app = builder.Build();

            app.UseCors(corsPolicy);

            // run code once
            using (var scope = app.Services.CreateAsyncScope())
            {
                try
                {
                    // exec the migration once when the app loads (if there are any new migrations)
                    var context = scope.ServiceProvider.GetRequiredService<DALContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Error Executing migration: " + ex.Message);

                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
