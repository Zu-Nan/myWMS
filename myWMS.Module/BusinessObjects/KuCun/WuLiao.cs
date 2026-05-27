using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using myWMS.Module.BusinessObjects.JiChuDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myWMS.Module.BusinessObjects.KuCun
{
    [DefaultClassOptions]
    [NavigationItem("在库管理")]
    //物料对象
    public class  WuLiao:XPObject
    {
        public WuLiao(Session session) : base(session) { }

        private CunChuZhuangTai _cunChuZhuangTai;
        [DisplayName("存储状态")]
        public CunChuZhuangTai CunChuZhuangTai
        {
            get => _cunChuZhuangTai; 
            set =>SetPropertyValue(nameof(CunChuZhuangTai), ref _cunChuZhuangTai, value); 
        }

        private string _baoHao;
        [DisplayName("系统包号")]
        public string BaoHao
        {
            get => _baoHao;
            set =>SetPropertyValue(nameof(BaoHao), ref _baoHao, value);
        }

        private KuWei _kuWei;
        [DisplayName("存储货位")]
        public KuWei KuWei
        {
            get => _kuWei;
            set =>SetPropertyValue(nameof(KuWei), ref _kuWei, value);
        }

        private string _wuLiaoName;
        [DisplayName("物料名称")]
        public string WuLiaoName
        {
            get => _wuLiaoName;
            set =>SetPropertyValue(nameof(WuLiaoName), ref _wuLiaoName, value);
        }

        private string _maKouName;
        [DisplayName("码口名称")]
        public string MaKouName
        {
            get => _maKouName;
            set =>SetPropertyValue(nameof(MaKouName), ref _maKouName, value);
        }

        private int _kuCunCount;
        [DisplayName("库存数量")]
        public int KuCunCount
        {
            get => _kuCunCount;
            set =>SetPropertyValue(nameof(KuCunCount), ref _kuCunCount, value);
        }

        private string _beiZhu;
        [DisplayName("备注")]
        [Size(100)]
        public string BeiZhu
        {
            get => _beiZhu;
            set =>SetPropertyValue(nameof(BeiZhu), ref _beiZhu, value);
        }

        private DateTime _time;
        [DisplayName("创建时间")]
        [ModelDefault("DisplayFormat", "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime Time
        {
            get => _time;
            set =>SetPropertyValue(nameof(Time), ref _time, value);
        }

        private DateTime _ruKuTime;
        [DisplayName("入库时间")]
        [ModelDefault("DisplayFormat", "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime RuKuTime
        {
            get => _ruKuTime;
            set => SetPropertyValue(nameof(RuKuTime), ref _ruKuTime, value);
        }

        private DateTime _chuKuTime;
        [DisplayName("出库时间")]
        [ModelDefault("DisplayFormat", "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime ChuKuTime
        {
            get => _chuKuTime;
            set => SetPropertyValue(nameof(ChuKuTime), ref _chuKuTime, value);
        }

        [PersistentAlias("KuWei.XiangDaoNum")]
        [DisplayName("巷道编号")]
        public string XiangDaoNum => EvaluateAlias(nameof(XiangDaoNum))?.ToString();

        [PersistentAlias("KuWei.Lie")]
        [DisplayName("列号")]
        public string Lie => EvaluateAlias(nameof(Lie))?.ToString();

        [PersistentAlias("KuWei.Pai")]
        [DisplayName("排号")]
        public string Pai => EvaluateAlias(nameof(Pai))?.ToString();

        [PersistentAlias("KuWei.Ceng")]
        [DisplayName("层号")]
        public string Ceng => EvaluateAlias(nameof(Ceng))?.ToString();

        protected override void OnSaving()
        {
            base.OnSaving();
            if (Session.IsNewObject(this))
            {
                Time = DateTime.Now;
            }
        }
    }
}
