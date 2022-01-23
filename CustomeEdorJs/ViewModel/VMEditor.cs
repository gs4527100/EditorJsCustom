using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CustomeEdorJs.ViewModel
{
    public class VMEditor
    {

        public int uploadImage(HttpFileCollectionBase postedFiles, ref string ImgUrl)
        {
            string fileName = string.Empty, filePath = string.Empty, fileExt = string.Empty;
            filePath = "~/Upload/";

            try
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(filePath)))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(filePath));
                }

                fileExt = Path.GetExtension(postedFiles[0].FileName);
                fileName = "img_" + DateTime.Now.ToFileTime().ToString() + fileExt;
                postedFiles[0].SaveAs(HttpContext.Current.Server.MapPath(filePath) + fileName);
                ImgUrl = "http://localhost:64299/Upload/" + fileName;
                return 1;
            }
            catch
            {
                return -1;
            }
        }
    }
}