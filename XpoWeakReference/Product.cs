using DevExpress.Xpo;
using System;

namespace XpoWeakReference
{
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
}
