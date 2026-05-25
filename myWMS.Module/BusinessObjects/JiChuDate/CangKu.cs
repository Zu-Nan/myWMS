using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;


namespace myWMS.Module.BusinessObjects.JiChuDate
{
    [DefaultClassOptions]
    [NavigationItem("基础数据")]

    public class CangKu : XPObject
    {
        public CangKu(Session session) : base(session) { }

        private string _cangkuName;
        [DisplayName("仓库名称")]
        public string CangKuName
        {
            get => _cangkuName;
            set => SetPropertyValue(nameof(CangKuName), ref _cangkuName, value);
        }

        private string _cangkuNum;
        [DisplayName("仓库编号")]
        public string CangKuNum
        {
            get => _cangkuNum;
            set => SetPropertyValue(nameof(CangKuNum), ref _cangkuNum, value);
        }

        private DateTime _time;
        [DisplayName("创建日期")]
        [ModelDefault("DisplayFormat", "{0:yyyy/MM/dd}")]
        public DateTime Time
        {
            get => _time;
            set => SetPropertyValue(nameof(Time), ref _time, value);
        }

        private string _beizhu;
        [DisplayName("备注")]
        [Size(100)]
        public string BeiZhu
        {
            get => _beizhu;
            set => SetPropertyValue(nameof(BeiZhu), ref _beizhu, value);
        }

        //仓库一对多库区
        [Association("CangKu-KuQvs")]
        public XPCollection<KuQv> KuQvs=>GetCollection<KuQv>(nameof(KuQvs));

        protected override void OnSaving()
        {
            base.OnSaving();
            Time = DateTime.Now;
        }
    }
}
