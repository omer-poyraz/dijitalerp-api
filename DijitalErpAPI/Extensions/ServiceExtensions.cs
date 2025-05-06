using System.Reflection;
using System.Text;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;
using Services.Extensions;

namespace DijitalErpAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("sqlConnection"))
            );
        }

        public static void ConfigureGeneral(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddSingleton(new FileReaderService());
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IAssemblyFailureStateService, AssemblyFailureStateService>();
            services.AddScoped<IAssemblyFailureStateRepository, AssemblyFailureStateRepository>();

            services.AddScoped<IAssemblyManuelService, AssemblyManuelService>();
            services.AddScoped<IAssemblyManuelRepository, AssemblyManuelRepository>();

            services.AddScoped<IAssemblyNoteService, AssemblyNoteService>();
            services.AddScoped<IAssemblyNoteRepository, AssemblyNoteRepository>();

            services.AddScoped<IAssemblyVisualNoteService, AssemblyVisualNoteService>();
            services.AddScoped<IAssemblyVisualNoteRepository, AssemblyVisualNoteRepository>();

            services.AddScoped<IAssemblySuccessStateService, AssemblySuccessStateService>();
            services.AddScoped<IAssemblySuccessStateRepository, AssemblySuccessStateRepository>();

            services.AddScoped<IAssemblyQualityService, AssemblyQualityService>();
            services.AddScoped<IAssemblyQualityRepository, AssemblyQualityRepository>();

            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ILogRepository, LogRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IServicesRepository, ServicesRepository>();
            services.AddScoped<IServicesService, ServicesService>();

            services.AddScoped<ITechnicalDrawingRepository, TechnicalDrawingRepository>();
            services.AddScoped<ITechnicalDrawingService, TechnicalDrawingService>();

            services.AddScoped<ITechnicalDrawingFailureStateRepository, TechnicalDrawingFailureStateRepository>();
            services.AddScoped<ITechnicalDrawingFailureStateService, TechnicalDrawingFailureStateService>();

            services.AddScoped<ITechnicalDrawingSuccessStateRepository, TechnicalDrawingSuccessStateRepository>();
            services.AddScoped<ITechnicalDrawingSuccessStateService, TechnicalDrawingSuccessStateService>();

            services.AddScoped<ITechnicalDrawingNoteRepository, TechnicalDrawingNoteRepository>();
            services.AddScoped<ITechnicalDrawingNoteService, TechnicalDrawingNoteService>();

            services.AddScoped<ITechnicalDrawingVisualNoteRepository, TechnicalDrawingVisualNoteRepository>();
            services.AddScoped<ITechnicalDrawingVisualNoteService, TechnicalDrawingVisualNoteService>();

            services.AddScoped<ITechnicalDrawingQualityRepository, TechnicalDrawingQualityRepository>();
            services.AddScoped<ITechnicalDrawingQualityService, TechnicalDrawingQualityService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            services.AddScoped<IUserPermissionService, UserPermissionService>();


            services.AddCors(opt =>
            {
                opt.AddPolicy(
                    "CorsPolicy",
                    build =>
                        build
                            .AllowAnyHeader()
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .WithExposedHeaders("X-Pagination")
                );
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            services
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["validIssuer"],
                        ValidAudience = jwtSettings["validAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),
                    };
                });
        }

        public static void ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerInfo = configuration.GetSection("SwaggerInfo");

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = swaggerInfo["Title"], Version = swaggerInfo["Version"] });
                s.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme()
                    {
                        In = ParameterLocation.Header,
                        Description = "Bearer xxTOKENxx",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                    }
                );

                s.AddSecurityRequirement(
                    new OpenApiSecurityRequirement()
                    {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                        Name = "Bearer",
                    },
                    new List<string>()
                },
                    }
                );

                var apiXmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var apiXmlPath = Path.Combine(AppContext.BaseDirectory, apiXmlFile);
                var presentationXmlFile = "Presentation.xml";
                var presentationXmlPath = Path.Combine(AppContext.BaseDirectory, presentationXmlFile);

                if (File.Exists(apiXmlPath))
                {
                    s.IncludeXmlComments(apiXmlPath);
                }

                if (File.Exists(presentationXmlPath))
                {
                    s.IncludeXmlComments(presentationXmlPath);
                }
            });
        }
    }
}
