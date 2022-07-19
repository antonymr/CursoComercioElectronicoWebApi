using Curso.ComercioElectronico.Aplicacion;
using Curso.ComercioElectronico.Dominio;
using Curso.ComercioElectronico.Infraestructura;
using Curso.ComercioElectronico.WebApi;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddControllers(options =>
{
    //Aplicar filter globalmente a todos los controller
    options.Filters.Add<ApiExceptionFilterAttribute>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregar las inyecciones de dependencia de cada una de las capas
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddDomain(builder.Configuration);

//Configurar esquema de autentificacion jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

//Configurar politica
builder.Services.AddAuthorization(options =>
{
    //de verificacion de claims
    //options.AddPolicy("PoliticaClaim", policy => policy.RequireClaim("CodigoAcceso"));
    options.AddPolicy("Ecuatoriano", policy => policy.RequireClaim("Ecuatoriano", true.ToString()));
    options.AddPolicy("TieneLicencia", policy => policy.RequireClaim("TieneLicencia", true.ToString()));
    options.AddPolicy("EcuatorianoLicencia", policy => policy.RequireClaim("TieneLicencia", true.ToString())
                                                            .RequireClaim("Ecuatoriano", true.ToString()));

    //Configurable
    //Archivo de configuracion Politicas => roles asociados
    options.AddPolicy("Gestion", policy => policy.RequireRole("Admin", "Soporte"));
});

builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("JWT"));

//builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Politica global CORS Middleware  
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // Permitir cualquier origen
    .AllowCredentials());

//2. registra el middleware que usa los esquemas de autenticación registrados
//debe estar antes de cualquier componente componente que requiere autenticacion
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
