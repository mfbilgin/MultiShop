using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Discount.Context;
using MultiShop.Discount.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtBearerOptions =>
{
    jwtBearerOptions.Authority = builder.Configuration["IdentityServerUrl"];
    jwtBearerOptions.Audience = "ResourceDiscount";
    jwtBearerOptions.RequireHttpsMetadata = false;
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<ICouponService,CouponManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
