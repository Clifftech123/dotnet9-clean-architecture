using Microsoft.EntityFrameworkCore;
using Todo.Application.Mapping;
using Todo.Application.Queries.Categorys;
using Todo.Infrastructure.Context;
using Todo.Infrastructure.Interface;
using Todo.Infrastructure.Repositories;
using TodoAPI.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddProblemDetails();




// Connecting our local SQL Server

builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
          b => b.MigrationsAssembly("Todo.Infrastructure"));
});


builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);


builder.Services.AddMediatR(m => m.RegisterServicesFromAssemblyContaining(typeof(GetAllTodoCategoriesQuery)));

var app = builder.Build();

app.UseExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
