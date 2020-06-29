using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace MTP
{
    public static class DomExcel
    {
        public static void GetSPrintExcel(List<Clients.Client> allclient, int startn, int no)
        {
            IWorkbook wb = new XSSFWorkbook();
            ISheet sh = wb.CreateSheet();
            sh.PrintSetup.PaperSize = 39;//US Std Fanfold 14 7/8 x 11 in
            sh.SetMargin(MarginType.BottomMargin, 0);//下方页边距
            sh.SetMargin(MarginType.TopMargin, 0);//上方页边距
            sh.SetMargin(MarginType.LeftMargin, 0);//左边页边距
            sh.SetMargin(MarginType.RightMargin, 0);//右边页边距
            sh.SetMargin(MarginType.HeaderMargin, 0);//页眉
            sh.SetMargin(MarginType.FooterMargin, 0);//页脚
            int pagen = allclient.Count / 32 + 1;//总页数
            for (int p = startn; p < no + 1; p++)//从第1页起，至最后一页
            {
                IRow rwpg = sh.CreateRow(0);
                ICell rwcell = GetCell(rwpg, 1);
                rwpg.Height = 9;//页码高度
                rwcell.SetCellValue("第" + p + "页");
                for (int x = p - 1; p < 32; p++)
                {
                    IRow Rzcode =  sh.CreateRow(41 * (x) + 1);
                    
                }
            }
        }

        public static ICell GetCell(IRow rw, int index)
        {
            ICell cell = rw.FirstOrDefault(n => n.ColumnIndex == index);
            if (cell == null)
            {
                cell = rw.CreateCell(index);
            }
            return cell;
        }
        public static void GetAPrintExcel(List<Clients.Client> allclient)
        {
            
        }
    }
}
