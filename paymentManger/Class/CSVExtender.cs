using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentManger.Class
{
    static internal class CSVExtender
    {

        static internal void ChangeGenreInCSV(SeriesBander sb,CSV csv)
        {

            for(int i= 0; i < csv.ItemCount; i++)
            {
                ChangeItemGenre(sb, i, csv);
            }
            

        }
        static internal void ChangeItemGenre(SeriesBander sb,int num,CSV csv)
        {

            var sorted_priority = sb.SortedByPriority;
            for(int i = 0; i < sorted_priority.Count(); i++)
            {
                var classifications = sb.classificatoinDatas;
                var classification = classifications[i];
                foreach(var kvp in classification)
                {
                    if (!csv.ExistedColumn(kvp.Key)) return;
                    string original_data = csv.GetCellData(kvp.Key, num);
                    List<string> com_value = kvp.Value.Com_value;

                    switch (kvp.Value.Op)
                    {
                        case "eq":
                            GenreChangerFromDeligate<string>(com_value, (x => original_data == x), csv, num, sorted_priority[i].Base_info.Name);
                            break;
                        case "neq":
                            GenreChangerFromDeligate<string>(com_value, (x => original_data != x), csv, num, sorted_priority[i].Base_info.Name);
                            break;
                        case "in":
                            GenreChangerFromDeligate<string>(com_value, (x => original_data.IndexOf(x) != -1), csv, num, sorted_priority[i].Base_info.Name);
                            break;
                        case "nin":
                            GenreChangerFromDeligate<string>(com_value, (x => original_data.IndexOf(x)==-1), csv, num, sorted_priority[i].Base_info.Name);
                            break;
                        case "le":
                            List<int> plc_le = com_value.ConvertAll(x => int.Parse(x));
                            GenreChangerFromDeligate<int>(plc_le, (x => int.Parse(original_data) < x), csv, num, sorted_priority[i].Base_info.Name);
                            break;
                        case "mo":
                            List<int> plc_mo = com_value.ConvertAll(x => int.Parse(x));
                            if (plc_mo.Where(x => int.Parse(original_data) > x).Count() > 0)
                            GenreChangerFromDeligate<int>(plc_mo, (x => int.Parse(original_data) > x), csv, num, sorted_priority[i].Base_info.Name);
                            break;
                    }

                }
            }

        }
        static private void GenreChangerFromDeligate<T>(List<T> list,Func<T,bool> func,CSV csv,int num,string name)
        {
            if (list.Where(func).Count() > 0){
                csv.EditItemValue("ジャンル", num, name);
            }
            return;
        }

    }
}
