using CustomeEdorJs.Models;
using CustomeEdorJs.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomeEdorJs.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ImageUpload()
        {
            
            string ImgUrl = string.Empty;
            int err = 0;
            HttpFileCollectionBase fl;

            try
            {
                ModelFile m = new ModelFile();
                MFile f = new MFile();

                //Checking Posted Files
                if (Request.Files != null)
                {
                    fl = Request.Files;

                    err = new VMEditor().uploadImage(fl, ref ImgUrl);
                    f.url = ImgUrl;
                    m.file = f;
                }
                if (err == 1)
                    m.success = 1;
                else
                    m.success = 0;

                //Json Convertion
                var d = JsonConvert.SerializeObject(m, Formatting.Indented);
                return Json(m, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(ex.Message.ToString(), JsonRequestBehavior.AllowGet);
            }
        }

    }
}
