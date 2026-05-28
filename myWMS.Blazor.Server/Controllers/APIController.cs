using DevExpress.ExpressApp;
using Microsoft.AspNetCore.Mvc;
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

        
    }
}
