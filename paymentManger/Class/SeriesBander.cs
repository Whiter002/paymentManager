﻿using System;
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
        };
        public struct ClassificationData
        {
            public string Op { get; set; }
            public List<string> Com_value { get; set; }
        }
        public struct ClassificatableSeriesData
        {
            public BasedSeriesData Base_info { get; set; }
            public Dictionary<string, ClassificationData> Classification { get; set; }
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

        private string[] GetUsedColumn()
        {
            return (from x in classificatable_series.Values select x.Classification.Keys.ToArray()).ToList()[0].ToArray();
        }

        private ClassificatableSeriesData[] SortBypriority()
        {

            List<ClassificatableSeriesData> all_series_datas = this.AllSeriesAsList;
            List<ClassificatableSeriesData> sorted_series_less = new List<ClassificatableSeriesData>() ;
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
                        continue;
                    }

                    if (i-1 == j)
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
                        continue;
                    }

                    if (i - 1 == j)
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

    }
}