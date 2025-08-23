using EventManagement.AutoMapper;
using EventManagement.Data;
using EventManagement.Helpers;
using EventManagement.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System.Text;
using EventManagement.Interface.Repository;
using EventManagement.Interface.services;
using EventManagement.Repository;
using EventManagement.services;
using EventManagement.Interfaces;
using EventManagement.DTOs;
using EventManagement.Models.BookingModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbPath")));

// Dependency injection
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IBookingRequest, BookingRequestRepository>();
builder.Services.AddScoped<IBookingServicesInterface, BookingServices>();
builder.Services.AddScoped<IPaymentRepository , PaymentRepository>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IEventCategoryRepository, EventCategoryRepository>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IVendorServicesRepository, VendorServicesRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// JWT configuration
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// AutoMapper
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EventManagement API",
        Version = "v1",
        Description = "API documentation for EventManagement"
    });

    // Add JWT support to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventManagement API v1");
        c.RoutePrefix = string.Empty; // Swagger at root
    });
}


app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowAll");

app.UseAuthentication(); // Important: Add before Authorization
app.UseAuthorization();

app.MapControllers();

app.Run();
