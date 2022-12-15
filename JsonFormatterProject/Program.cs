using JsonFormatterProject;
using JsonFormatterProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented= true;
});
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddTransient<IJsonFormatter,JsonFormatter>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware <ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
