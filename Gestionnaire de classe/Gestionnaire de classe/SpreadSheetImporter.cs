using Microsoft.Office.Interop.Excel;

namespace Gestionnaire_de_classe
{
    class SpreadSheetImporter
    {
        public SpreadSheetImporter()
        {

            string selectedPath = "";
            CancellationTokenSource tokenSource = new();

            Thread t = new(() =>
            {
                LongRunningOperation(tokenSource.Token);

                OpenFileDialog saveFileDialog1 = new()
                {
                    Filter = "Classeur (*.ods,*.xslx)|*.ods* , *.xlsx*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selectedPath = saveFileDialog1.FileName;
                }

            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            tokenSource.Cancel();
            t.Join();
            tokenSource.Dispose();

            //Create COM Objects.
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }

            Workbook excelBook = excelApp.Workbooks.Open(selectedPath);

            _Worksheet excelSheet = excelBook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;

            for (int i = 1; i <= rows; i++)
            {
                Student student = new(excelRange.Cells[i, 1].Value2.ToString(), excelRange.Cells[i, 2].Value2.ToString(), excelRange.Cells[i, 3].Value2.ToString());
                Manager.students.Add(student);
            }

            //after reading, relaase the excel project
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        static void LongRunningOperation(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                Thread.Sleep(500);
            }
        }
    }
}
