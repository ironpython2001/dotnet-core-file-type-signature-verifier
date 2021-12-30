using System.Net;
//var config = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddCommandLine(args)
//                .Build();


var builder = WebApplication.CreateBuilder(args);
////builder.Configuration.AddConfiguration(config);

////this is for .net 6 and heroku
//////https://medium.com/null-exception/deploy-net-core-app-to-heroku-a22a04f107c9
//////https://stackoverflow.com/questions/69904260/configuring-kestrel-server-options-in-net-6-startup
//builder.WebHost.UseKestrel(serverOptions =>
//{
//    serverOptions.Listen(IPAddress.Any, Convert.ToInt32(Environment.GetEnvironmentVariable("PORT")));
//});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline. //dont do this in production
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
