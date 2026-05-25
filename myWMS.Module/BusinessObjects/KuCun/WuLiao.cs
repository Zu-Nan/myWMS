using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myWMS.Module.BusinessObjects.KuCun
{
    [DefaultClassOptions]
    [NavigationItem("在库管理")]
    public class  WuLiao:XPObject
    {
        public WuLiao(Session session) : base(session) { }


    }
}
