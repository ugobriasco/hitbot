using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace pallet_demo
{
    class ConfigHelp
    {

        private static string path = "config.txt";

        public ConfigHelp()
        {

        }
        public static string read_config_file()
        {

            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            String config="";
            while ((line = sr.ReadLine()) != null)
            {
                // Console.WriteLine(line.ToString());
                config += line;
            }
            sr.Close();

            return config;

        }
        public static void save_config_file(string mes)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(mes);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
    }
}
