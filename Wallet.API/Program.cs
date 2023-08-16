using Microsoft.EntityFrameworkCore;
using Wallet.Infrastructure.Business;
using Wallet.Infrastucture.Data;
using Wallet.Infrastucture.Data.Repositories;
using Wallet.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
builder.Services.AddDbContext<DataContext>(options => 
	options
		.UseSqlServer(builder.Configuration.GetConnectionString("WalletConnection"),
			migration => migration.MigrationsAssembly("Wallet.Infrastucture.Data")));
builder.Services.Configure<PageSettings>(configuration.GetSection("PageSettings"));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<AccountRepository>();
builder.Services.AddTransient<OperationRepository>();

builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IOperationService, OperationService>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.Run();