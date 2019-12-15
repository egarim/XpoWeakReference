using DevExpress.Xpo;
using System;

namespace XpoWeakReference
{
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
}
