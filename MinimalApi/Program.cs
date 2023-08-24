using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Repository;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IPersonRepository, PersonRepository>();
WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();