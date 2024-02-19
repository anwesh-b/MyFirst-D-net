using MyFirst.Database;
using MyFirst.Model;

namespace MyFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // builder.Services.AddDbContext<BaseDbModel>();
            builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoDB"));
            // Add services to the container.
            builder.Services.AddSingleton<MongoSettings>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseExceptionHandler("/Error");

            app.MapControllers();

            app.Run();
        }
    }

}
