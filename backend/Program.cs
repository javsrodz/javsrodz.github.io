using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

//Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin() //Permitir cualquier Origen
        .AllowAnyHeader() //Permitir cualquier encabezado
        .AllowAnyMethod(); //Permitir cualquier metodo http
    });
});

//configuracion de JWT
builder.Configuration.AddJsonFile("appsettings.json");
var llavesecreta = builder.Configuration.GetSection("JWTConfig").GetSection("secretkey").ToString();
var KeyBytes = Encoding.UTF8.GetBytes(llavesecreta);


builder.Services.AddAuthentication(config =>
{
config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
config.RequireHttpsMetadata = false;
config.SaveToken = true;
config.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(KeyBytes),
    ValidateIssuer = false,
    ValidateAudience = false,
    ClockSkew = TimeSpan.Zero
};
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseCors("NuevaPolitica");


app.UseAuthorization();

app.MapControllers();

app.Run();
