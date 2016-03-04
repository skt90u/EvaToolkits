using EvaSso.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using OfficeOpenXml;
using System.IO;
using System.Drawing;
using OfficeOpenXml.Style;
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ConsoleApplication10
{
    class Program
    {
        private static string[] columnNames = new string[] { 
            "圖片",
            "名稱",
            "售價",
            "料號",
            "月營收",

            "月數量",
            "上架時間",
            "庫存",
            "預計退運時間數量",
            "備註",
        };

        static void Main(string[] args)
        {
            try
            {
                Program pg = new Program();
                //pg.btnExport_Click();

                string dir = @"C:\Users\Z215\Documents\Visual Studio 2012\Projects\ConsoleApplication10\ConsoleApplication10\";
                string fileName = @"PASR0010.rpt";
                string reportPath = System.IO.Path.Combine(dir, fileName);

                CrystalReport report = new CrystalReport();
                report.DatabaseId = string.Empty; // DEFAULT
                report.FilePath = reportPath;
                report.ReportArguments = new List<object> { "1903128" };
                report.Export(@"C:\1.pdf");


                System.Diagnostics.Process.Start(@"C:\1.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                var b = 0;
            }
        }

        private void aaa()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" SELECT");
            sb.AppendFormat("     (SELECT CLASS    || '-' || CLASS_NAME    FROM BAS_MATERIAL_CLASS WHERE CLASS = A.CLASS AND SUBCLASS = A.SUBCLASS ) AS CLASS,");
            sb.AppendFormat("     (SELECT SUBCLASS || '-' || SUBCLASS_NAME FROM BAS_MATERIAL_CLASS WHERE CLASS = A.CLASS AND SUBCLASS = A.SUBCLASS ) AS SUBCLASS,");
            sb.AppendFormat("     A.CODE,");
            sb.AppendFormat("     A.CHINESE_FULLNAME,");
            sb.AppendFormat("     B.BACKUP_PERIOD AS MONTH,");
            sb.AppendFormat("     B.CURR_QTY,");
            sb.AppendFormat("     B.CURR_AMT");
            sb.AppendFormat(" FROM");
            sb.AppendFormat("     BAS_MATERIAL A,");
            sb.AppendFormat("     INV_STOCK_MONTH_END B");
            sb.AppendFormat(" WHERE");
            sb.AppendFormat("     1 = 1");
            // 1.期間
            sb.AppendFormat("     AND B.BACKUP_PERIOD BETWEEN :MONTH1 AND :MONTH2");
            // 2.商品主類別
            sb.AppendFormat("     AND A.CLASS IN ('G', 'P', 'W', 'Y')");
            // 3.商品次類別
            sb.AppendFormat("     AND ((A.CLASS = 'G' AND A.SUBCLASS = '2') OR");
            sb.AppendFormat("          (A.CLASS = 'P' AND A.SUBCLASS = 'E'))");
            // 4.Kitty類商品 {'Y', 'N', ''}
            sb.AppendFormat("     AND ((A.KITTY_FLAG = 'Y') OR");
            sb.AppendFormat("          (A.KITTY_FLAG = 'N'))");
            // 5.會計科目
            sb.AppendFormat("     AND A.ACCOUNT_CODE BETWEEN :ACCOUNT_CODE1 AND :ACCOUNT_CODE2");
            // 6.庫存數量為零
            sb.AppendFormat("     AND (EXISTS (SELECT * FROM INV_INVENTORY WHERE A.CODE = INV_INVENTORY.CODE AND INV_INVENTORY.CURR_QTY <> 0) OR");
            sb.AppendFormat("          EXISTS (SELECT * FROM INV_INVENTORY WHERE A.CODE = INV_INVENTORY.CODE AND INV_INVENTORY.CURR_QTY =  0))");
            // 7.料號
            sb.AppendFormat("     AND A.CODE IN ('8100005')");
            sb.AppendFormat("     AND A.CODE = B.CODE(+)");
            sb.AppendFormat("     AND B.STORE_NO='AA'");

            sb.ToString();

        }
        private void testSql()
        {
            const string sheetName = "SCRM0014";

            string STND_LOAD_NO = "PRE1601B";
            string FilterType = "ALL";
            string DEPT_DATE1 = "20150111";
            string DEPT_DATE2 = "20150118";

            List<string> CODEs = null;
            CODEs = GetCODEs(STND_LOAD_NO);
            CODEs = FilterOutCODEs(FilterType, CODEs);

            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();

            DataTable dt = GetExportData(CODEs, DEPT_DATE1, DEPT_DATE2);

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        protected void btnExport_Click()
        {
            var fileName = @"C:\1.xlsx";

            FileInfo output = new FileInfo(fileName);
            if (output.Exists)
            {
                output.Delete();
                output = new FileInfo(fileName);
            }

            using (var package = new ExcelPackage())
            {
                WriteExcel(package);

                package.SaveAs(output);
            }
        }

        private void WriteExcel(ExcelPackage package)
        {
            const string sheetName = "SCRM0014";

            string STND_LOAD_NO = "PRE1601B";
            string FilterType = "ALL";
            string DEPT_DATE1 = "20150111";
            string DEPT_DATE2 = "20150118";

            List<string> CODEs = null;
            CODEs = GetCODEs(STND_LOAD_NO);
            CODEs = FilterOutCODEs(FilterType, CODEs);

            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();

            DataTable dt = GetExportData(CODEs, DEPT_DATE1, DEPT_DATE2);

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            if (dt != null)
            {
                var sheet = package.Workbook.Worksheets.Add(sheetName);

                sheet.PrinterSettings.PaperSize = ePaperSize.A4;
                sheet.DefaultRowHeight = 15;
                sheet.DefaultColWidth = 21;

                var count = dt.Rows.Count;

                for(var i=0; i<count; i++)
                {
                    DataRow row = dt.Rows[i];

                    int nCol = (i % 3) + 2; // 由 B 行 開始

                    for(var j=0; j<columnNames.Length; j++)
                    {
                        var columnName = columnNames[j];

                        int nRow = ((int)(i / 3) * 10) + j + 1; // 每三筆資料一列, 每筆資料包含10列, 由第一列開始

                        var value = row[columnName];

                        if (i % 3 == 0)
                        {
                            sheet.Cells[nRow, 1].Value = columnName; // 設定 Title

                            if (j == 0)
                            {
                                sheet.Row(nRow).Height = 115; // 圖片列的高度
                            }
                        }

                        if (j == 0) 
                        {
                            // 處理圖片
                            if(value == null)continue;

                            byte[] buffer = value as byte[];
                            if(buffer == null)continue;

                            byte[] data = (byte[])buffer.Clone();

                            try
                            {
                                using (var ms = new MemoryStream(data))
                                {
                                    ms.Position = 0;

                                    using (var image = Image.FromStream(ms))
                                    {
                                        var pic = sheet.Drawings.AddPicture(Guid.NewGuid().ToString(), image);
                                        pic.SetSize(140, 140); // 設定圖片大小

                                        pic.SetPosition(nRow - 1, 5, nCol - 1, 3); // 定位圖片位置
                                    }
                                }
                            }
                            catch
                            {
                                // 有些圖片轉換會失敗
                                continue;
                            }
                        }
                        else
                        {
                            sheet.Cells[nRow, nCol].Value = value;
                        }
                    }
                }

                // 設定格線
                var excelRowCount = (int)Math.Ceiling((decimal)count / 3) * 10;
                string excelAddress = "A1:D" + excelRowCount.ToString();
                var excelRange = sheet.Cells[excelAddress];
                excelRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                excelRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                excelRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                excelRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                // 參考資料:
                // http://stackoverflow.com/questions/30972175/epplus-how-can-i-assign-border-around-each-cell-after-i-apply-loadfromcollectio
                // http://www.cnblogs.com/sunney/archive/2010/07/28/1786903.html
                // http://epplus.codeplex.com/SourceControl/latest
                // http://forums.asp.net/t/1920859.aspx?Downloading+excel+file
                // http://www.c-sharpcorner.com/UploadFile/0c1bb2/uploading-and-downloading-excel-files-from-database-using-as/
                // http://geekswithblogs.net/KarthickRaju/archive/2014/06/18/download-excel-file-in-asp.net.aspx
                // http://stackoverflow.com/questions/6878525/asp-net-excel-file-download-on-button-click
                // http://no2don.blogspot.com/2013/02/c-aspnet-excel.html
                // https://www.youtube.com/watch?v=K5aPyJ10n8g
            }
        }

        private DataTable GetExportData(List<string> CODEs, string DEPT_DATE1, string DEPT_DATE2)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT");
            sb.Append(@"    H.IMAGE AS 圖片,");
            sb.Append("     A.NAME_CHINESE AS 名稱,");
            sb.Append("     'NT$' || NVL(C.PRICE * D.EXCH_RATE, 0) || ' / US$' || NVL(C.PRICE, 0) AS 售價,");
            sb.Append("     A.CODE AS 料號, ");
            sb.Append("     TO_CHAR(NVL(ROUND(E.DAYS_IN_MONTH / E.DATEDIFF * F.SALES_IN_CASH_INCLUDE_DISCOUNT * D.EXCH_RATE, 0), 0))  AS 月營收,"); //  月營收 = (銷售金額 / 總銷售天數) * 當月天數
            sb.Append("     TO_CHAR(NVL(FLOOR(E.DAYS_IN_MONTH / E.DATEDIFF * F.SALES_IN_UNITS), 0))  AS 月數量,"); // 月銷售量 = (銷售數量 / 總銷售天數) * 當月天數
            sb.Append("     B.REQUEST_DATE AS 上架時間,");
            sb.Append("     TO_CHAR(G.CURR_QTY) AS 庫存,");
            sb.Append("     '' AS 預計退運時間數量,");
            sb.Append("     '' AS 備註");
            sb.Append(" FROM");
            sb.Append("     PRE_PREORDER_MATERIAL A, ");
            sb.Append("     BAS_MATERIAL B, ");
            sb.Append("     (");
            sb.Append("         SELECT ");
            sb.Append("             A.CODE,");
            sb.Append("             B.PRICE ");
            sb.Append("         FROM ");
            sb.Append("             (");
            sb.Append("                 SELECT ");
            sb.Append("                     CODE,");
            sb.Append("                     MAX(SEQ) AS SEQ");
            sb.Append("                 FROM ");
            sb.Append("                     CRW_SCR_COST_PRICE  ");
            sb.Append("                 GROUP BY CODE");
            sb.Append("             ) A,");
            sb.Append("             CRW_SCR_COST_PRICE B ");
            sb.Append("         WHERE ");
            sb.Append("             A.CODE = B.CODE ");
            sb.Append("             AND A.SEQ = B.SEQ");
            sb.Append("     ) C,");
            sb.Append("     (");
            sb.Append("         SELECT ");
            sb.Append("             NVL (EX_RATE, 0) EXCH_RATE");
            sb.Append("         FROM ");
            sb.Append("             CRW_EXCHANGE_RATE");
            sb.Append("         WHERE     ");
            sb.Append("             EXCH_TYPE = 'A'");
            sb.Append("             AND EXCH_DATE = SUBSTR(:DEPT_DATE1,1,6)");
            sb.Append("             AND CUR_DIVIDEND = 'TWD'");
            sb.Append("             AND CUR_DIVISOR = 'USD'    ");
            sb.Append("     ) D,");
            sb.Append("     (");
            sb.Append("         SELECT ");
            sb.Append("             CAST(TO_CHAR(LAST_DAY(TO_DATE( :DEPT_DATE1, 'YYYYMMDD')), 'DD') AS INT) AS DAYS_IN_MONTH,");
            sb.Append("             ABS(TO_DATE(:DEPT_DATE1, 'YYYYMMDD') -  TO_DATE(:DEPT_DATE2, 'YYYYMMDD')) + 1 AS DATEDIFF  ");
            sb.Append("         FROM DUAL");
            sb.Append("     ) E,");
            sb.Append("     (");
            sb.Append("         SELECT ");
            sb.Append("             B.CODE,");
            sb.Append("             NVL (SUM (B.UNIT_PRICE_USD * B.INFLT_DISC * B.ORDER_QTY - B.ORDER_QTY * C.COST), 0) AS SALES_IN_CASH,");
            sb.Append("             NVL (SUM (B.UNIT_PRICE_USD * B.INFLT_DISC * B.ORDER_QTY), 0) AS SALES_IN_CASH_INCLUDE_DISCOUNT,");
            sb.Append("             NVL (SUM (B.ORDER_QTY), 0) AS SALES_IN_UNITS");
            sb.Append("         FROM ");
            sb.Append("             PRE_ORDER_MASTER A, ");
            sb.Append("             PRE_ORDER_DETAILS B, ");
            sb.Append("             CRW_SCR_COST_PRICE C");
            sb.Append("         WHERE     ");
            sb.Append("             A.BASE_DEPT_DATE >= :DEPT_DATE1");
            sb.Append("             AND A.BASE_DEPT_DATE <= :DEPT_DATE2");
            sb.Append("             AND A.ORDER_NO = B.ORDER_NO");
            sb.Append("             AND A.RTN_FLAG = 'S'");
            sb.Append("             AND A.STATUS IN (7, 8, 9)");
            sb.Append("             AND B.CODE = C.CODE(+)");
            sb.Append("             AND ( C.EFF_DATE <= A.BASE_DEPT_DATE AND C.EXP_DATE >= A.BASE_DEPT_DATE)");
            sb.Append("         GROUP BY B.CODE");
            sb.Append("         ORDER BY SALES_IN_CASH DESC    ");
            sb.Append("     ) F,");
            sb.Append("     (");
            sb.Append("         SELECT");
            sb.Append("             A.CODE,");
            sb.Append("             NVL (SUM (NVL (A.CURR_QTY, 0) - DECODE (SIGN (NVL (A.PREN_QTY, 0)), 1, A.PREN_QTY, 0) - NVL (A.H_ONWAY_QTY, 0)), 0) CURR_QTY");
            sb.Append("         FROM");
            sb.Append("             INV_INVENTORY A");
            sb.Append("         WHERE ");
            sb.Append("             A.STORE_NO IN ('APN', 'MANO', 'MANG')");
            sb.Append("         GROUP BY A.CODE");
            sb.Append("     ) G,");
            sb.Append("     (");
            sb.Append("         SELECT CODE, IMAGE FROM PRE_PREORDER_MATERIAL WHERE STATUS = '1'");
            sb.Append("     ) H");
            sb.Append(" WHERE  ");
            sb.AppendFormat("     A.CODE IN ({0})", SqlWhereIn(CODEs));
            sb.Append("     AND A.CODE = B.CODE(+)");
            sb.Append("     AND A.CODE = C.CODE(+)");
            sb.Append("     AND A.CODE = F.CODE(+)");
            sb.Append("     AND A.CODE = G.CODE(+)");
            sb.Append("     AND A.CODE = H.CODE(+)");
            
            string sql = sb.ToString();

            using (var connection = NewConnection)
            {
                var items = connection.Query(sql, new
                {
                    DEPT_DATE1 = DEPT_DATE1,
                    DEPT_DATE2 = DEPT_DATE2,
                });

                var dt = new DataTable();

                foreach (var columnName in columnNames)
                {
                    if (columnName != "圖片")
                    {
                        dt.Columns.Add(columnName, typeof(string));
                    }
                    else
                    {
                        dt.Columns.Add(columnName, typeof(byte[]));
                    }
                }

                foreach (var item in items)
                {
                    var fields = item as IDictionary<string, object>;

                    var row = dt.NewRow();

                    foreach (var columnName in columnNames)
                    {
                        row[columnName] = fields[columnName];
                    }

                    dt.Rows.Add(row);
                }

                return dt;
            }
        }

        

        /// <summary>
        /// SCRM0011 DetailTable 所有料號
        /// </summary>
        /// <returns></returns>
        private List<string> GetCODEs(string STND_LOAD_NO)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT ");
            sb.Append(" 	A.CODE");
            sb.Append(" FROM ");
            sb.Append(" 	CRW_STANDARD_LOAD A, ");
            sb.Append(" 	BAS_MATERIAL B");
            sb.Append(" WHERE ");
            sb.Append(" 	A.CODE = B.CODE ");
            sb.Append(" 	AND A.STND_LOAD_NO = :STND_LOAD_NO");
            sb.Append(" ORDER BY A.CODE");

            string sql = sb.ToString();

            using (var connection = NewConnection)
            {
                var result = connection.Query(sql, new
                {
                    STND_LOAD_NO = STND_LOAD_NO,
                });

                return result.Select(p => Convert.ToString(p.CODE)).Cast<string>().ToList();
            }
        }

        private List<string> FilterOutCODEs(string FilterType, List<string> CODEs)
        {
            string sql = string.Empty;
            string type = FilterType.Trim().ToUpper();

            switch (FilterType)
            {
                case "ALL": // 主類別: All CLASS  IN G,P,W,Y
                    sql = string.Format("SELECT CODE FROM BAS_MATERIAL WHERE CODE IN ({0}) AND CLASS IN ({1})",
                        SqlWhereIn(CODEs),
                        SqlWhereIn(new string[] { "G", "P", "W", "Y" })
                        );
                    break;
                case "G": // G-禮品: CLASS =G 排除 CLASS =G,SUBCLASS=1,7
                    sql = string.Format("SELECT CODE FROM BAS_MATERIAL WHERE CODE IN ({0}) AND CLASS = 'G' AND SUBCLASS NOT IN ('1', '7')",
                        SqlWhereIn(CODEs)
                        );
                    break;

                case "P": // P-化妝品: CLASS =P 排除 CLASS =P,SUBCLASS=1
                    sql = string.Format("SELECT CODE FROM BAS_MATERIAL WHERE CODE IN ({0}) AND CLASS = 'P' AND SUBCLASS NOT IN ('1')",
                        SqlWhereIn(CODEs)
                        );
                    break;

                case "Y": // Y-菸: CLASS =Y 排除 CLASS =Y,SUBCLASS=1
                    sql = string.Format("SELECT CODE FROM BAS_MATERIAL WHERE CODE IN ({0}) AND CLASS = 'Y' AND SUBCLASS NOT IN ('1')",
                        SqlWhereIn(CODEs)
                        );
                    break;

                case "W": // W-酒: CLASS =W 排除 CLASS =W,SUBCLASS=1
                    sql = string.Format("SELECT CODE FROM BAS_MATERIAL WHERE CODE IN ({0}) AND CLASS = 'W' AND SUBCLASS NOT IN ('1')",
                        SqlWhereIn(CODEs)
                        );
                    break;

                case "L": // L-LOGO: CLASS =G &SUBCLASS=7
                    sql = string.Format("SELECT CODE FROM BAS_MATERIAL WHERE CODE IN ({0}) AND CLASS = 'G' AND SUBCLASS = '7'",
                        SqlWhereIn(CODEs)
                        );
                    break;

                case "K": // K-KITTY: 
                    // CLASS =G &SUBCLASS=1, 
                    // CLASS =W &SUBCLASS=1, 
                    // CLASS =P &SUBCLASS=1, 
                    // CLASS =Y &SUBCLASS=1,
                    sql = string.Format("SELECT CODE FROM BAS_MATERIAL WHERE CODE IN ({0}) AND CLASS IN ({1}) AND SUBCLASS = '1'",
                        SqlWhereIn(CODEs),
                        SqlWhereIn(new string[] { "G", "P", "W", "Y" })
                        );
                    break;
                default:
                    return new List<string>();
            }

            using (var connection = NewConnection)
            {
                var result = connection.Query(sql);

                return result.Select(p => p.CODE).Cast<string>().ToList();
            }
        }

        private string SqlWhereIn(IEnumerable<string> array)
        {
            return string.Join(", ", array.Select(p => string.Format("'{0}'", p)));
        }

        private IDbConnection NewConnection
        {
            get
            {
                return DbConnectionFactory.Create("default");
            }
        }
    }
}
