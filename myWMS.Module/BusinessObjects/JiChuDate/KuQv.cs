using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myWMS.Module.BusinessObjects.JiChuDate
{
    [DefaultClassOptions]
    [NavigationItem("基础数据")]
    public class KuQv : XPObject
    {
        public KuQv(Session session) : base(session) { }

        [Association("CangKu-KuQvs")]
        [DisplayName("所属仓库")]
        public CangKu CangKu
        {
            get => GetPropertyValue<CangKu>(nameof(CangKu));
            set => SetPropertyValue(nameof(CangKu), value);
        }

        private string _kuqvName;
        [DisplayName("库区名称")]
        public string KuQvName
        {
            get => _kuqvName;
            set => SetPropertyValue(nameof(KuQvName), ref _kuqvName, value);
        }

        private string _kuqvNum;
        [DisplayName("库区编号")]
        public string KuQvNum
        {
            get => _kuqvNum;
            set => SetPropertyValue(nameof(KuQvNum), ref _kuqvNum, value);
        }

        private int _lieNum;
        [DisplayName("列数量")]
        public int LieNum
        {
            get => _lieNum;
            set => SetPropertyValue(nameof(LieNum), ref _lieNum, value);
        }

        private int _qishiLie;
        [DisplayName("起始列")]
        public int QishiLie
        {
            get => _qishiLie;
            set => SetPropertyValue(nameof(QishiLie), ref _qishiLie, value);
        }

        private int _paiNum;
        [DisplayName("排数量")]
        public int PaiNum
        {
            get => _paiNum;
            set => SetPropertyValue(nameof(PaiNum), ref _paiNum, value);
        }

        private int _qishiPai;
        [DisplayName("起始排")]
        public int QishiPai
        {
            get => _qishiPai;
            set => SetPropertyValue(nameof(QishiPai), ref _qishiPai, value);
        }

        private int _cengNum;
        [DisplayName("层数量")]
        public int CengNum
        {
            get => _cengNum;
            set => SetPropertyValue(nameof(CengNum), ref _cengNum, value);
        }

        private int _qishiCeng;
        [DisplayName("起始层")]
        public int QishiCeng
        {
            get => _qishiCeng;
            set => SetPropertyValue(nameof(QishiCeng), ref _qishiCeng, value);
        }

        private bool _zidongKuQv;
        [DisplayName("自动化库区")]
        public bool ZidongKuQv
        {
            get => _zidongKuQv;
            set => SetPropertyValue(nameof(ZidongKuQv), ref _zidongKuQv, value);
        }

        private DateTime _time;
        [DisplayName("创建日期")]
        public DateTime Time
        {
            get => _time;
            set => SetPropertyValue(nameof(Time), ref _time, value);
        }

        private bool _lock;
        [DisplayName("锁定")]
        public bool Lock
        {
            get => _lock;
            set => SetPropertyValue(nameof(Lock), ref _lock, value);
        }

        private string _beizhu;
        [DisplayName("备注")]
        [Size(100)]
        public string BeiZhu
        {
            get => _beizhu;
            set => SetPropertyValue(nameof(BeiZhu), ref _beizhu, value);
        }

        [Association("KuQv-KuWeis")]
        public XPCollection<KuWei> KuWeis => GetCollection<KuWei>(nameof(KuWeis));

        protected override void OnSaving()
        {
            base.OnSaving();
            Time = DateTime.Now;
        }
    }
}
