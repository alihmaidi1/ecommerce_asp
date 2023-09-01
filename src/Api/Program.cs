using Common;
using ecommerce.admin;
using ecommerce.Controllers.Common;
using ecommerce.Domain.Attribute;
using ecommerce.infrutructure;
using ecommerce.infrutructure.seed;
using ecommerce.infrutructure.Services.Classes;
using ecommerce.infrutructure.Services.Interfaces;
using ecommerce.service;
using ecommerce.user;
using ecommerce_shared.Authorization.Handlers;
using ecommerce_shared.Authorization.Providers;
using ecommerce_shared.File;
using ecommerce_shared.Jwt;
using ecommerce_shared.Middleware;
using ecommerce_shared.Redis;
using ecommerce_shared.Services.Email;
using ecommerce_shared.Swagger;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using Repositories;
using Repositories.Jwt;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(option =>
{

}).AddJsonOptions(options =>
{

    //options.JsonSerializerOptions.NumberHandling=JsonNumberHandling.AllowReadingFromString| JsonNumberHandling.WriteAsString;


}).AddNewtonsoftJson(options =>
{

    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

});


builder.Services.Configure<MailSetting>(builder.Configuration.GetSection("EmailConfiguration"));

builder.Services.AddMediatR(configuration =>
{

    configuration.RegisterServicesFromAssembly(ecommerce.user.AssemblyReference.Assembly);

});


builder.Services.Configure<DataProtectionTokenProviderOptions>(option => option.TokenLifespan = TimeSpan.FromMinutes(10));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


builder.Services.AddValidatorsFromAssembly(ecommerce.user.AssemblyReference.Assembly);
builder.Services.AddAutoMapper(ecommerce.user.AssemblyReference.Assembly);


builder.Services.AddValidatorsFromAssembly(ecommerce.admin.AssemblyReference.Assembly);
builder.Services.AddMediatR(configuration =>
{

    configuration.RegisterServicesFromAssembly(ecommerce.admin.AssemblyReference.Assembly);
});


builder.Services.AddAutoMapper(ecommerce.admin.AssemblyReference.Assembly);



//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    var supportedCultures = new[] { "en", "ar" };
//    options.SetDefaultCulture(supportedCultures[1])
//        .AddSupportedCultures(supportedCultures)
//        .AddSupportedUICultures(supportedCultures);

//});

// builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();



builder.Services.AddLocalization(options => options.ResourcesPath = "");
builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("AccessToken"));

builder.Services.AddHttpClient("Region",c=> {c.BaseAddress = new Uri("https://countriesnow.space");});

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
builder.Services.AddS3Configration();
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
builder.Services.AddScoped<IAuthorizationHandler,RolesAuthorizationHandler>();
builder.Services.AddTransient<IAuthorizationPolicyProvider,PermissionProvider>();
builder.Services.AddTransient<IAuthorizationHandler,PermissionAuthorizationHandler>();

builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddTransient<CheckTokenInRedisAttribute>();


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


