using EmployeeManager.API.Middleware;
using EmployeeManager.Infrastructure;
namespace EmployeeManager.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy",
                    builder =>
                    {
                        builder.AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowCredentials().WithOrigins("http://localhost:4200");
                    });
            });


            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();
            builder.Services.infrastructureConfiguration(builder.Configuration);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CORSPolicy");
            app.UseMiddleware<ExceptionsMiddleware>();
            app.UseStaticFiles();
            app.UseStatusCodePagesWithReExecute("/errors/{0}"); 
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
