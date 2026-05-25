using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myWMS.Module.BusinessObjects.JiChuDate
{
    [DefaultClassOptions]
    [NavigationItem("基础数据")]
    public class  KuWei:XPObject
    {
        public KuWei(Session session) : base(session) { }

        [Association("KuQv-KuWeis")]
        [DisplayName("所属库区")]
        public KuQv KuWeis
        {
            get => GetPropertyValue<KuQv>(nameof(KuWeis));
            set => SetPropertyValue(nameof(KuWeis), value);
        }


    }
}
