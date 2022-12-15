//import form Extensions folder in our project(Api)
using Api.Datas;
using Api.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register DbContext
builder.Services.AddDbContextPool<DataContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();



// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();//added code
    app.UseSwagger();
    app.UseSwaggerUI();
}

//added code
else
{
    app.UseHsts();//will add middleware for using HSTS, which adds the Strict-Transport-Security header.
}


app.UseHttpsRedirection();//add the middleware for the redirect from http|https


app.UseStaticFiles();


app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All//will forward proxy headers to the current request.
});


app.UseCors("CorsPolicy");

app.UseAuthorization();//add authorization middleware to specified IApplicationBuilder to enable authorization capabilities

//**************************
//  customise middleware
//**************************
//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hellow world! from middleware comment!");
//});

//app.Use(async (context, next) =>
//{
//    Console.WriteLine($"Logic before executing the next delegate in the user method");
//    await next.Invoke();
//    Console.WriteLine($"Logic after executing the next delegate in the use method");
//});

//app.Run(async context =>
//{
//    Console.WriteLine($"Write the response to the client in the run method");
//    context.Response.StatusCode = 200;
//    await context.Response.WriteAsync("Hello from the middelware component");
//});


//**************************
//  customise middleware
//**************************


app.MapControllers();

app.Run();
