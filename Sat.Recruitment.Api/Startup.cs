using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sat.Recruitment.Api.Data;
using Sat.Recruitment.Api.Service;
using Sat.Recruitment.Api.Services.Helpers;
using Sat.Recruitment.Api.UserTypeFactory;
using Sat.Recruitment.Api.UserTypeLogic;
using Sat.Recruitment.Api.UserTypeLogic.Contracts;
using Sat.Recruitment.Api.Validations.UserStateValidation;
using Sat.Recruitment.Api.Validations.UserStateValidation.Contracts;

namespace Sat.Recruitment.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddScoped<INameValidator, NameValidator>();
            services.AddScoped<IEmailValidator, EmailValidator>();
            services.AddScoped<IAddressValidator, AddressValidator>();
            services.AddScoped<IPhoneValidator, PhoneValidator>();
            services.AddScoped<INormalUserTypeLogic, NormalUserTypeLogic>();
            services.AddScoped<ISuperUserUserTypeLogic, SuperUserUserTypeLogic>();
            services.AddScoped<IPremiumUserTypeLogic, PremiumUserTypeLogic>();
            services.AddScoped<IUserTypeLogicCreator, UserTypeLogicCreator>();
            services.AddScoped<IUserDuplicateValidator, UserDuplicateValidator>();
            services.AddScoped<IUserValidator, UserValidator>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmailHelper, EmailHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
