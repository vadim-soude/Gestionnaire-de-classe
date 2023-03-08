using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Threading;

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
                    Filter = "Classeur OpenDocument (*.ods)|*.ods*|Classeur Excel (*.xslx)|*.xlsx*",
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
                //create new line
                Console.Write("\r\n");
                for (int j = 1; j <= cols; j++)
                {
                    //write the console
                    if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                        Console.Write(excelRange.Cells[i, j].Value2.ToString() + "\t");
                }
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
