using DigitalBank.Api.Middleware;
using DigitalBank.Business;
using DigitalBank.Infrastructure.Contracts.Business;
using DigitalBank.Infrastructure.Contracts.Repository;
using DigitalBank.Repository.Data;
using DigitalBank.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DigitalBankContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DigitalBankDbConnection")));

builder.Services.AddScoped<IAccountBusiness, AccountLogic>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IBankBusiness, BankLogic>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<ICustomerBusiness, CustomerLogic>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ITransactionBusiness, TransactionLogic>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json")
.Build();

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Debug()
            .WriteTo.Console()            
            .WriteTo.MSSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Digitalbank",
             new MSSqlServerSinkOptions
             {
                 TableName = "Logs",
                 SchemaName = "dbo",
                 AutoCreateSqlTable = true
             })
            .ReadFrom.Configuration(configuration)
             .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();