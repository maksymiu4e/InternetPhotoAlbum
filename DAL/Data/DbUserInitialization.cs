using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;
using static Shared.Shared.Enums;

namespace DAL.Data
{
    public static class DbUserInitialization
    {
        public static async Task InitializeAdmin(UserManager<User> userManager)
        {
            var admin = await userManager.FindByEmailAsync(AdminData.GetDataFromFile("Email"));
            if (admin != null)
            {
                return;
            }

            admin = new User
            {
                FirstName = "Admin",
                LastName = "Adminovych",
                Email = AdminData.GetDataFromFile("Email"),
                UserName = AdminData.GetDataFromFile("Email"),
                EmailConfirmed = true
            };

            IdentityResult result = await userManager.CreateAsync(admin, AdminData.GetDataFromFile("Password"));

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, UserRole.Admin.ToString());
            }
        }

    }

    internal class AdminData
    {
        public static string GetDataFromFile(string data)
        {
            string field = string.Empty;
            try
            {
                using (var src = new StreamReader("../AdminData.txt"))
                {
                    string adminData = src.ReadToEnd();
                    JObject adminObject = JObject.Parse(adminData);
                    JToken jToken = adminObject[data];
                    field = jToken.ToString();
                }
            }
            catch (Exception)
            {
                throw new Exception("There is no such File. Contact Volodymyr Majsymiuk.");
            }

            return field;
        }
    }

}
