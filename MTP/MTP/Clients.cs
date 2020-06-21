using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MTP
{
    public static class Clients
    {

        public struct MTType
        {
            public int clientNo;
            public int pageNo;
            public int mttype;
        }
        public struct Client
        {
            public string Z_Code;
            public string C_Address;
            public string C_NO;
            public string C_Name;
        }
        public struct Client4
        {
            public Client C1;
            public Client C2;
            public Client C3;
            public Client C4;
        }
        

        public static List<Client> Getclient(string MTFilePath)
        {
            List<Client> AllClient=new List<MTP.Clients.Client>();
            //AllClient.Clear();
            byte[] ba = File.ReadAllBytes(MTFilePath);
            int st = ba.Length / 640 * 640;//整页数的byte文件
            int et = ba.Length - st;//结尾数量
            string Endstring = System.Text.Encoding.Default.GetString(ba, st, et);//结尾文字
            for (int i = 0; i < ba.Length / 640; i++)
            {
                Client4 cs = GetClientsInfo(System.Text.Encoding.Default.GetString(ba, i * 640, 640));
                AllClient.Add(cs.C1);
                AllClient.Add(cs.C2);
                AllClient.Add(cs.C3);
                AllClient.Add(cs.C4);
            }
            return AllClient;
        }

        public static Client4 GetClientsInfo(string C4)
        {
            byte[] b4 = Encoding.Default.GetBytes(C4);
            Client4 cs = new Client4();
            cs.C1.Z_Code = Encoding.Default.GetString(b4, 0, 40).TrimStart().TrimEnd();
            cs.C2.Z_Code = Encoding.Default.GetString(b4, 40, 40).TrimStart().TrimEnd();
            cs.C3.Z_Code = Encoding.Default.GetString(b4, 80, 40).TrimStart().TrimEnd();
            cs.C4.Z_Code = Encoding.Default.GetString(b4, 120, 40).TrimStart().TrimEnd();
            cs.C1.C_Address = Encoding.Default.GetString(b4, 160, 40).TrimStart().TrimEnd();
            cs.C2.C_Address = Encoding.Default.GetString(b4, 200, 40).TrimStart().TrimEnd();
            cs.C3.C_Address = Encoding.Default.GetString(b4, 240, 40).TrimStart().TrimEnd();
            cs.C4.C_Address = Encoding.Default.GetString(b4, 280, 40).TrimStart().TrimEnd();
            cs.C1.C_NO = Encoding.Default.GetString(b4, 320, 40).TrimStart().TrimEnd();
            cs.C2.C_NO = Encoding.Default.GetString(b4, 360, 40).TrimStart().TrimEnd();
            cs.C3.C_NO = Encoding.Default.GetString(b4, 400, 40).TrimStart().TrimEnd();
            cs.C4.C_NO = Encoding.Default.GetString(b4, 440, 40).TrimStart().TrimEnd();
            cs.C1.C_Name = Encoding.Default.GetString(b4, 480, 40).TrimStart().TrimEnd();
            cs.C2.C_Name = Encoding.Default.GetString(b4, 520, 40).TrimStart().TrimEnd();
            cs.C3.C_Name = Encoding.Default.GetString(b4, 560, 40).TrimStart().TrimEnd();
            cs.C4.C_Name = Encoding.Default.GetString(b4, 600, 40).TrimStart().TrimEnd();
            return cs;
        }

        

    }
}
