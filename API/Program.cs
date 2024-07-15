using API.Context;
using API.lib;
using API.Lib;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


// add the schema filter, show the enum values in the swagger
builder.Services.AddSwaggerGen(cfg => cfg.SchemaFilter<EnumSchemaFilter>());

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// initial migration
DbManager.MigrateDatabase(app);

app.UseStaticFiles();
app.UseRouting();

// always enable swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(policyBuilder =>
    policyBuilder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();