using DijitalErpAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder
    .Services.AddControllers(opt =>
    {
        opt.RespectBrowserAcceptHeader = true;
        opt.ReturnHttpNotAcceptable = true;
    })
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
    .AddNewtonsoftJson(opt =>
        opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureGeneral();
builder.Services.ConfigureIdentity();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureSwagger(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<CreateInitialUsersMiddleware>();
app.UseMiddleware<LanguageMiddleware>();
app.UseMiddleware<LogMiddleware>();

app.UseHttpsRedirection();
app.UsePathBase("/api");

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
