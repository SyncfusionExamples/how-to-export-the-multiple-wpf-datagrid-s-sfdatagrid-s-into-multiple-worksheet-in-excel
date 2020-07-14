using Microsoft.Win32;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Converter;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SfDataGridDemo
{
    public static class Commands
    {
        static Commands()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfDataGrid), new CommandBinding(ExportToExcel, OnExecuteExportToExcel, OnCanExecuteExportToExcel));
        }


        #region ExportToExcel Command

        public static RoutedCommand ExportToExcel = new RoutedCommand("ExportToExcel", typeof(SfDataGrid));

        private static void OnExecuteExportToExcel(object sender, ExecutedRoutedEventArgs args)
        {
            var dataGrid1 = args.Source as SfDataGrid;
            var dataGrid2 = args.Parameter as SfDataGrid;
            if (dataGrid1 == null) return;
            if (dataGrid2 == null) return;
            try
            {
                var options = new ExcelExportingOptions();
                options.ExcelVersion = ExcelVersion.Excel2010;
                options.ExportingEventHandler = ExportingHandler;
                ExcelEngine excelEngine = new ExcelEngine();
                IWorkbook workBook = excelEngine.Excel.Workbooks.Create();
                dataGrid1.ExportToExcel(dataGrid1.View, options, workBook.Worksheets[0] );
                dataGrid2.ExportToExcel(dataGrid2.View, options, workBook.Worksheets[1]);
                // Saving the workbook.
                workBook.SaveAs("sample.xlsx");
                    //Message box confirmation to view the created spreadsheet.
               if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                                        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                   //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                   System.Diagnostics.Process.Start("sample.xlsx");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void ExportingHandler(object sender, GridExcelExportingEventArgs e)
        {
            if (e.CellType == ExportCellType.HeaderCell)
            {
               
            }
            else if (e.CellType == ExportCellType.RecordCell)
            {
            }
        }

        private static void OnCanExecuteExportToExcel(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
        #endregion
    }
}
