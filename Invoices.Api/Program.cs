

using Invoices.Api;
using Invoices.Api.Interfaces;
using Invoices.Api.Managers;
using Invoices.Data;
using Invoices.Data.Interfaces;
using Invoices.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LocalInvoicesConnection");

builder.Services.AddDbContext<InvoicesDbContext>(options =>
    options.UseSqlServer(connectionString)
        .UseLazyLoadingProxies()
        .ConfigureWarnings(x => x.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning)));

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    options.SwaggerDoc("invoices", new OpenApiInfo
    {
        Version = "v1",
        Title = "Invoices"
    }));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

builder.Services.AddScoped<IPersonManager, PersonManager>();
builder.Services.AddScoped<IInvoiceManager, InvoiceManager>();
builder.Services.AddAutoMapper(typeof(AutomapperConfigurationProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("invoices/swagger.json", "Invoices - v1");
    });
}

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
