using GestionUniversidad.Authentication;
using GestionUniversidad.Db;
using GestionUniversidad.Services;
using GestionUniversidad.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//MIS SERVICIOS
builder.Services.AddDbContext<Database>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});


builder.Services.AddScoped<DocenteService>();
builder.Services.AddScoped<EstudianteService>();
builder.Services.AddScoped<ProgramaService>();
builder.Services.AddScoped<FacultadService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<Utilidades>();
builder.Services.AddScoped<HttpContextAccessor>();
builder.Services.AddScoped<MateriaService>();
builder.Services.AddScoped<MatriculaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Todos", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GestionUniversidad v1");

        //PARA COLOCAR LOS RECURSOS SIN DESPLEGARLOS
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);

        //PARA NO MOSTRAR ESQUEMAS
        //c.DefaultModelsExpandDepth(-1);

    });
}


app.UseCors("Todos");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
