using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace WinSolution.Module {
    [DefaultClassOptions]
    public class MyUser : BaseObject {
        public MyUser(Session session) : base(session) { }
        private string _userName;
        public string UserName {
            get { return _userName; }
            set { SetPropertyValue("UserName", ref _userName, value); }
        }
        [Association("MyRoles-MyUsers")]
        public XPCollection<MyRole> MyRoles {
            get {
                return GetCollection<MyRole>("MyRoles");
            }
        }
    }

}
