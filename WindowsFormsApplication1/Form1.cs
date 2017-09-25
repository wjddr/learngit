using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string line;
            string sFileName = "";
            string useline = "";
            string tmpStr = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//弹出文件选择器,选择文件
            {
                sFileName = openFileDialog1.FileName;//将文件名获取出来赋值给对应的变量

                int iXH = 0;
                int 计数 = 0;

                FileStream fs = new FileStream("C:\\Users\\wj\\Desktop\\sms1.csv", FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("GB2312"));


                StreamReader file = new StreamReader(sFileName, Encoding.GetEncoding("GB2312"));
                while ((line = file.ReadLine()) != null)
                {
                    //这里的Line就是您要的的数据了
                    iXH++;//计数,总共几行
                    if (iXH == 1)
                    {
                        sw.WriteLine(line);
                        continue;
                    }

                    if (tmpStr.Equals(""))
                    {
                        tmpStr += line;
                    }
                    else
                    {
                        tmpStr = tmpStr + System.Environment.NewLine + line;
                    }
                   
                    if (tmpStr.IndexOf("NONE") != -1
                        || tmpStr.IndexOf("失败") != -1
                        || tmpStr.IndexOf("完成") != -1)
                    {
                        if (!useline.Equals(tmpStr))
                        {
                            sw.WriteLine(tmpStr);
                            useline = tmpStr;
                            
                            计数++;
                        }
                        tmpStr = "";
                    }
                    else
                    {
                        continue;
                    }
                    
                    //useline = line;
                }
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();

                file.Close();//关闭文件读取流
            }
        }
    }
}
