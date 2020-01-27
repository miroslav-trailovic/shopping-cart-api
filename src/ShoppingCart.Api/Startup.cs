using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ShoppingCart.Api.CustomExceptionMiddleware;
using ShoppingCart.BusinessLogic;
using ShoppingCart.BusinessLogic.Interfaces;
using ShoppingCart.BusinessModel;
using ShoppingCart.Repositories;
using ShoppingCart.Repositories.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace ShoppingCart.Api
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
            services.AddDbContext<ShoppingCartContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ShoppingCartConnection")));

            services.AddTransient<ICartItemRepository, CartItemRepository>();
            services.AddTransient<ICartItemBusinessLogic, CartItemBusinessLogic>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerBusinessLogic, CustomerBusinessLogic>();

            services.AddAutoMapper();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CartItemValidator>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Configuration.GetSection("ServiceData")["Version"], new Info
                {
                    Version = Configuration.GetSection("ServiceData")["Version"],
                    Title = Configuration.GetSection("ServiceData")["ServiceName"],
                    Description = Configuration.GetSection("ServiceData")["UniqueIdentifier"],
                    TermsOfService = Configuration.GetSection("ServiceData")["UniqueIdentifier"],
                    Contact = new Contact
                    {
                        Name = Configuration.GetSection("ServiceData")["Vendor"],
                        Email = Configuration.GetSection("ServiceData")["VendorEmail"],
                        Url = Configuration.GetSection("ServiceData")["VendorUrl"]
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping Cart API V1");
            });

            app.UseCustomExceptionMiddleware();

            app.UseMvc();
        }
    }
}
