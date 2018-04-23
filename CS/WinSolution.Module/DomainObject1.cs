using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.ComponentModel;
using DevExpress.Data.Filtering;

namespace WinSolution.Module {
    [DefaultClassOptions]
    public class DomainObject1 : BaseObject {
        public DomainObject1(Session session) : base(session) { }
        private string _name;
        public string Name {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }
        private MyRole _myRole;
        [ImmediatePostData]
        public MyRole MyRole {
            get { return _myRole; }
            set { SetPropertyValue("MyRole", ref _myRole, value); }
        }
        private MyUser _myUser;
        [DataSourceProperty("MyUserDataSource")]
        //[DataSourceCriteria("MyRoles[RoleName = 'r2']")]
        public MyUser MyUser {
            get { return _myUser; }
            set { SetPropertyValue("MyUser", ref _myUser, value); }
        }
        private XPCollection<MyUser> myUserDataSourceInternal = null;
        [Browsable(false), MemberDesignTimeVisibility(false)]
        public XPCollection<MyUser> MyUserDataSource {
            get {
                if (myUserDataSourceInternal == null) {
                    myUserDataSourceInternal = new XPCollection<MyUser>(Session);
                }
                UpdateAddressDataSource();
                return myUserDataSourceInternal;
            }
        }
        private void UpdateAddressDataSource() {
            myUserDataSourceInternal.Criteria = MyRole != null ? CriteriaOperator.Parse("MyRoles[RoleName = ?]", MyRole.RoleName) : null;
        }
    }
}
