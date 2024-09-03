using Microsoft.AspNetCore.SignalR.Client;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// Conexão com o Azure SignalR
var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5059/chat")
    .Build();

try
{
    // Inicia a conexão
    await connection.StartAsync();
    Console.WriteLine("Conectado ao SignalR.");

    // Enviar mensagem
    while (true)
    {
        Console.Write("Digite a mensagem para enviar: ");
        var message = Console.ReadLine();

        await connection.InvokeAsync("SendMessage", message);
        Console.WriteLine("Mensagem enviada.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
finally
{
    await connection.DisposeAsync();
}