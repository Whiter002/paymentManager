using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace paymentManger.Class
{
    internal class SeriesBander
    {
        #region 構造体
        public struct BasedSeriesData
        {
            public string Name { get; set; }
            public int View_num { get; set; }
            public int priority { get; set; }
            internal BasedSeriesData Duplicate()
            {
                BasedSeriesData copy = new BasedSeriesData();
                copy.Name = this.Name;
                copy.priority = this.priority;
                copy.View_num = this.View_num;
                return copy;
            }
        };
        public struct ClassificationData
        {
            public string Op { get; set; }
            public List<string> Com_value { get; set; }
            internal ClassificationData Duplicate()
            {
                ClassificationData cd = new ClassificationData();
                cd.Op = this.Op;
                cd.Com_value = new List<string>(this.Com_value);
                return cd;
            }
        }
        public struct ClassificatableSeriesData
        {
            public BasedSeriesData Base_info { get; set; }
            public Dictionary<string, ClassificationData> Classification { get; set; }
            internal ClassificatableSeriesData Duplicate()
            {


                ClassificatableSeriesData copy = new ClassificatableSeriesData();
                copy.Base_info = this.Base_info.Duplicate();
                if (this.Classification == null) return copy;
                copy.Classification = new Dictionary<string, ClassificationData>();

                foreach (KeyValuePair<string, ClassificationData> kvp in this.Classification)
                {
                    copy.Classification.Add(kvp.Key, kvp.Value.Duplicate());

                }
                return copy;
            }
        }
        #endregion

        [JsonPropertyName("default_series")]
        public ClassificatableSeriesData default_series_dummy { get; set; }
        [JsonPropertyName("other_series")]
        public Dictionary<string,ClassificatableSeriesData> classificatable_series_dummy { get; set; }


        private ClassificatableSeriesData default_series;
        private Dictionary<string, ClassificatableSeriesData> classificatable_series;
        private string[] used_column;

        private ClassificatableSeriesData[] sort_by_priority;
        private ClassificatableSeriesData[] sort_by_view;

        internal void Initialize()
        {

            default_series = default_series_dummy;
            classificatable_series = classificatable_series_dummy;

            used_column = GetUsedColumn();

            sort_by_priority = SortBypriority();

            sort_by_view = SortByview();

        }
        internal string[] UsedColumn
        {
            get { return used_column; }
        }
        private string[] GetUsedColumn()
        {
            string[][] datas = (from x in classificatable_series.Values select x.Classification.Keys.ToArray()).ToList().ToArray();

            string[] output = new string[datas.Length];
            for (int i=0;i<datas.Length;i++)
            {
                output[i] = datas[i][0];
            }
            return output;
            //return new string[1];
        }

        private ClassificatableSeriesData[] SortBypriority()
        {

            List<ClassificatableSeriesData> all_series_datas = this.AllSeriesAsList;
            List<ClassificatableSeriesData> sorted_series_less = new List<ClassificatableSeriesData>();
            all_series_datas.RemoveAt(0);
            sorted_series_less.Add(all_series_datas[0]);


            for(int i = 1; i < all_series_datas.Count; i++)
            {
                int list_pri = all_series_datas[i].Base_info.priority;
                int insert_ind = sorted_series_less.Count-1;
                for (int j = 0; j < i; j++)
                {
                    int sorted_pri = sorted_series_less[j].Base_info.priority;
                    if (list_pri < sorted_pri)
                    {
                        sorted_series_less.Insert(j, all_series_datas[i]);
                        break;
                    }else if (i-1 == j)
                    {
                        sorted_series_less.Add(all_series_datas[i]);
                    }
                }
            }
            return sorted_series_less.ToArray();
        }

        private ClassificatableSeriesData[] SortByview()
        {

            List<ClassificatableSeriesData> all_series_datas = this.AllSeriesAsList;
            List<ClassificatableSeriesData> sorted_series_less = new List<ClassificatableSeriesData>();
            sorted_series_less.Add(all_series_datas[0]);


            for (int i = 1; i < all_series_datas.Count; i++)
            {
                int list_pri = all_series_datas[i].Base_info.View_num;
                int insert_ind = sorted_series_less.Count - 1;
                for (int j = 0; j < i; j++)
                {
                    int sorted_pri = sorted_series_less[j].Base_info.View_num;
                    if (list_pri < sorted_pri)
                    {
                        sorted_series_less.Insert(j, all_series_datas[i]);
                        break;
                    }else if (i - 1 == j)
                    {
                        sorted_series_less.Add(all_series_datas[i]);
                    }
                }
            }
            return sorted_series_less.ToArray();
        }

        internal string[] SeriesList
        {
            get
            {
                return classificatable_series.Keys.ToArray();
            }
        }
        internal ClassificatableSeriesData[] OtherSeriesDatas
        {
            get { return classificatable_series.Values.ToList().ToArray(); }
        }
        internal ClassificatableSeriesData[] AllSeriesDatas
        {
            get { return classificatable_series.Values.ToList().ToArray(); }
        }
        internal string[] SeriesNameList
        {
            get
            {
                List<string> seriesName = new List<string>();
                seriesName.Add(default_series.Base_info.Name);
                seriesName.AddRange(from x in classificatable_series.Values select x.Base_info.Name);
                return seriesName.ToArray();
            }
        }
        internal int SeriesCount
        {
            get { return this.SeriesList.Count(); }
        }
        internal Dictionary<string,ClassificationData>[] classificatoinDatas
        {
            get { return (from x in sort_by_priority select x.Classification).ToArray(); }
        }
        internal ClassificatableSeriesData DefaultSeries
        {
            get { return this.default_series; }
        }
        
        private List<ClassificatableSeriesData> AllSeriesAsList
        {
            get
            {
                List<ClassificatableSeriesData> all_series = new List<ClassificatableSeriesData>() {
                    default_series
                };
                all_series.AddRange(classificatable_series.Values);
                return all_series;
            }
        }
        internal ClassificatableSeriesData[] SortedByView
        {
            get { return sort_by_view; }
        }
        internal ClassificatableSeriesData[] SortedByPriority
        {
            get { return sort_by_priority; }
        }
        /// <summary>
        /// SeriesBanderの深いコピー
        /// </summary>
        /// <returns></returns>
        internal SeriesBander Duplicate()
        {

            SeriesBander copy = new SeriesBander();
            ClassificatableSeriesData default_series_copy = this.default_series.Duplicate();
            Dictionary<string, ClassificatableSeriesData> classificatabl_eseries_copy = new Dictionary<string, ClassificatableSeriesData>();
            foreach(var kvp in classificatable_series)
            {
                classificatabl_eseries_copy.Add(kvp.Key, kvp.Value.Duplicate());
            }
            copy.default_series_dummy = default_series_copy;
            copy.classificatable_series_dummy = classificatabl_eseries_copy;
            copy.Initialize();
            return copy;


        }
        

    }
}
