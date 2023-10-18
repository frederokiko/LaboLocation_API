using LaboLocation_API.LaboLocation_DAL.Repository;
using LaboLocation_API.LaboLocation_DAL.Services;
using LaboLocation_API.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDbConnection, SqlConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("default")));
builder.Services.AddScoped<IPersonneRepository, PersonneService>();
builder.Services.AddScoped<IEmployeRepository, EmployeService>();
builder.Services.AddScoped<IProprietaireRepository,ProprietaireService>();
builder.Services.AddScoped<ILocataireRepository,LocataireService>();
builder.Services.AddScoped<IBienRepository,BienService>();
builder.Services.AddScoped<IBatimentRepository,BatimentService>();
builder.Services.AddScoped<IGenre_pieceRepository,Genre_pieceService>();
builder.Services.AddScoped<IPieceRepository,PieceService>();
builder.Services.AddScoped<IGarageRepository,GarageService>();
builder.Services.AddScoped<IMessageRepository,MessageService>();  
builder.Services.AddScoped<IPhotoRepository,PhotoService>();
builder.Services.AddScoped<IVisiteRepository,VisiteService>();
builder.Services.AddScoped<IValideBienRepository,ValideBienService>();
builder.Services.AddScoped<IValideLocationRepository,ValideLocationService>();
builder.Services.AddScoped<IPhotoGarageRepository,PhotoGarageService>();

builder.Services.AddScoped<TokenGenerator>();

//Déclaration des différents niveaux de sécurité à mettre en place dans le
//controller grâce à l'attribut [Authorize("nom_de_la_police")]
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("AdminPolicy", option => option.RequireRole("Admin"));
    o.AddPolicy("ModoPolicy", option => option.RequireRole("Admin", "Modo"));
    o.AddPolicy("UserPolicy", option => option.RequireAuthenticatedUser());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenGenerator.secretKey)),
                ValidateLifetime = true,
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(o => o.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
