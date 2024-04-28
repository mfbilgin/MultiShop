using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MultiShop.Catalog.Services.Category;
using MultiShop.Catalog.Services.Product;
using MultiShop.Catalog.Services.ProductDetail;
using MultiShop.Catalog.Services.ProductImage;
using MultiShop.Catalog.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtBearerOptions =>
{
    jwtBearerOptions.Authority = builder.Configuration["IdentityServerUrl"];
    jwtBearerOptions.Audience = "ResourceCatalog";
    jwtBearerOptions.RequireHttpsMetadata = false;
});

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDetailService, ProductDetailManager>();
builder.Services.AddScoped<IProductImageService, ProductImageManager>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(provider =>
    provider.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();