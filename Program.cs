// <copyright file="Program.cs" owner="maiorsi">
// Licenced under the MIT Licence.
// </copyright>

using System.Xml;

using CiscoIpPhoneLdapDirectory.Settings;

using DirectoryServices.Settings;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OpenApi.Models;

using Serilog;

using var log = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Configure

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("text/xml"));
    options.OutputFormatters.Add(new XmlSerializerOutputFormatter(new XmlWriterSettings
    {
        OmitXmlDeclaration = false
    }));
});

builder.Services.Configure<DirectorySettings>(builder.Configuration.GetSection("DirectorySettings"));
builder.Services.Configure<LdapSettings>(builder.Configuration.GetSection("Settings"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1.0", new OpenApiInfo
    {
        Title = "Cisco IP Phone LDAP Directory API",
        Description = "XML API",
        Contact = new OpenApiContact { Name = "maiorsi", Email = "36492124+maiorsi@users.noreply.github.com" },
        License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://choosealicence.com/licences/mit/") },
        Version = "v1.0.0"
    });
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