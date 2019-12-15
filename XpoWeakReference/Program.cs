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
    public class TestClass : XPObject
    {
        public TestClass(Session session) : base(session)
        { }


        XPWeakReference object2;
        XPWeakReference object1;

        public XPWeakReference Object1
        {
            get => object1;
            set => SetPropertyValue(nameof(Object1), ref object1, value);
        }
        
        public XPWeakReference Object2
        {
            get => object2;
            set => SetPropertyValue(nameof(Object2), ref object2, value);
        }

    }
    public class Product : XPObject
    {
        public Product(Session session) : base(session)
        { }



        decimal price;
        string code;
        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }
        
        public decimal Price
        {
            get => price;
            set => SetPropertyValue(nameof(Price), ref price, value);
        }

    }
    public class Customer : XPObject
    {
        public Customer(Session session) : base(session)
        { }



        string name;
        string code;


        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }
    }
}
