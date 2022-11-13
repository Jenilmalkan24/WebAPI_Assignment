using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Model.DBModels;
using System.Reflection;

// Scaffold-DbContext "Server=BRD-3917L13-L\\SQLEXPRESS;Database=Organization;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DBModels -f
//Scaffold-DbContext "Server=BLR-7W5GL13-L\SQLEXPRESS;Database=Organization;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DBModels

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrganizationContext>(options =>
  options.UseSqlServer("Server=BLR-7W5GL13-L\\SQLEXPRESS;Database=Organization;Trusted_Connection=True;"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Employee Details API",
        Version = "v1",
        Description = "An API to perform CRUD operations over Employee Details",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Jenil Malkan",
            Url = new Uri("https://twitter.com/jeni_vis"),
        },
        License = new OpenApiLicense
        {
            Name = "Employee API LICX",
            Url = new Uri("https://example.com/license"),
        }
    });
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();