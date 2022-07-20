using OfficeOpenXml;
using OfficeOpenXml.Style;

public class ExcelConnector : ILocalConnection
{
    public async Task SaveExcelAsync(string BatchName, string GradeName, Section section, Period period)//refactored and tested
    {
        if (GlobalTools.Excel)
        {
            using (var package = new ExcelPackage(new FileInfo(Path.Combine(GlobalTools.ExcelPath, $"{BatchName} {GradeName} {section.Teachers[0].Name}.xlsx"))))
            {
                int i = 1;
                string sectionName = section.Name.ToString();
                ExcelWorksheet? worksheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == sectionName);
                if (worksheet is null) worksheet = package.Workbook.Worksheets.Add(sectionName);
                while (worksheet.Cells["A" + i].Value is not null)
                {
                    i++;
                }
                worksheet.Cells[i, 1].Value = $"{period.StartTime.ToShortDateString()} {BatchName} {GradeName} {sectionName} " +
                    $"{period.Subject} {period.StartTime.ToShortTimeString()} - {period.EndTime.ToShortTimeString()}";
                worksheet.Cells[i, 1, i, 7].Merge = true;
                worksheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Row(i).Style.Font.Size = 16;
                worksheet.Cells["A" + i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A" + i].Style.Fill.BackgroundColor.SetColor(ExcelIndexedColor.Indexed35);
                worksheet.Cells["A" + i].Style.Font.Color.SetColor(System.Drawing.Color.Blue);
                worksheet.Cells[i, 1, i, 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[i, 1, i, 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Column(4).Style.Numberformat.Format = "h:mm:ss";
                worksheet.Column(5).Style.Numberformat.Format = "h:mm:ss";
                worksheet.Column(6).Style.Numberformat.Format = "h:mm:ss";
                i++;
                var range = worksheet.Cells["A" + i].LoadFromCollection(period.Attendees, true);
                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                range.AutoFitColumns();
                worksheet.Cells[i, 1, i, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[i, 1, i, 7].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Green);
                worksheet.Cells[i, 1, i, 7].Style.Font.Color.SetColor(System.Drawing.Color.White);
                worksheet.Cells[i, 1, i, 7].Style.Font.Size = 12;
                await package.SaveAsync();
            }
        }
    }
}