
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .WithMethods("GET", "POST");
        });
});


builder.Services.AddSignalR()
    .AddAzureSignalR();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseCors();
app.MapHub<ChatHub>("/chat");

app.Run();
