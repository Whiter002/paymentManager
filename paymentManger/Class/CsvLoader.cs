using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace paymentManger
{
    internal static class CsvLoader
    {

        static internal CSV LoadCSVFile(string path,params string[] ignore_strs)
        {
            if (File.Exists(path)){

                StreamReader sr = new StreamReader(path);

                string line = sr.ReadLine();

                foreach (string replace_str in ignore_strs)
                {
                    line = line.Replace(replace_str, "");
                }
                CSV csv = new CSV(line.Split(','));
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    foreach(string replace_str in ignore_strs)
                    {
                        line = line.Replace(replace_str,"");
                    }
                    csv.Regist_Row_data(line.Split(','));

                }
                return csv;
            }
            else
            {

                //警告
                MessageBox.Show($"指定されたパスにファイルが存在しません\r\nPath:{path}", "読み込みエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new CSV();

            }
        }


    }
}
