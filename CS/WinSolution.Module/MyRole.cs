using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace WinSolution.Module {
    [DefaultClassOptions]
    public class MyRole : BaseObject {
        public MyRole(Session session) : base(session) { }
        private string _roleName;
        public string RoleName {
            get { return _roleName; }
            set { SetPropertyValue("RoleName", ref _roleName, value); }
        }
        [Association("MyRoles-MyUsers")]
        public XPCollection<MyUser> MyUsers {
            get {
                return GetCollection<MyUser>("MyUsers");
            }
        }
    }

}
