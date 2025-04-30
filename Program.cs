using Microsoft.EntityFrameworkCore;
using Dreamsauda.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Add DbContext (connect to SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add OpenAPI/Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add controllers
builder.Services.AddControllers();

// Enable CORS for React app (localhost:3000)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React's local server URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS middleware to allow cross-origin requests
app.UseCors();

app.UseAuthorization();

// Map API Controllers (add endpoints)
app.MapControllers();

// Run the application
app.Run();
