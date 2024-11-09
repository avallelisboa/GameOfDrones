var builder = WebApplication.CreateBuilder(args);

//Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
       builder => builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
});

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
