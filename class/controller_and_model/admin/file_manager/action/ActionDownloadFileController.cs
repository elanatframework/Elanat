using CodeBehind;
using System.IO;

namespace Elanat
{
    public partial class ActionDownloadFileController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["file_path"]))
            {
                Write("false");
                return;
            }

            if (!Path.GetFileName(context.Request.Query["file_path"].ToString()).Contains('.'))
            {
                Write("false");
                return;
            }


            var FilePath = StaticObject.ServerMapPath(context.Request.Query["file_path"].ToString());
            long FileSize = new FileInfo(FilePath).Length;
            var response = context.Response;
            response.Headers.Add("Content-Length", FileSize.ToString());
            response.ContentType = "application/octet-stream";
            response.Headers.Add("Content-Disposition", $"attachment; filename=\"{Path.GetFileName(FilePath)}\"");
            using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var bufferSize = 64 * 1024; // 64KB
                var buffer = new byte[bufferSize];
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    try
                    {
                        response.Body.WriteAsync(buffer, 0, bytesRead);
                        response.Body.FlushAsync();
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
            }
        }
    }
}