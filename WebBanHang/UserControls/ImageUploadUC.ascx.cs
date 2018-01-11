using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using BUS;

namespace WebBanHang.UserControls
{
    public partial class ImageUploadUC : System.Web.UI.UserControl
    {
        public int MaxSize = 1024 * 1024;
        public event EventHandler GetError;
        public string ImagePath { get; set; } = "/images/products/";
        public string DefaultUrl { get; set; } = "/images/products/default.png";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                image.ImageUrl = DefaultUrl;
            }
        }

        public string GetUrl()
        {
            return image.ImageUrl;
        }

        bool UploadImage(out string message)
        {
            string[] validimage = {".png",".jpg",".jpeg"};
            if (UploadedFile.Value != String.Empty)
            {
                string extension = System.IO.Path.GetExtension(UploadedFile.Value);
                string fname = System.IO.Path.GetFileNameWithoutExtension(UploadedFile.Value);
                if (validimage.Contains(extension))
                {
                    if (UploadedFile.PostedFile.ContentLength < MaxSize)
                    {
                        string filename = fname;
                        string path = Server.MapPath(ImagePath);
                        int index = 1;
                        while(System.IO.File.Exists(path+filename+extension))
                        {
                            filename = filename + index.ToString();
                            index++;
                        }
                        HttpPostedFile file = UploadedFile.PostedFile;
                        file.SaveAs(path + filename + extension);
                        image.ImageUrl = ImagePath + filename + extension;
                        message = "SUCCESS";
                        return true;
                    }
                    else
                        message = "FILE_UPLOAD_TOO_BIG";
                }
                else
                    message = "INVALID_IMAGE_FORMAT";
            }
            message = "NO_FILE_UPLOADED";
            return false;
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            string message = "success";
            bool v = UploadImage(out message);
            if(!v)
            {
                GetError.Invoke(this,EventArgs.Empty);
            }
        }
    }
}