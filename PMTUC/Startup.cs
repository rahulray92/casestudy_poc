using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PMT_BAL.Service;
using PMT_DAL.Data;
using PMT_DAL.Interface;
using PMT_DAL.Models;
using PMT_DAL.Repository;
using Swashbuckle.AspNetCore.Filters;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace PMTUC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// sum
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("PMT_DAL")));

            services.AddControllers();
            services.AddHttpClient();
            services.AddTransient<IRepository<Member>, RepositoryMember>();
            //services.AddTransient<IRepositoryTask<PMTTask>, RepositoryTask>();
            services.AddTransient<IAuthRepository<User>, RepositoryUser>();
            services.AddTransient<AuthService, AuthService>();
            services.AddTransient<MemberService, MemberService>();
            //services.AddTransient<TaskService, TaskService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           // services.AddRazorPages();
            services.AddControllers();
            
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PMT API", Version = "1.0" });
                c.IncludeXmlComments(System.IO.Path.Combine(System.AppContext.BaseDirectory, "PMTUC.xml"));
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization using bearer scheme",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                        GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddCors();
            //services.AddEndPointApiExplorer();
            //services.AddMvc(x => x.Conventions.Add(new ApiExplorerVersionConvention()));
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(MyAllowSpecificOrigins,
            //    builder =>
            //    {
            //        builder.WithOrigins("http://localhost:53135",
            //                            "http://localhost:4200"
            //                            )
            //                            .AllowAnyHeader()
            //                            .AllowAnyMethod();
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                

            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "My Demo API (V 1.0)");
            });
            
            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            // app.UseCors(MyAllowSpecificOrigins);
            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();
                endpoints.MapControllerRoute(name: "default", pattern: "projectmgmt/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
