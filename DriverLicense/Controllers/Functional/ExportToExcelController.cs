using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ClosedXML.Excel;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DriverLicense.Controllers.Functional
{
    public class ExportToExcelController : Controller
    {
        private readonly IRepository<UsersForms> _contextUsersForms;

        public ExportToExcelController(IRepository<UsersForms> contextUsersForms)
        {
            _contextUsersForms = contextUsersForms;
        }
        
        public IActionResult ExportToExcel()
        {
            var form = JsonConvert.DeserializeObject<List<UsersForms>>((TempData.Peek("list").ToString()));

            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var worksheet = workbook.Worksheets.Add("AdminDriverLicenseTable");
                var currentRow = 1;
                
                worksheet.Cell(currentRow, 1).Value = "Дата добавления";
                worksheet.Cell(currentRow, 2).Value = "Id клиента";
                worksheet.Cell(currentRow,3).Value = "Имя, Фамилия";
                worksheet.Cell(currentRow,4).Value = "Военный билет";
                worksheet.Cell(currentRow,5).SetDataType(XLDataType.Text).Value = "Номер телефона";
                worksheet.Cell(currentRow,6).Value = "Категория прав";
                worksheet.Cell(currentRow,7).Value = "Номер паспорта";

                foreach (var item in form)
                {
                    currentRow++;
                    
                    worksheet.Cell(currentRow, 1).Value = item.Date.ToString();
                    worksheet.Cell(currentRow, 2).Value = item.Users.ID.ToString();
                    worksheet.Cell(currentRow,3).Value = item.FullName;
                    worksheet.Cell(currentRow,4).Value = item.MilitaryTicket;
                    worksheet.Cell(currentRow,5).Value = item.PhoneNumber;
                    worksheet.Cell(currentRow,6).Value = item.Category;
                    worksheet.Cell(currentRow,7).Value = item.PassportID;
                }
                
                var rngTable = worksheet.Range("A1:G" + worksheet.Rows().Count());
                
                rngTable.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.TopBorder = XLBorderStyleValues.Thin;

                worksheet.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "AdminUserFormsTable.xlsx");
                }
            }
        }
    }
}