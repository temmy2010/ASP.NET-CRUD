using WalletPlus_Inc.Web.Data.Entities;

namespace WalletPlus_Inc.Web.Data
{
    public class SeedHelper
    {
        public static async Task InitializeData(ApplicationDbContext context)
        {
            //1. check if clients contain data
            if (!context.Customers.Any())
            {
                //2. create sample data
                context.Customers.Add(new Customer
                {
                    FirstName = "Francis",
                    LastName = "Joseph",
                    MiddleName = "Ayo",
                    Gender = GenderEnum.Male,
                    MaritalStatus = "Single",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    Country = "Nigeria",
                    State = "Lagos",
                    City = "Lagos"
                });

                context.Customers.Add(new Customer
                {
                    FirstName = "Alade",
                    LastName = "Ibrahim",
                    MiddleName = "Ade",
                    Gender = GenderEnum.Male,
                    MaritalStatus = "Married",
                    DateOfBirth = DateTime.Now.AddYears(-15),
                    Country = "Nigeria",
                    State = "Ondo",
                    City = "Akure"
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
