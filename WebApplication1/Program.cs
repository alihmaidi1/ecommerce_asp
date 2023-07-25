using ecommerce.admin;
using ecommerce.Dto;
using ecommerce.infrutructure;
using ecommerce.service;
using ecommerce_shared.Middleware;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.RateLimiting;
using Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddTransient<ErrorHandling>();

builder.Services.AddRateLimiter(Limitrateoption =>
{

    Limitrateoption.AddFixedWindowLimiter("fixedwindow", option =>
    {

        option.PermitLimit = 2;
        option.Window=TimeSpan.FromSeconds(1);
        option.QueueLimit = 0;
    });


});


builder.Services.AddInfrustucture(builder.Configuration);
builder.Services.AddRepository();
builder.Services.AddServices();
builder.Services.AddAdmindependency();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy", policyBuilder =>
    {
        policyBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});





var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ConfigureOpenAPI();
}

app.UseSerilogRequestLogging();
app.UseCors("Policy");

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandling>();
app.Run();
