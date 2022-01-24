using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace paymentManger
{
    internal class CSV
    {

        private IDictionary<string,List<string>> csv_data = new Dictionary<string,List<string>>();
        private string[] keys = null;

        internal CSV(params string[] column_name)
        {

            foreach (string dic_key in column_name)
            {

                csv_data.Add(dic_key, new List<string>());

            }
            Updatekeys();

        }


        [Obsolete("テストを実施していない関数です。不具合が発生する可能性があります")]
        internal void EditItemValue(int column_number,int row_number,string value)
        {
            EditItemValue(csv_data.Keys.ToArray()[column_number],row_number,value);
        }
        internal void EditItemValue(string column_name,int row_number,string value)
        {

            csv_data[column_name][row_number] = value;
            return;

        }

        internal void Regist_Row_data(params string[] data_line)
        {

            for(int i = 0; keys.Length > i; i++)
            {

                csv_data[keys[i]].Add(data_line[i]);
            
            }
            return;

        }

        internal void Regist_New_Column(string column_name, string ini = "")
        {

            int items_count = this.ItemCount;
            csv_data.Add(column_name, new List<string>());
            for(int i = 0; i < items_count; i++)
            {

                csv_data[column_name].Add(ini);

            }
            Updatekeys();

        }

        internal void Delete_Row_data(int count)
        {

            for(int i=0;keys.Length > i; i++)
            {
                csv_data[keys[i]].RemoveAt(count);
            }
            return;


        }
        internal void Delete_Column_data(int num)
        {
            Delete_Column_data(keys[num]);
        }
        internal void Delete_Column_data(string name)
        {
            csv_data.Remove(name);
            Updatekeys();
            return;
        }

        internal void TExtract_Column_data(params string[] column_name)
        {
            this.csv_data = extractItemFromColumnRegexAsDictionary(column_name);
            Updatekeys();
        }


        internal IDictionary<string, List<string>> extractItemFromColumnRegexAsDictionary(params string[] column_regex)
        {

            var csv_data_extracted = (from x in csv_data where (from regex in column_regex where Regex.IsMatch(x.Key, regex) select regex).Count()>0 select x).ToDictionary(x => x.Key, x => x.Value);

            return csv_data_extracted;

        }

        /// <summary>
        /// 行数を指定して読み込む。
        /// 0から数える
        /// 要テスト関数
        /// </summary>
        /// <param name="row_num"></param>
        /// <returns></returns>
        internal IDictionary<string, List<string>> extractItemFromRowNumberAsDictionary(params int[] row_num)
        {

            var csv_data_extracted = (from x in csv_data select x).ToDictionary(x => x.Key, x => x.Value.Where((name,index) => row_num.Contains(index)).ToList());

            return csv_data_extracted;

        }
        internal string[] GetItemFromRowNumber(int num)
        {

            var row_data = extractItemFromRowNumberAsDictionary(num);
            string[] item_content = new string[keys.Length];
            int i = 0;
            foreach(List<string> value in row_data.Values)
            {
                item_content[i] = value[0];
                i++;
            }
            return item_content;

        }

        internal string GetCellData(int column_num,int row_num)
        {
            return GetCellData(csv_data.Keys.ToArray()[column_num],row_num);
        }
        internal string GetCellData(string column_name,int row_number)
        {

            return csv_data[column_name][row_number];

        }
        internal string[] GetRowData(string column_name)
        {
            return csv_data[column_name].ToArray();
        }
        internal void RenameTitle(string old_regex,string new_name)
        {
            var name = (from x in csv_data where Regex.IsMatch(x.Key, old_regex) select x.Key).ToArray()[0];

            var value_list = csv_data[name];
            csv_data[name].CopyTo(value_list.ToArray());
            csv_data.Remove(name);
            csv_data.Add(new_name, value_list.ToList());
            Updatekeys();
        }
        internal CSV Duplicate()
        {

            CSV dup_obj = new CSV(keys);
            for(int i = 0; i < this.ItemCount; i++)
            {
                var item_datas = GetItemFromRowNumber(i);
                dup_obj.Regist_Row_data(item_datas);

            }
            return dup_obj;
        }

        private void Updatekeys()
        {
            keys = csv_data.Keys.ToArray();
            return;
        }

        public void ToFile(string save_path)
        {

            StreamWriter sw = new StreamWriter(save_path);

            sw.Write(this.ToString());
            sw.Close();

        }
        public override string ToString()
        {
            string str_data = "";

            str_data = String.Join(",", keys)+Environment.NewLine;

            for (int i = 0; i < this.ItemCount; i++)
            {
                List<string> line_data = csv_data.Values.SelectMany(x => x.Where((name, index) => index == i)).ToList();

                str_data += String.Join(",", line_data)+Environment.NewLine;
            }
            return str_data;
        }

        public override bool Equals(object obj)
        {

            CSV c1 = (CSV)obj;
            CSV c2 = this;

            List<string>[][] values = new List<string>[2][]
            {
                c1.Values.ToArray(),
                c2.Values.ToArray()
            };
            List<string>[] keys = new List<string>[2]
            {
                c1.Keys.ToList(),
                c2.keys.ToList()
            };
            if (!keys[0].SequenceEqual(keys[1]))
            {
                return false;
            }
            for (int i = 0; i < keys[0].Count; i++)
            {

                if (!values[0][i].SequenceEqual(values[1][i]))
                {
                    return false;
                }

            }
            return true;

        }
        public static bool Equals(CSV c1,CSV c2)
        {
            return c1.Equals(c2);
        }

        internal delegate bool Condition(string key,string values);
        internal delegate void Function(CSV csv);
        internal void Extract_condition(Condition del)
        {
            foreach(string key in csv_data.Keys)
            {
                int line_num = 0;
                string[] value_bac = new string [this.ItemCount];
                csv_data[key].CopyTo(value_bac);
                foreach(string value in value_bac)
                {
                    if (!del(key, value))
                    {
                        this.Delete_Row_data(line_num);
                        line_num--;
                    }
                    line_num++;
                }
            }
        }
        internal void do_func(Function func)
        {

            func(this);

        }
        internal int ItemCount
        {
            get { return csv_data[csv_data.First().Key].Count; }
        }
        private ICollection<List<string>> Values
        {
            get { return csv_data.Values; }
        }
        private ICollection<string> Keys
        {
            get { return csv_data.Keys; }
        }
        public ICollection<string> Title
        {
            get { return csv_data.Keys; }
        }

    }

}
