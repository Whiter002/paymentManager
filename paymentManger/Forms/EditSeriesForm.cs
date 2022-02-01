using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using paymentManger.Class;

namespace paymentManger.Forms
{
    internal partial class EditSeriesForm : Form
    {
        SeriesBander sb;

        internal EditSeriesForm()
        {
            InitializeComponent();
        }
        internal void SetSeriesBansder(SeriesBander sb)
        {

            this.sb = sb.Duplicate();

        }
        internal void SetInformationForControl()
        {

            string[] nameList = ConfigDatas.SeriesSortByPriority;
            ListViewItem[] lvi = new ListViewItem[nameList.Length];
            for(int i = 0; i < nameList.Length; i++)
            {
                lvi[i]=new ListViewItem(new string[]{
                nameList[i],
                ConfigDatas.Series.SortedByPriority[i].Base_info.priority.ToString(),
                ConfigDatas.Series.SortedByPriority[i].Base_info.View_num.ToString()
                });
            }
            this.Series_list.Items.AddRange(lvi);

        }

        private void EditSeriesForm_Shown(object sender, EventArgs e)
        {

            SetInformationForControl();

        }


        private void Series_list_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            int selected_index = lv.SelectedIndices[0];
            if (selected_index == -1) return;

            string series_name = lv.Items[selected_index].Text;
            if (!ConfigDatas.IsExistedSeriesName(series_name)) return ;

            SeriesBander.ClassificatableSeriesData csd = ConfigDatas.GetSeriesDataFromName(series_name);

            ListViewItem[] lvi_arr = new ListViewItem[csd.Classification.Keys.Count];
            int index = 0;
            foreach(string key in csd.Classification.Keys)
            {
                string[] item_infos = new string[3]
                {
                    key,
                    csd.Classification[key].Op,
                    String.Join(",",csd.Classification[key].Com_value)
                };
                lvi_arr[index] = new ListViewItem(item_infos);
                index++;
            }

            this.Classification_list.Items.Clear();
            this.Classification_list.Items.AddRange(lvi_arr);

        }
    }
}
