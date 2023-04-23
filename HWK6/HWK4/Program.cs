using HW2Rest;
using HWK4;
using HWK4.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<Seed>();
builder.Services.AddControllers().AddJsonOptions(x =>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add connection to MySQL database
builder.Services.AddEntityFrameworkMySql().AddDbContext<DataContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version())));

//Add repository references
builder.Services.AddScoped<ICarRepository, HW2Repository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
SeedData(app);

void SeedData(IHost app)
{

    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();

        service.SeedDataContext();

    }
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
