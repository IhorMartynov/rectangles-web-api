using System.Reflection;
using Rectangles.Application;
using Rectangles.Db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(RectanglesApplicationServicesExtensions).Assembly);
});

builder.Services
    .AddRectangleApplicationServices()
    .AddDatabaseServices(builder.Configuration["ConnectionStrings:RectanglesDb"]!);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler("/error");

app.UseAuthorization();

app.MapControllers();

app.Run();
