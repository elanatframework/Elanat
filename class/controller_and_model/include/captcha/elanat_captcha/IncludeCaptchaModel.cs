using CodeBehind;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace Elanat
{
    public partial class IncludeElanatCaptchaModel : CodeBehindModel
    {
        public void SetValue(HttpContext context)
        {
            DateTime DateTimeNow = DateTime.Now;

            Random rand = new Random();

            // Set Captcha Delay
            int CaptchaDelay = int.Parse(ElanatConfig.GetNode("delay/captcha").Attributes["value"].Value);
            Thread.Sleep(CaptchaDelay * 1000);


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

            Image<Rgba32> img = new Image<Rgba32>(CaptchaWidth, CaptchaHeight, Color.White);

            // Set Random Text
            string RandomImage = "";
            float Xposition = 0;
            float Yposition = 0;
            string CaptchaCharacter = node["captcha_character"].InnerText;

            FontCollection collection = new FontCollection();
            FontFamily family = collection.Add(StaticObject.ServerMapPath(StaticObject.SitePath + "include/font/" + CaptchaFont + ".ttf"));
            Font font = family.CreateFont(CaptchaFontSize, FontStyle.Regular);

            while (CaptchaCharacterCount > 0)
            {
                string RandomCharacter = (CaptchaCharacter[rand.Next(0, CaptchaCharacter.Length - 1)]).ToString();

                Xposition += CaptchaFontSize + rand.Next(0, CaptchaFontSize);
                Yposition = rand.Next(0, (CaptchaHeight - CaptchaFontSize) / 2);

                int RandomRotateTransform = rand.Next(CaptchaRotateTransform * -1, CaptchaRotateTransform);

                float Alpha = rand.Next(100 - CaptchaNoise, 255);
                int Gray = 30 * rand.Next(1, 8);

                img.Mutate(x =>
                {
                    x.DrawText(new DrawingOptions { Transform = Matrix3x2Extensions.CreateRotationDegrees(RandomRotateTransform) }, RandomCharacter, font, Color.FromRgba((byte)Gray, (byte)Gray, (byte)Gray, (byte)Alpha), new PointF(Xposition, Yposition));
                });

                RandomImage += RandomCharacter;
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
                        float Alpha = rimg.Next(0, 100) / 100;
                        int Gray = 8 * rimg.Next(0, 30);
                        img[x, y] = new Rgba32(Gray, Gray, Gray, Alpha);

                        int x2 = rand.Next(0, CaptchaWidth);
                        int y2 = rand.Next(0, CaptchaHeight);
                        img[x2, y2] = new Rgba32(Gray, Gray, Gray, Alpha);

                        y++;
                    }
                }
            }

            context.Session.SetString("el_captcha", RandomImage);

            context.Response.ContentType = "image/png";

            using (MemoryStream stream = new MemoryStream())
            {
                img.SaveAsPng(stream);

                context.Response.Body.WriteAsync(stream.ToArray());
                context.Response.Body.FlushAsync();
            }


            // Set Captcha Repeat Time
            if (ElanatConfig.GetNode("security/captcha_repeat_time").Attributes["active"].Value == "true")
            {
                MemoryStream ms = new MemoryStream();
                img.SaveAsPng(ms);
                byte[] ImageContent = ms.ToArray();
                context.Session.Set("el_image_content", ImageContent);

                context.Session.SetString("el_last_captcha_time", DateTimeNow.ToString());
            }

            img.Dispose();
        }
    }
}