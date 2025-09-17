using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Core.Validators;
using eCommerce.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddCore();
builder.Services.AddInfrastructure();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Registrar AutoMapper con tu perfil
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

builder.Services.AddAuthentication();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder => {
            builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
        });
});

var app = builder.Build();

// Exception handling
app.UseExceptionHandlingMiddleware();
// Routing
app.UseRouting();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();
// Middlewares
app.UseAuthentication();
app.UseAuthorization();

// Endpoints
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
