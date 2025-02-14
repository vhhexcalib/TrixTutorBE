using DataAccess.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository.Interfaces;
using Repository.Repositories;
using Service.DTOs.TokenDTO;
using Service.Interfaces;
using Service.Mappings;
using Service.Services;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TrixTutorAPI.Helper;

var builder = WebApplication.CreateBuilder(args);
// Get JSON from Environment Variable
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var connectionString = config["ConnectionStrings:AzureStorage"];
if (string.IsNullOrEmpty(connectionString))
{
    throw new ArgumentNullException(nameof(connectionString), "AzureStorage connection string is missing.");
}

// Test if can take variable
var email = builder.Configuration["EMAIL_CONFIGURATION:EMAIL"];
var azureConnection = builder.Configuration["AzureBlobStorage:ConnectionString"];
connectionString = builder.Configuration.GetConnectionString("MyDb");
builder.Services.AddTrixTutorDBContext(connectionString);
// log console to test
Console.WriteLine($"Email: {email}");
Console.WriteLine($"Azure Connection: {azureConnection}");
Console.WriteLine($"DB Connection: {connectionString}");


builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "TrixTutorAPI", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] { }
        }
    });
    option.DocumentFilter<CustomDocumentFilter>();
    option.SchemaFilter<SimpleEnumSchemaFilter>();
    option.OperationFilter<SwaggerFileOperationFilter>();
});

// Add services to the container.
//Add cors
builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// Add Authentication
var jwtSettings = builder.Configuration.GetSection("JwtConfig");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
// JWT 
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));
var secretKey = builder.Configuration["AppSettings:SecretKey"];
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //tu cap Token
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
        ClockSkew = TimeSpan.Zero
    };
});
//Authorize
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("1"));
    options.AddPolicy("StaffOnly", policy => policy.RequireRole("2"));
    options.AddPolicy("StudentOnly", policy => policy.RequireRole("3"));
    options.AddPolicy("LecturerOnly", policy => policy.RequireRole("4"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("3", "4"));
    options.AddPolicy("SystemAccountOnly", policy => policy.RequireRole("1", "2"));

});
//DI
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
});

builder.Services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);                  //automapper
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServicesConfiguration(builder.Configuration);
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddHostedService<ConfirmationOTPBackgroundService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
