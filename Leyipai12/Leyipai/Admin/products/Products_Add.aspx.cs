using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
    public partial class Admin_products_Products_Add : Leyipai.BLL.AdminBasePage
    {

        Leyipai.BLL.products.ProductsBLL bll = new Leyipai.BLL.products.ProductsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TestPurview(HttpContext.Current, 10);
            if (!IsPostBack)
            {
                brandBand();
                string pid = Request.QueryString["pid"];
                if (null != pid && !"".Equals(pid))
                {
                    editLoad(pid);
                }
            }
        }

        protected void brandBand()
        {
            List<Leyipai.Model.products_brand> list = new Leyipai.BLL.products.ProductsBrandBLL().GetModelList(" state=0");
            Brand_ID.DataSource = list;
            Brand_ID.DataBind();
            Brand_ID.Items.Insert(0, new ListItem("--请选择--", ""));
        }


        protected void Button2_Click(object sender, EventArgs e)
        {

            string _product_id = Product_ID.Value;
            string _product_name = Product_Name.Text;
            string _type_id = Type_ID.Value;
            string _brand_id = Brand_ID.SelectedValue;
            string _cost_price = Cost_price.Text;
            string _wholesale_price = Wholesale_price.Text;
            string _retail_price = Retail_Price.Text;
            string _units = units.Text;
            string _weight = Weight.Text;
            string _material = Material.Text;
            string _spec = Spec.Text;
            //string _prc=Pi
            string _upperlimit = UpperLimit.Text;
            string _lowerlimit = LowerLimit.Text;
            string _expiry_date = Expiry_date.Text;
            string _code = code.Text;
            string _description = WE_NewsContent.Text;
            if ("".Equals(_product_name))
            {
                msg.Text = "商品名称输入有误！";
                return;
            }
            if ("".Equals(_cost_price))
            {
                msg.Text = "商品成本输入有误！";
                return;
            }
            if ("".Equals(_type_id))
            {
                msg.Text = "商品类型输入有误！";
                return;
            }
            try
            {
                decimal cost = decimal.Parse(_cost_price);
                if ("".Equals(_wholesale_price))
                {
                    _wholesale_price = (cost * 2) + "";
                }
                if ("".Equals(_retail_price))
                {
                    _retail_price = (cost * 3) + "";
                }

            }
            catch (Exception ex)
            {
                return;
            }

            bool isNew = true;
            Leyipai.Model.products node = null;
            if (null == _product_id || "".Equals(_product_id))
            {
                node = new Leyipai.Model.products();
            }
            else
            {
                node = bll.GetModel(int.Parse(_product_id));
                if (null != node)
                    isNew = false;
            }

            if (isNew)
            {
                node = new Leyipai.Model.products();
                node.brand_id = int.Parse(_brand_id);
                node.code = _code;
                node.cost_price = double.Parse(_cost_price);
                node.description = _description;
                node.expiry_date = _expiry_date;
                node.lowerLimit = int.Parse(_lowerlimit);
                node.material = _material;
                node.product_name = _product_name;
                node.retail_price = double.Parse(_retail_price);
                node.spec = _spec;
                node.type_id = int.Parse(_type_id);
                node.units = _units;
                node.upperLimit = int.Parse(_upperlimit);
                node.weight = _weight;
                node.wholesale_price = double.Parse(_wholesale_price);
                node.prc = product_pic.Value;
                bll.Add(node);
                msg.Text = "添加成功";


                //code.Text = "";
                //Cost_price.Text ="";
                //WE_NewsContent.Text = "";
                //Expiry_date.Text = "";
                //LowerLimit.Text ="0";
                //Material.Text ="";
                //Product_Name.Text ="";
                //Retail_Price.Text ="";
                //Spec.Text = "";
                //units.Text = node.units;
                //UpperLimit.Text = "100";
                //Weight.Text = node.weight;
                //Wholesale_price.Text =  "";
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
            else
            {

                node.brand_id = int.Parse(_brand_id);
                node.code = _code;
                node.cost_price = double.Parse(_cost_price);
                node.description = _description;
                node.expiry_date = _expiry_date;
                node.lowerLimit = int.Parse(_lowerlimit);
                node.material = _material;
                node.product_name = _product_name;
                node.retail_price = double.Parse(_retail_price);
                node.spec = _spec;
                node.type_id = int.Parse(_type_id);
                node.units = _units;
                node.upperLimit = int.Parse(_upperlimit);
                node.weight = _weight;
                node.wholesale_price = double.Parse(_wholesale_price);
                node.product_id = int.Parse(_product_id);
                node.prc = product_pic.Value;

                bll.Update(node);
                Panel1.Visible = false;
                Panel2.Visible = true;
                msg.Text = "修改成功";

            }

        }


        /// <summary>
        /// 编辑商品LOAD
        /// </summary>
        /// <param name="productsId"></param>
        protected void editLoad(string productsId)
        {
            Leyipai.Model.products node = bll.GetModel(Int16.Parse(productsId));
            if (null != node)
            {

                Brand_ID.SelectedIndex = Brand_ID.Items.IndexOf(Brand_ID.Items.FindByValue(node.brand_id + ""));
                code.Text = node.code;
                Cost_price.Text = node.cost_price.ToString("#.##");
                WE_NewsContent.Text = node.description;
                Expiry_date.Text = node.expiry_date;
                LowerLimit.Text = node.lowerLimit + "";
                Material.Text = node.material;
                Product_Name.Text = node.product_name;


                Retail_Price.Text = node.retail_price.ToString("#.##");
                Spec.Text = node.spec;
                Type_ID.Value = node.type_id + "";
                Type_text.Text = node.type_name;
                units.Text = node.units;
                UpperLimit.Text = node.upperLimit + "";
                Weight.Text = node.weight;
                Wholesale_price.Text = node.wholesale_price.ToString("#.##");
                Product_ID.Value = node.product_id + "";
                product_pic.Value = node.prc;

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (prc_FileUpload.HasFile)
            {
                string fileContentType = prc_FileUpload.PostedFile.ContentType;
                if (fileContentType == "image/bmp" || fileContentType == "image/gif" || fileContentType == "image/pjpeg")
                {
                    string name = prc_FileUpload.PostedFile.FileName;                  // 客户端文件路径

                    FileInfo file = new FileInfo(name);
                    string random = Leyipai.Common.MyRandom.GenerateCheckCode(10);
                    string fileName = file.Name;                                    // 文件名称
                    string fileName_s = "x_" + random + file.Name;                           // 缩略图文件名称
                    string fileName_sy = "text_" + random + file.Name;                         // 水印图文件名称（文字）
                    string fileName_syp = "water_" + random + file.Name;                       // 水印图文件名称（图片）
                    string webFilePath = Server.MapPath("../../ImgUpload/" + fileName);        // 服务器端文件路径
                    string webFilePath_s = Server.MapPath("../../ImgUpload/" + fileName_s);　　// 服务器端缩略图路径
                    string webFilePath_sy = Server.MapPath("../../ImgUpload/" + fileName_sy);　// 服务器端带水印图路径(文字)
                    string webFilePath_syp = Server.MapPath("../../ImgUpload/" + fileName_syp);　// 服务器端带水印图路径(图片)
                    string webFilePath_sypf = Server.MapPath("../../ImgUpload/png.png");　// 服务器端水印图路径(图片)

                    if (!File.Exists(webFilePath))
                    {
                        try
                        {
                            prc_FileUpload.SaveAs(webFilePath);                                // 使用 SaveAs 方法保存文件
                            AddWater(webFilePath, webFilePath_sy);
                            AddWaterPic(webFilePath, webFilePath_syp, webFilePath_sypf);
                            MakeThumbnail(webFilePath, webFilePath_s, 130, 130, "Cut");     // 生成缩略图方法
                            Label1.Text = "提示：文件“" + fileName + "”成功上传，并生成“" + fileName_s;
                            product_pic.Value = fileName_s;
                        }
                        catch (Exception ex)
                        {
                            Label1.Text = "提示：文件上传失败，失败原因：" + ex.Message;
                        }
                    }
                    else
                    {
                        Label1.Text = "提示：文件已经存在，请重命名后上传";
                    }
                }
                else
                {
                    Label1.Text = "提示：文件类型不符";
                }
            }
        }


        /**/
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）                
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        /**/
        /// <summary>
        /// 在图片上增加文字水印
        /// </summary>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_sy">生成的带文字水印的图片路径</param>
        protected void AddWater(string Path, string Path_sy)
        {
            string addText = "leyp.com";
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            System.Drawing.Font f = new System.Drawing.Font("Verdana", 60);
            System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Green);

            g.DrawString(addText, f, b, 35, 35);
            g.Dispose();

            image.Save(Path_sy);
            image.Dispose();
        }

        /**/
        /// <summary>
        /// 在图片上生成图片水印
        /// </summary>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_syp">生成的带图片水印的图片路径</param>
        /// <param name="Path_sypf">水印图片路径</param>
        protected void AddWaterPic(string Path, string Path_syp, string Path_sypf)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();

            image.Save(Path_syp);
            image.Dispose();
        }




    }
