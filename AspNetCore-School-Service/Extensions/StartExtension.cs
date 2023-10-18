using AspNetCore_School_DataAccess_Layer.Context;
using AspNetCore_School_DataAccess_Layer.Identity;
using AspNetCore_School_DataAccess_Layer.Repository;
using AspNetCore_School_DataAccess_Layer.UnitOfWorks;
using AspNetCore_School_Entity_Layer.Interfaces;
using AspNetCore_School_Entity_Layer.IService;
using AspNetCore_School_Entity_Layer.UnitOfWorks;
using AspNetCore_School_Service.Mapping;
using AspNetCore_School_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_School_Service.Extensions
{
    public static class StartExtension
    {
        public static void AddExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISchoolService,SchoolService>();
            services.AddScoped<IClassService,ClassService>();


            services.AddAutoMapper(typeof(MappingProfile));


            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false; 
                options.Password.RequiredLength = 3; 
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;  
                options.Password.RequireDigit = false; 
                                                      
                options.User.RequireUniqueEmail = false;
                options.Lockout.MaxFailedAccessAttempts = 3;  
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);  

            }).AddEntityFrameworkStores<SchoolContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(op =>
            {
                op.LoginPath = new PathString("/Account/Login");   	
                op.ExpireTimeSpan = TimeSpan.FromMinutes(10); 
                                                            
                op.SlidingExpiration = true;
                op.Cookie = new CookieBuilder()
                {
                    Name = "IdentityAppCookie", 
                    HttpOnly = true,  

                };

            });



        }
    }
}
