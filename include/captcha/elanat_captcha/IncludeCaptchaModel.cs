using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class IncludeCaptchaModel
    {
        public void SetValue()
        {
            DateTime DateTimeNow = DateTime.Now;

            Random rand = new Random();

            // Set Captcha Delay
            int CaptchaDelay = int.Parse(ElanatConfig.GetNode("delay/captcha").Attributes["value"].Value);
            System.Threading.Thread.Sleep(CaptchaDelay * 1000);


            // Set Captcha Value
            XmlNode node = StaticObject.ConfigDocument.SelectSingleNode("elanat_root/security");
            int CaptchaWidth = int.Parse(node["captcha_width"].Attributes["value"].Value);
            int CaptchaHeight = int.Parse(node["captcha_height"].Attributes["value"].Value);
            int CaptchaFontSize = int.Parse(node["captcha_font_size"].Attributes["value"].Value);
            int CaptchaNoise = int.Parse(node["captcha_noise"].Attributes["value"].Value);
            int CaptchaCharacterCount = rand.Next(int.Parse(node["captcha_character_count"].Attributes["from"].Value), int.Parse(node["captcha_character_count"].Attributes["to"].Value));
            int CaptchaRotateTransform = int.Parse(node["captcha_rotate_transform"].Attributes["value"].Value);

            string RandomImagePhysicalName = "img" + rand.Next(100000, 999999).ToString();
            string CaptchaFont = node["captcha_font"].Attributes["value"].Value;

            Bitmap img = new Bitmap(CaptchaWidth, CaptchaHeight);

            Graphics g = Graphics.FromImage(img);

            string RandomImage = "";
            float Xposition = 0;
            float Yposition = 0;
            while (CaptchaCharacterCount > 0)
            {
                string CaptchaCharacter = node["captcha_character"].InnerText;

                string RandomCharacter = (CaptchaCharacter[rand.Next(0, CaptchaCharacter.Length - 1)]).ToString();

                Xposition += CaptchaFontSize + rand.Next(0, CaptchaFontSize);
                Yposition = rand.Next(0, (CaptchaHeight - CaptchaFontSize) / 2);

                int RandomRotateTransform = rand.Next(CaptchaRotateTransform * -1, CaptchaRotateTransform);
                g.RotateTransform(RandomRotateTransform);

                int Alpha = 30 * rand.Next(1, 8);
                int Gray = 30 * rand.Next(1, 8);

                g.DrawString(RandomCharacter, new Font(CaptchaFont, CaptchaFontSize, FontStyle.Regular), new SolidBrush(Color.FromArgb(Alpha, Gray, Gray, Gray)), Xposition, Yposition);
                RandomImage += RandomCharacter;
                g.RotateTransform(RandomRotateTransform * -1);

                CaptchaCharacterCount--;
            }


            // Set Noise
            Random rimg = new Random();
            for (int x = 0; x < CaptchaWidth; x++)
            {
                if (CaptchaNoise > rand.Next(0, 100))
                {
                    int y = 0;
                    while (y < CaptchaHeight)
                    {
                        int Alpha = 8 * rimg.Next(0, 30);
                        int Gray = 8 * rimg.Next(0, 30);
                        img.SetPixel(x, y, Color.FromArgb(Alpha, Gray, Gray, Gray));

                        int x2 = rand.Next(0, CaptchaWidth);
                        int y2 = rand.Next(0, CaptchaHeight);
                        img.SetPixel(x2, y2, Color.FromArgb(Alpha, Gray, Gray, Gray));

                        y++;
                    }
                }
            }


            HttpContext.Current.Session.Add("el_captcha", RandomImage);

            HttpContext.Current.Response.ContentType = "image/png";

            img.Save(HttpContext.Current.Response.OutputStream, ImageFormat.Png);


            // Set Captcha Repeat Time
            if (ElanatConfig.GetNode("security/captcha_repeat_time").Attributes["active"].Value == "true")
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] ImageContent = ms.ToArray();
                HttpContext.Current.Session["el_image_content"] = ImageContent;

                HttpContext.Current.Session.Add("el_last_captcha_time", DateTimeNow.ToString());
            }

            img.Dispose();
        }
    }
}