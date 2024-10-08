using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.OpenApi.Models;
using prjNorthwindCustomer.DAO;
using prjNorthwindCustomer.Helper;
using prjNorthwindCustomer.Interface;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Northwind");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Northwind API",
        Version = "v1",
        Description = "API for managing Northwind customers"
    });
});

// 註冊 CustomersDAO 服務
builder.Services.AddScoped<CustomersDAO>(provider => new CustomersDAO(connectionString));
builder.Services.AddScoped<OrdersDAO>(provider => new OrdersDAO(connectionString));

// 註冊 CustomersHelper 服務
builder.Services.AddScoped<ICustomersHelper, CustomersHelper>();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind API V1");
        c.RoutePrefix = string.Empty; // 可選：將 Swagger UI 設置為根路徑
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
