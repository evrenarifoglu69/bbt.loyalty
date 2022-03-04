using Bbt.Campaign.EntityFrameworkCore.Redis;
using Bbt.Campaign.Services;
using Bbt.Campaign.Shared.ServiceDependencies;
using Bbt.Campaign.Shared.Static;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

StaticValues.Campaign_Redis_ConStr = configuration["ConnectionStrings:RedisConnection"];
StaticValues.Campaign_Redis_Ttl = configuration["ConnectionStrings:RedisTtl"];
StaticValues.Campaign_MsSql_ConStr = configuration["ConnectionStrings:DefaultConnection"];

#if DEBUG
Bbt.Campaign.Shared.Redis.RedisServer.StartRedis();
#endif

IocLoader.UseIocLoader(builder.Services);
ServiceModule.Configure(configuration, builder.Services);

builder.Services.AddSingleton<IRedisDatabaseProvider>(c => new RedisDatabaseProvider(StaticValues.Campaign_Redis_ConStr));
builder.Services.AddMemoryCache();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("CampaignApiCors", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
})); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors("CampaignApiCors");

app.UseAuthorization();

app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials());

app.MapControllers();

app.Run();
