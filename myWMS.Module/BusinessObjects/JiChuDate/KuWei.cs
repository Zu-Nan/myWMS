using DevExpress.ExpressApp.Model;
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
    public class KuWei : XPObject
    {
        public KuWei(Session session) : base(session) { }

        [Association("KuQv-KuWeis")]
        [DisplayName("所属库区")]
        public KuQv KuWeis
        {
            get => GetPropertyValue<KuQv>(nameof(KuWeis));
            set => SetPropertyValue(nameof(KuWeis), value);
        }

        private string _lie;
        [DisplayName("列号")]
        public string Lie
        {
            get => _lie;
            set => SetPropertyValue(nameof(Lie), ref _lie, value);
        }

        private string _pai;
        [DisplayName("排号")]
        public string Pai
        {
            get => _pai;
            set => SetPropertyValue(nameof(Pai), ref _pai, value);
        }

        private string _ceng;
        [DisplayName("层号")]
        public string Ceng
        {
            get => _ceng;
            set => SetPropertyValue(nameof(Ceng), ref _ceng, value);
        }

        private bool _isEmpty;
        [DisplayName("空货位")]
        public bool IsEmpty
        {
            get => _isEmpty;
            set => SetPropertyValue(nameof(IsEmpty), ref _isEmpty, value);
        }

        private bool _isLock;
        [DisplayName("任务锁定")]
        public bool IsLock
        {
            get => _isLock;
            set => SetPropertyValue(nameof(IsLock), ref _isLock, value);
        }

        private bool _qiYong;
        [DisplayName("启用")]
        public bool QiYong
        {
            get => _qiYong;
            set => SetPropertyValue(nameof(QiYong), ref _qiYong, value);
        }

        private DateTime _time;
        [DisplayName("创建日期")]
        [ModelDefault("DisplayFormat", "{0:yyyy/MM/dd}")]
        public DateTime Time
        {
            get => _time;
            set => SetPropertyValue(nameof(Time), ref _time, value);
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            Time = DateTime.Now;
        }
    }
}
