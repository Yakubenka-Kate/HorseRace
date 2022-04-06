using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;

namespace dataReading
{
    internal class Excel
    {
        private static readonly string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private static readonly string folder = Path.Combine(desktopPath, folderName);
        private const string folderName = "User";

        public static void UserExcel(string name, IEnumerable bet)
        {
            const string position = "Position";
            const string horseName = "Horse Name";
            const string coef = "Horse coef";
            const string rate = "Rate";
            const string result = "Result";

            var excel_app = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbook workBook = excel_app.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet workSheet = workBook.ActiveSheet;

            workSheet.Cells[1, "A"] = position;
            workSheet.Cells[1, "B"] = horseName;
            workSheet.Cells[1, "C"] = coef;
            workSheet.Cells[1, "D"] = rate;
            workSheet.Cells[1, "E"] = result;

            string file = Path.Combine(folder, name);

            int row = 2;
            foreach (var line in bet)
            {
                string[] words = line.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                workSheet.Cells[row, "A"] = words[2];
                workSheet.Cells[row, "B"] = words[0];
                workSheet.Cells[row, "C"] = words[1];
                workSheet.Cells[row, "D"] = words[3];
                workSheet.Cells[row, "E"] = words[5];
                
                row++;
            }

            workBook.Close(true, file);
            excel_app.Quit();  
        }
    }
}
