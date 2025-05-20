using Investors.BL.Interfaces;
using Investors.BL.Services;
using Investors.Data.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var corsPolicy = "CorsPolicy";

builder.Services.AddCors(options => 
{
    options.AddPolicy(name: corsPolicy, policy =>
    {
        policy.WithOrigins(builder.Configuration.GetValue<string>("ClientHost"));          
            
    });
});

// Add services to the container.
builder.Services.AddDbContext<InvestorContext>(
    x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddScoped<IInvestorService, InvestorService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
