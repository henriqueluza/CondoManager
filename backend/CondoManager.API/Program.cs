using System.Text;
using CondoManager.Infrastructure.Data;
using CondoManager.Infrastructure.Repositories;
using CondoManager.Domain.Interfaces;
using CondoManager.Application.UseCases.Condominiums;
using CondoManager.Application.UseCases.Members;
using CondoManager.Application.UseCases.Employees;
using CondoManager.Application.UseCases.Visitors;
using CondoManager.Application.UseCases.AccessLogs;
using CondoManager.Application.UseCases.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Banco de dados
builder.Services.AddDbContext<CondoManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositórios
builder.Services.AddScoped<ICondominiumRepository, CondominiumRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
builder.Services.AddScoped<IAccessLogRepository, AccessLogRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Use Cases — Condominiums
builder.Services.AddScoped<CreateCondominiumUseCase>();
builder.Services.AddScoped<GetCondominiumUseCase>();
builder.Services.AddScoped<GetAllCondominiumsUseCase>();
builder.Services.AddScoped<UpdateCondominiumUseCase>();
builder.Services.AddScoped<DeleteCondominiumUseCase>();

// Use Cases — Members
builder.Services.AddScoped<CreateResidentUseCase>();
builder.Services.AddScoped<CreateSyndicUseCase>();
builder.Services.AddScoped<GetMemberUseCase>();
builder.Services.AddScoped<GetAllMembersUseCase>();
builder.Services.AddScoped<UpdateResidentUseCase>();
builder.Services.AddScoped<UpdateSyndicUseCase>();
builder.Services.AddScoped<DeleteMemberUseCase>();

// Use Cases — Employees
builder.Services.AddScoped<CreateEmployeeUseCase>();
builder.Services.AddScoped<GetEmployeeUseCase>();
builder.Services.AddScoped<GetAllEmployeesUseCase>();
builder.Services.AddScoped<UpdateEmployeeUseCase>();
builder.Services.AddScoped<DeleteEmployeeUseCase>();

// Use Cases — Visitors
builder.Services.AddScoped<CreateVisitorUseCase>();
builder.Services.AddScoped<GetAllVisitorsUseCase>();

// Use Cases — AccessLogs
builder.Services.AddScoped<CreateAccessLogUseCase>();
builder.Services.AddScoped<GetAccessLogUseCase>();
builder.Services.AddScoped<GetAllAccessLogsUseCase>();
builder.Services.AddScoped<UpdateAccessLogCheckoutUseCase>();

// Use Cases — Users
builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<LoginUserUseCase>();
builder.Services.AddScoped<GetUserUseCase>();

// JWT
var secretKey = builder.Configuration["JwtSettings:SecretKey"];
var key = Encoding.UTF8.GetBytes(secretKey!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
    };
    
    // Lê o token do cookie HttpOnly
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["jwt"];
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); 
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();