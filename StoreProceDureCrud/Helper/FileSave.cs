using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace StoreProceDureCrud.Helper
{
    public static class FileSave
    {
        public static string SaveFile(out string fileName, IFormFile file, string localPath)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
            string message = "success";

            var extention = Path.GetExtension(file.FileName);
            if (file.Length > 2000000)
                message = "Select jpg or jpeg or png or pdf less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png or pdf";

            fileName = Path.Combine(localPath, DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }

        public static string SaveAttachment(out string fileName, IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".txt", ".pdf", ".ppt", ".pptx" };
            string message = "success";

            var extention = Path.GetExtension(file.FileName);
            if (file.Length > 2000000)
                message = "Select jpg or jpeg or png or pdf less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png or pdf";

            fileName = Path.Combine("Attachment", DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload attachment";
            }
            return message;
        }

        public static string SaveEmpAttachment(out string fileName, IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
            string message = "success";

            var extention = Path.GetExtension(file.FileName);
            if (file.Length > 2000000)
                message = "Select jpg or jpeg or png or pdf less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png or pdf";

            fileName = Path.Combine("EmpAttachment", DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }

        public static string SaveImage(out string fileName, IFormFile img)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string message = "success";

            var extention = Path.GetExtension(img.FileName);
            if (img.Length > 2000000)
                message = "Select jpg or jpeg or png less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png";

            fileName = Path.Combine("UploadImages", DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }

        public static string SaveImageWithLoacation(out string fileName, string filePath, IFormFile img)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string message = "success";
            var extention = Path.GetExtension(img.FileName);
            fileName = Path.Combine(filePath, DateTime.Now.Ticks + extention);

            if (img.Length > 2000000)
                return "Select jpg or jpeg or png less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                return "Must be jpg or jpeg or png";


            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
            }
            catch
            {
                return "can not upload image";
            }
            return message;
        }
    }
    public static class DayConverter
    {
        public static string DayToDuration(DateTime dueDate, DateTime today)
        {
            int y, m, d;
            string result = "";
            int days = Int32.Parse((today - dueDate).TotalDays.ToString());

            y = days / 365;
            m = (days % 365) / 30;
            d = (days % 365) % 30;

            if (m >= 12 && d < 30)
            {
                y++;
                m -= 12;
            }
            else if (d >= 30 && m < 12)
            {
                m++;
                d -= 30;
            }

            if (y > 0 && m > 0 && d > 0)
            {
                result = String.Format("{0} year {1} month {2} day", y, m, d);
            }
            else if (y > 0 && m > 0 && d == 0)
            {
                result = String.Format("{0} year {1} month", y, m);
            }
            else if (y > 0 && d > 0 && m == 0)
            {
                result = String.Format("{0} year {1} day", y, d);
            }
            else if (m > 0 && d > 0 && y == 0)
            {
                result = String.Format("{0} month {1} day", m, d);
            }
            else if (y > 0 && m == 0 && d == 0)
            {
                result = String.Format("{0} year", y);
            }
            else if (y == 0 && m > 0 && d == 0)
            {
                result = String.Format("{0} month", m);
            }
            else if (y == 0 && m == 0 && d > 0)
            {
                result = String.Format("{0} day", d);
            }
            else if (y == 0 && m == 0 && d == 0)
            {
                result = "0 day";
            }
            else
            {
                result = "Please input correct date";
            }

            return result;
        }
    }
}
