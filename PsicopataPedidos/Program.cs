using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PsicopataPedidos.Application;
using PsicopataPedidos.Application.OrderServices;
using PsicopataPedidos.Application.ProductCategoryServices;
using PsicopataPedidos.Infrastructure;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.EnableEndpointRouting = false;
}).AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "swaggerAADdemo", Version = "v1" });
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "OAuth2.0 Auth Code with PKCE",
        Name = "Authorization",
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri(builder.Configuration["AzureAdB2C:Instance"]),
                TokenUrl = new Uri(builder.Configuration["AzureAdB2C:TokenUrl"]),
                Scopes = new Dictionary<string, string>
                {
                    {builder.Configuration["AzureAdB2C:ApiScope"], "read" }
                }
            }
        },
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme, Id = "oauth2" }
            },
            new [] { builder.Configuration["AzureAdB2C:ClientId"] }
        }
    });

    //options.OperationFilter<SecurityRequirementsOperationFilter>();
});

    //options.OperationFilter<SecurityRequirementsOperationFilter>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration, "AzureAdB2C");




//Adds Microsoft Identity platform (Azure AD B2C) support to protect this Api
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//        .AddMicrosoftIdentityWebApi(options =>
//        {
//            builder.Configuration.Bind("AzureAdB2C", options);

//            options.TokenValidationParameters.NameClaimType = "name";
//        },
//options => { builder.Configuration.Bind("AzureAd", options); });


builder.Services.AddDbContext<ProductDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
b => b.MigrationsAssembly("PsicopataPedidos.API")));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShoppingListService, ShoppingListService>();
builder.Services.AddScoped<IShoppingListRepository, ShoppingListRepository>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddCors(x => x.AddPolicy("AllowAnyOrigin", x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        app.UseDeveloperExceptionPage();
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "swaggerAADdemo v1");
        c.OAuthClientId(builder.Configuration["AzureAdB2C:ClientId"]);
        c.OAuthUsePkce();
        c.OAuthScopeSeparator(" ");
    });
}
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
