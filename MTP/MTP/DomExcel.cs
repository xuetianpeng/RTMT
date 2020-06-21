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
            for (int p = 0; p < pagen + 1; p++)//从第1页起，至最后一页
            {
                IRow rp= sh.CreateRow(p);
                rp.Height = 12;
            }
        }
        public static void GetAPrintExcel(List<Clients.Client> allclient)
        {
            
        }
    }
}
