using Microsoft.EntityFrameworkCore;
using Pharmacy.Business;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<ISqlPharmacySink, SqlPharmacySink>();
    builder.Services.AddScoped<IPharmacyCreationService, PharmacyCreationService>();
    builder.Services.AddScoped<ISqlPharmacySource, SqlPharmacySource>();
    builder.Services.AddScoped<IPharmacyFetchingService, PharmacyFetchingService>();
    builder.Services.AddScoped<IPharmacyUpdatingService, PharmacyUpdatingService>();

    builder.Configuration.AddEnvironmentVariables();

    builder.Services.AddDbContext<PharmacyContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("PharmacyDatabase")));

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
}


var app = builder.Build();
{
    // Seed the data
    // get all the services in a using block to dispose of them after the seed data is initialized
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
}