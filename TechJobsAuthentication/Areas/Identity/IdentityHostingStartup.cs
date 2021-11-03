using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechJobsAuthentication.Areas.Identity.Data;
using TechJobsAuthentication.Data;

[assembly: HostingStartup(typeof(TechJobsAuthentication.Areas.Identity.IdentityHostingStartup))]
namespace TechJobsAuthentication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TechJobsAuthentication.Data.JobDbContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TechJobsAuthentication.Data.JobDbContext>();
            });
        }
    }
}