using DigitalIdentity.App.Business.Abstract;
using DigitalIdentity.App.Business.Managers;
using DigitalIdentity.Data.Databases.SqlServer;
using DigitalIdentity.Data.Databases.SqlServer.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILocation, LocationManager>();
builder.Services.AddScoped<IVoucher, VoucherManager>();
builder.Services.AddScoped<IVouchee, VoucheeManager>();


//TODO: i shouldn't assign the business logic to the start, how will i manage this error
builder.Services.AddDbContextPool<SqlServerDb>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DigitalIdentityDb"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
