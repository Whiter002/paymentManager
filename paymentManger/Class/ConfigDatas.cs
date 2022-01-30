using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Windows.Forms;
using System.Text.Encodings.Web;

namespace paymentManger
{
    static internal class ConfigDatas
    {
        //分類情報などのコンフィグデータをここから呼び出すために作られたクラスです。
        #region DebugOnlyFunctoins
#if DEBUG
        static internal void Json_Test()
        {

        IDictionary<string, string> test = new Dictionary<string, string>()
            {
                {"Test1","are"},
                {"Test2","rate"},
                {"Test3","ate"},
                {"Test4","tar"},
                {"Test5","ter"}
            };

            string test_str = JsonSerializer.Serialize(test);
            var options = new JsonSerializerOptions
            {
                // JavaScriptEncoder.Createでエンコードしない文字を指定するのも可
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                // 読みやすいようインデントを付ける
                WriteIndented = true
            };


            string json_str = Read_Json(0);
            var load_json1 = JsonSerializer.Deserialize<SeriesDatas>(json_str, options);

            json_str = Read_Json(1);
            var load_json2 = JsonSerializer.Deserialize<Dictionary<string,SeriesClassificationData>>(json_str,options);


        }
        static private string Read_Json(int file_num)
        {
            string[] path = new string[] {
                Path.Combine(Application.StartupPath, @"..\..\..\..\..\..",@"data\json_test","define_series_test.json"),
                Path.Combine(Application.StartupPath, @"..\..\..\..\..\..",@"data\json_test","difine_classification_series_test.json"),
                Path.Combine(Application.StartupPath, @"..\..\..\..\..\..",@"data\json_test","simple_test.json")
            };
            StreamReader sr = new StreamReader(path[file_num]);
            string json = sr.ReadToEnd();
            sr.Close();
            return json;

        }
#endif
        #endregion
    }
}
