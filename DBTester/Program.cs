using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BikesAndBrews.Repository;
using BikesAndBrews.Models;
using BikesAndBrews.Repository.Sql;
using System.Linq;

namespace DBTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Program tester = new Program();
            //tester.TestDBContext();
            //tester.TestDbReader();

            /*Customer cust = new Customer() { FirstName = "John", LastName = "Doe", Email = "john@someaddress.com", Phone = "9187772345" };
            int id = tester.AddCustomer(cust);
            Console.WriteLine($"Customer ID: {id}");

            cust = tester.GetCustomer(id);
            Console.WriteLine($"Name: {cust.FirstName} {cust.LastName} Email: {cust.Email} Phone: {cust.Phone}"); */

            int count = tester.DeleteCustomer(new List<int> { 1448, 1449 });
            Console.WriteLine($"deleted {count} customers");            
        }

        public int AddCustomer(Customer customer)
        {
            int id = 0;

            using (var db = new BikesAndBrewsContext())
            {
                ICustomerRepository repo = new SqlCustomerRepository(db);
                id = repo.InsertAsync(customer).Result.Id;
            }
            
            return id;
        }

        public bool DeleteCustomer(int id)
        {
            bool result = false;
            using (var db = new BikesAndBrewsContext())
            {
                ICustomerRepository repo = new SqlCustomerRepository(db);
               result = repo.DeleteAsync(id).Result;
            }

            return result;
        }

        public int DeleteCustomer(List<int> idList)
        {
            int result = 0;
            using (var db = new BikesAndBrewsContext())
            {
                ICustomerRepository repo = new SqlCustomerRepository(db);
                result = repo.DeleteRangeAsync(idList).Result;
            }

            return result;
        }

        public Customer GetCustomer(int id)
        {
            Customer cust = null;

            using (var db = new BikesAndBrewsContext())
            {
                ICustomerRepository repo = new SqlCustomerRepository(db);
                cust = repo.GetAsync(id).Result;
            }

            return cust;
        }

        public void TestDBContext()
        {
            using (var db = new BikesAndBrewsContext())
            {
                // Read from the db

                //List<State> states = db.State.ToList();

                //foreach (var state in states)
                //{
                //    Console.WriteLine($"State: {state.Name}  Abbr: {state.ShortName}  Sales Tax {state.SalesTax}");
                //}

                Order order = db.Order.FirstOrDefault(o => o.Id == 90);

                Console.WriteLine($"{order.Id} {order.OrderDate}");
                    //.Where(o => o.CustomerId == 90);
            }
        }

        public void TestDbReader()
        {
            //string connStr = "Data Source=HPLPT1;Initial Catalog=BikeStore;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader dataReader;
            string sql = "select Name, ShortName from sales.State";
            cnn = new SqlConnection(Constants.connStr);
            cnn.Open();
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine($"State: {dataReader.GetString(0)} Abbr: {dataReader.GetString(1)} ");
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        /*
        public class DataContext : DbContext
        {
            public DbSet<Order> Orders { get; set; }
            public DbSet<User> Users { get; set; }
            // Here list any other DbSet...

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // First we identify the model-types by examining the properties in the DbContext class
                // Here, I am assuming that your DbContext class is called "DataContext"
                var modelTypes = typeof(DataContext).GetProperties()
                                 .Where(x => x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                                 .Select(x => x.PropertyType.GetGenericArguments().First())
                                 .ToList();

                // Feel free to add any other possible types you may have defined your "Id" property with
                // Here I am assuming that only short, int, and bigint would be considered identity
                var identityTypes = new List<Type> { typeof(Int16), typeof(Int32), typeof(Int64) };

                foreach (Type modelType in modelTypes)
                {
                    // Find the first property that is named "id" with the types defined in identityTypes collection
                    var key = modelType.GetProperties()
                                       .FirstOrDefault(x => x.Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase) && identityTypes.Contains(x.PropertyType));

                    // Once we know a matching property is found
                    // We set the propery as Identity using UseSqlServerIdentityColumn() method
                    if (key == null)
                    {
                        continue;
                    }

                    // Here we identify the Id property to be set to Identity
                    // Also, we use change the PropertySaveBehavior on the same
                    // property to ignore the values 
                    modelBuilder.Entity(modelType)
                                .Property(key.Name)
                                .UseSqlServerIdentityColumn()
                                .Metadata.BeforeSaveBehavior = PropertySaveBehavior.Ignore;
                }
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (optionsBuilder.IsConfigured)
                {
                    return;
                }

                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ConnectionName"]);
            } 
        } */
    }
}
