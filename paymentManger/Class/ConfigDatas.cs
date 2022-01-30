using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Windows.Forms;

namespace paymentManger
{
    static internal class ConfigDatas
    {
        //分類情報などのコンフィグデータをここから呼び出すために作られたクラスです。
        #region DebugOnlyFunctoins
#if DEBUG
        static internal void Json_Test() {


            string json_str = Read_Json();
            var json = JsonSerializer.Deserialize<Dictionary<string,string>>(jsonstr);
            foreach (var item in json)
            {
                System.Diagnostics.Debug.Print("{0}", item.Key);
                System.Diagnostics.Debug.Print("{0}", item.Value);
            }

        }
        static private string Read_Json(int file_num)
        {
            string[] path = new string[] {
                Path.Combine(Application.StartupPath, @"..\..\..\..\..\..",@"data\json_test","define_series_test.json"),
                Path.Combine(Application.StartupPath, @"..\..\..\..\..\..",@"data\json_test","difine_classification_series_test.json")
            };
            StreamReader sr = new StreamReader("");
            string json = sr.ReadToEnd();
            sr.Close();
            return json;

        }
#endif
        #endregion
    }
}
