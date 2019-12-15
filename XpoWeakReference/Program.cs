using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System;
using System.IO;

namespace XpoWeakReference
{
    class Program
    {
        static void Main(string[] args)
        {

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string connectionString = SQLiteConnectionProvider.GetConnectionString(Path.Combine(appDataPath, "myXpoApp.db"));
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);





            UnitOfWork UoW = new UnitOfWork();


          



            Product product1 = new Product(UoW) { Code = "001", Name = "Product1", Price =10.0M };
            Product product2 = new Product(UoW) { Code = "002", Name = "Product2", Price = 10.0M };

            
            Customer Customer1=new Customer(UoW) { Code = "001", Name = "Jose Manuel Ojeda"};
            Customer Customer2 = new Customer(UoW) { Code = "001", Name = "Oscar Ojeda" };

            UoW.CommitChanges();

            TestClass Instance1 = new TestClass(UoW);
            Instance1.Object1 = new XPWeakReference(product1);
            Instance1.Object2 = new XPWeakReference(product2);

            TestClass Instance2 = new TestClass(UoW);
            Instance2.Object1 = new XPWeakReference(Customer1);
            Instance2.Object2 = new XPWeakReference(Customer2);

            UoW.CommitChanges();


            XPCollection<TestClass> Classes = new XPCollection<TestClass>(UoW);



        }
    }
}
