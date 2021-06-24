using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace _24062021.Controllers
{
    public class RookieController : Controller
    {
        static List<PersonModel> members = new List<PersonModel>{
            new PersonModel{
                FirstName = "A",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "male",
                DateOfBirth = new DateTime(1992,01,02),
            },
            new PersonModel{
                FirstName = "B",
                LastName = "Nguyen Van",
                BirthPlace = "Quang Ninh",
                Gender = "Male",
                DateOfBirth = new DateTime(1992,01,01),
            },
            new PersonModel{
                FirstName = "C",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "male",
                DateOfBirth = new DateTime(1992,01,01),
            },
            new PersonModel{
                FirstName = "D",
                LastName = "Nguyen Van",
                BirthPlace = "Ha Noi",
                Gender = "Female",
                DateOfBirth = new DateTime(2001,12,02),
            },
            new PersonModel{
                FirstName = "E",
                LastName = "Nguyen Van",
                BirthPlace = "ha noi",
                Gender = "Male",
                DateOfBirth = new DateTime(1993,07,02),
            },
            new PersonModel{
                FirstName = "F",
                LastName = "Nguyen Van",
                BirthPlace = "Ha Noi",
                Gender = "Male",
                DateOfBirth = new DateTime(2000,01,02),
            },
            new PersonModel{
                FirstName = "G",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "Female",
                DateOfBirth = new DateTime(2000,01,02),
            },
        };

        public IActionResult MaleList()
        {
            var maleList = members.Where(x => x.Gender.Equals("Male", StringComparison.CurrentCultureIgnoreCase)).ToList();
            return Json(maleList);
        }
        public IActionResult OldestPerson()
        {
            return Json(members.Max());
        }
        public IActionResult FullNameList()
        {
            var fullNameList = members.Select(x => x.FullName);
            return Json(fullNameList);
        }
        public IActionResult AgeEqualPersonList(int yearOfBirth)
        {
            var equalList = members.Where(x => x.DateOfBirth.Year == yearOfBirth).ToList();
            return Json(equalList);
        }
        public IActionResult AgeGreaterPersonList(int yearOfBirth)
        {
            var greaterList = members.Where(x => x.DateOfBirth.Year > yearOfBirth).ToList();
            return Json(greaterList);
        }
        public IActionResult AgeLessPersonList(int yearOfBirth)
        {
            var lessList = members.Where(x => x.DateOfBirth.Year < yearOfBirth).ToList();
            return Json(lessList);
        }

        public IActionResult AgePersonGroup(string type, int yearOfBirth)
        {
            switch (type)
            {
                case "equal":
                    return RedirectToAction("AgeEqualPersonList", new { yearOfBirth });
                case "greater":
                    return RedirectToAction("AgeGreaterPersonList", new { yearOfBirth });
                case "less":
                    return RedirectToAction("AgeLessPersonList", new { yearOfBirth });
                default: return new EmptyResult();
            }
        }
        public IActionResult Export()
        {
            DataTable Dt = new DataTable();
            Dt.Columns.Add("FirstName", typeof(string));
            Dt.Columns.Add("LastName", typeof(string));
            Dt.Columns.Add("Gender", typeof(string));
            Dt.Columns.Add("DateOfBirth", typeof(DateTime));
            Dt.Columns.Add("PhoneNumber", typeof(string));
            Dt.Columns.Add("BirthPlace", typeof(string));
            Dt.Columns.Add("Age", typeof(int));

            foreach (var data in members)
            {
                DataRow row = Dt.NewRow();
                row[0] = data.FirstName;
                row[1] = data.LastName;
                row[2] = data.Gender;
                row[3] = data.DateOfBirth;
                row[4] = data.PhoneNumber;
                row[5] = data.BirthPlace;
                row[6] = data.Age;
                Dt.Rows.Add(row);

            }

            var memoryStream = new MemoryStream();

            using (var excelPackage = new ExcelPackage(memoryStream))
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
                ExcelRangeBase excelRangeBase = worksheet.Cells["A1"].LoadFromDataTable(Dt, true, TableStyles.None);
                worksheet.Cells["A1:AN1"].Style.Font.Bold = true;
                worksheet.DefaultRowHeight = 18;
                int colNumber = 1;
                foreach (DataColumn col in Dt.Columns)
                {
                    if (col.DataType == typeof(DateTime))
                    {
                        worksheet.Column(colNumber).Style.Numberformat.Format = "yyyy-MM-dd";
                    }
                    colNumber++;
                }
                worksheet.Cells["A1:K20"].AutoFitColumns();
                worksheet.DefaultColWidth = 20;
                return File(excelPackage.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }

        }

    }
}
