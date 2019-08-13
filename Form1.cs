using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IQIYI.PlayList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }
        List<VideoInfo> videos = new List<VideoInfo>();
        private void btnGetUrl_Click(object sender, EventArgs e)
        {
            videos = new List<VideoInfo>();
            string content = HttpUtils.HttpGet(txtUrl.Text.Trim(),"");
            Regex reg = new Regex("bodan-playlist-data='([^']+)'");
            Match match = reg.Match(content);
            if (match != null)
            {
                string res = match.Groups[1].Value;
                JObject ob = JsonConvert.DeserializeObject(res) as JObject;
                JArray array = ob["playList"] as JArray;
                int i = 1;
                foreach (JObject jb in array)
                {
                    ListViewItem item = new ListViewItem(i.ToString());
                    item.SubItems.Add(jb["shortTitle"].ToString());
                    item.SubItems.Add(jb["playUrl"].ToString());
                    item.SubItems.Add("初始化");
                    listView1.Items.Add(item);
                    VideoInfo video = new VideoInfo() { Id=i.ToString(), Title= jb["shortTitle"].ToString(), Url= jb["playUrl"].ToString() };
                    videos.Add(video);
                    i++;
                }
            }
        }

        private void btnDowload_Click(object sender, EventArgs e)
        {
           
            Task.Run(() =>
            {
                RunTask();
            }).Wait();
            lblHint.Text = "下载完毕...";
        }
        protected void RunTask()
        {
            int num = 5;
            List<Task> tasks = new List<Task>();
            TaskFactory factory = new TaskFactory();
            videos.ForEach(v => {
                tasks.Add(factory.StartNew(()=> {
                    //业务逻辑处理
                    Process process = new Process();
                    process.StartInfo.Arguments = " "+v.Url;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.FileName = "annie.exe";
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.Start();
                    process.WaitForExit();
                    listView1.Items[Convert.ToInt32(v.Id) - 1].SubItems[3].Text = "完成";
                    process.StandardOutput.ReadToEnd();//返回结果

                }));
                if (tasks.Count >= num)
                {
                    Task.WaitAny(tasks.ToArray());
                    tasks = tasks.Where(c => c.Status == TaskStatus.Running).ToList();
                }

            });

        }
    }
}
