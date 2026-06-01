using DevExpress.ExpressApp;
using Microsoft.AspNetCore.Mvc;
using myWMS.Module;
using myWMS.Module.BusinessObjects.JiChuDate;
using myWMS.Module.BusinessObjects.KuCun;
using myWMS.Module.BusinessObjects.ZuoYe;
using wms.Module.BusinessObjects.TongJi;

namespace myWMS.Blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIController : ControllerBase
    {
        private readonly IObjectSpaceFactory objectSpaceFactory;
        
        //完成作业
        [HttpPost("WanCheng")]
        public IActionResult WanCheng([FromBody] int renwuOid)
        {
            try
            {
                using var os=objectSpaceFactory.CreateObjectSpace(typeof(RenWu));
                using var logSpace=objectSpaceFactory.CreateObjectSpace<Log>();

                //Oid查任务
                RenWu renwu=os.GetObjectByKey<RenWu>(renwuOid);
                if (renwu == null)
                {
                    return NotFound($"未找到任务,Oid={renwuOid}");
                }
                
                if(renwu.RenWuLeiXing==RenWuLeiXing.RuKuRenWu)
                {
                    

                    LogHelper.WriteMessage(logSpace,"APIController.WanCheng",$"入库任务已完成,Oid={renwuOid},包号={renwu.BaoHao},货位={renwu.KuWei}");
                }
                else
                {
                    
                

                    LogHelper.WriteMessage(logSpace,"APIController.WanCheng",$"出库任务已完成,Oid={renwuOid},包号={renwu.BaoHao},货位={renwu.KuWei}");
                }

                return Ok(new{success=true,message="任务已完成"});
            }catch(Exception ex)
            {
                using var logSpace=objectSpaceFactory.CreateObjectSpace<Log>();
                LogHelper.WriteError(logSpace,"APIController.WanCheng",$"执行失败：{ex.Message}",ex);
                return BadRequest(new{success=false,message=ex.Message});
            }
        }
        
        //撤销作业
        [HttpPost("CheXiao")]
        public IActionResult CheXiao([FromBody] int renwuOid)
        {
            try
            {
                using var os=objectSpaceFactory.CreateObjectSpace(typeof(RenWu));
                using var logSpace=objectSpaceFactory.CreateObjectSpace<Log>();

                //Oid查任务
                RenWu renwu=os.GetObjectByKey<RenWu>(renwuOid);
                if (renwu == null)
                {
                    return NotFound($"未找到任务,Oid={renwuOid}");
                }

                if(renwu.RenWuLeiXing==RenWuLeiXing.RuKuRenWu)
                {
                    

                    LogHelper.WriteMessage(logSpace,"APIController.CheXiao",$"入库任务已撤销,Oid={renwuOid},包号={renwu.BaoHao}");
                }
                else
                {
                    
                

                    LogHelper.WriteMessage(logSpace,"APIController.CheXiao",$"出库任务已撤销,Oid={renwuOid},包号={renwu.BaoHao},货位={renwu.KuWei}");
                }
                LogHelper.WriteMessage(logSpace,"APIController.CheXiao",$"任务已撤销,Oid={renwuOid},包号={renwu.BaoHao},货位={renwu.KuWei}");

                return Ok(new{success=true,message="任务已撤销"});
            }catch(Exception ex)
            {
                using var logSpace=objectSpaceFactory.CreateObjectSpace<Log>();
                LogHelper.WriteError(logSpace,"APIController.CheXiao",$"执行失败：{ex.Message}",ex);
                return BadRequest(new{success=false,message=ex.Message});
            }
        }

        //新建物资
        [HttpPost("XinJianWuLiao")]
        public IActionResult XinJianWuLiao([FromBody] WuLiaoHelper wl)
        {
            try
            {
                using var os=objectSpaceFactory.CreateObjectSpace(typeof(WuLiao));
                using var logSpace=objectSpaceFactory.CreateObjectSpace<Log>();

                //新建物资
                WuLiao wuliaos=os.CreateObject<WuLiao>();
                wuliaos.BaoHao=wl.BaoHao;
                wuliaos.WuLiaoName=wl.WuLiaoName;
                wuliaos.MaKouName=wl.MaKouName;
                os.CommitChanges();

                LogHelper.WriteMessage(logSpace,"APIController.XinJianWuLiao",$"新建物资成功,包号={wl.BaoHao},码口名称={wl.MaKouName}");

                return Ok(new{success=true,message="物资已创建"});
            }catch(Exception ex)
            {
                using var logSpace=objectSpaceFactory.CreateObjectSpace<Log>();
                LogHelper.WriteError(logSpace,"APIController.XinJianWuLiao",$"执行失败：{ex.Message}",ex);
                return BadRequest(new{success=false,message=ex.Message});
            }
        }

        //执行入库
        [HttpPost("ZhiXingRuKu")]
        public IActionResult ZhiXingRuKu([FromBody] string rukouNum)
        {
            try
            {
                using var os=objectSpaceFactory.CreateObjectSpace(typeof(RuKou));
                using var logSpace=objectSpaceFactory.CreateObjectSpace<Log>();

                //查入口
                RuKou rukou=os.GetObjectByKey<RuKou>(rukouNum);
                if (rukou == null)
                {
                    return NotFound($"未找到入口{rukouNum}");
                }

                    

                LogHelper.WriteMessage(logSpace,"APIController.ZhiXingRuKu",$"入库任务已执行,Oid={rukouNum},包号={rukou.BaoHao}");


                return Ok(new{success=true,message="任务已执行"});
            }catch(Exception ex)
            {
                using var logSpace=objectSpaceFactory.CreateObjectSpace<Log>();
                LogHelper.WriteError(logSpace,"APIController.ZhiXingRuKu",$"执行失败：{ex.Message}",ex);
                return BadRequest(new{success=false,message=ex.Message});
            }
        }
    }
}
