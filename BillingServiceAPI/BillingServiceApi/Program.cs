using BillingServiceApi;
using BillingServiceApi.PaymentGateways.Interfaces;
using BillingServiceApi.PaymentGateways.Services;
using BillingServiceApi.PaymentGateways.Services.PaymentGatewayServiceX;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging();
builder.Logging.AddConsole();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPaymentGatewayService, PayPalGatewayService>();
builder.Services.AddTransient<IPaymentGatewayService, PaymentGatewayServiceY>();

builder.Services.Configure<PaymentGatewayOptions>(builder.Configuration.GetSection(nameof(PaymentGatewayOptions)));

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
