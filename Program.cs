using Microsoft.EntityFrameworkCore;
using crud.DbContext;
using crud.Mapping;
using crud.Models;
using crud.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// for AppDbContext
builder.Services.AddDbContext<AppDbContext>(Options =>
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddTransient<Category>();
builder.Services.AddScoped<IComestibleService, ComestibleService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();
app.UseEndpoints(Endpoint =>
{
    Endpoint.MapControllers();
});
app.Run();