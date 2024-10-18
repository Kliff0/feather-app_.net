// Program.cs
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Add MVC controller support
builder.Services.AddHttpClient();  // Register HttpClient
builder.Services.AddSingleton<RiotApiService>(); // Register service class

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.MapControllers(); // Map controller routes

app.Run();