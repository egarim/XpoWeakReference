using DevExpress.Xpo;
using System;

namespace XpoWeakReference
{
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
