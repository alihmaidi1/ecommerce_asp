using Common;
using ecommerce.admin;
using ecommerce.Dto;
using ecommerce.infrutructure;
using ecommerce.infrutructure.seed;
using ecommerce.infrutructure.Services.Classes;
using ecommerce.infrutructure.Services.Interfaces;
using ecommerce.service;
using ecommerce.user;
using ecommerce_shared.Jwt;
using ecommerce_shared.Middleware;
using ecommerce_shared.Repository.Concrete;
using ecommerce_shared.Repository.interfaces;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Serilog;
using System.Configuration;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "en", "ar" };
    options.SetDefaultCulture(supportedCultures[1])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);

});

// builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{

    //options.JsonSerializerOptions.NumberHandling=JsonNumberHandling.AllowReadingFromString| JsonNumberHandling.WriteAsString;


}).AddNewtonsoftJson(options =>
{
    
    options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore;

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();



builder.Services.AddLocalization(options => options.ResourcesPath = "");
builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("AccessToken"));

builder.Services.AddHttpClient("Region",c=> {


    c.BaseAddress = new Uri("https://countriesnow.space");
   
    });

builder.Services.AddTransient<ExternalRegionApi>();

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
builder.Services.AddUserdependency();

builder.Services.AddCommondependency();
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

builder.Services.AddJwtConfigration(builder.Configuration);



builder.Services.AddTransient<IJwtRepository, JwtRepository>();
builder.Services.AddScoped<ICacheRepository,CacheRepository>();



builder.Services.AddTransient<ErrorHandling>();



var app = builder.Build();


app.ConfigureOpenAPI();




app.UseRequestLocalization(new RequestLocalizationOptions
{
    ApplyCurrentCultureToResponseHeaders = true
});


// app.UseSerilogRequestLogging();
app.UseCors("Policy");


app.UseMiddleware<ErrorHandling>();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{

    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto


}); ;

using(var scope= app.Services.CreateScope()){
    
    
    await DatabaseSeed.InitializeAsync(scope.ServiceProvider);


}


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();