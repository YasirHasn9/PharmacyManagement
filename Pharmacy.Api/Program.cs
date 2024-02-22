using Microsoft.EntityFrameworkCore;
using Pharmacy.Business;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IPostgresPharmacySink, PostgresPharmacySink>();
builder.Services.AddScoped<IPharmacyCreationService, PharmacyCreationService>();
builder.Services.AddScoped<IPostgresPharmacySource, PostgresPharmacySource>();
builder.Services.AddScoped<IPharmacyFetchingService, PharmacyFetchingService>();
builder.Services.AddScoped<IPharmacyUpdatingService, PharmacyUpdatingService>();

builder.Services.AddDbContext<PharmacyContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .EnableSensitiveDataLogging());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Replace with your front-end application's origin
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
var app = builder.Build();

// Seed the data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}


app.MapGet("/Pharmacies/healthCheck", () =>
{
    var message = new { Message = "Ok." };

    return message;
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();