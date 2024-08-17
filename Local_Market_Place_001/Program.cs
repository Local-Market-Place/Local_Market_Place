using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Local_Market_Place_001.Data;

namespace Local_Market_Place_001
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Local_Market_Place_001Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Revision_001Context") ?? throw new InvalidOperationException("Connection string 'Local_Market_Place_001Context' not found.")));


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder => builder
                        .WithOrigins("http://localhost:3000")  // React app URL
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);
     
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

           
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowReactApp");

            app.MapControllers();

            app.Run();
        }
    }
}
