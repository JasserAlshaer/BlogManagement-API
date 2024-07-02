using BlogManagement_Core.Context;
using BlogManagement_Core.IRepos;
using BlogManagement_Core.IService;
using BlogManagement_Infra.Repos;
using BlogManagement_Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogsDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("Local")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepos, UserRepos>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // To serve files 
// Add custom static files middleware
var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imagesDirectory),
    RequestPath = "/Images"
});


app.UseAuthorization();

app.MapControllers();

app.Run();
