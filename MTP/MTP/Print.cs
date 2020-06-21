using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTP
{
    public static class Print
    {
        public static void PrintMT(List<Clients.Client> allclient)
        {
            DomExcel.GetAPrintExcel(allclient);
        }

        public static void PrintMT(List<Clients.Client> allclient, int startn, int no)
        {
            DomExcel.GetSPrintExcel(allclient,startn,no);
        }
    }
}
