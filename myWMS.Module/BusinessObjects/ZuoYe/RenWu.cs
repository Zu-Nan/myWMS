using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myWMS.Module.BusinessObjects.ZuoYe
{
    [DefaultClassOptions]
    [NavigationItem("作业管理")]
    public class RenWu : XPObject
    {
        public RenWu(Session session) : base(session) { }


    }
}
