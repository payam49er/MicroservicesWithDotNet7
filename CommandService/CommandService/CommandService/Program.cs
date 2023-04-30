var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

ConfigureServices(builder.Services);

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

// configuring custom services 
void ConfigureServices(IServiceCollection services)
{
    //adding db context and what database we want to use
    //register dependency
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}