using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace CodeLogOut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofd.FileName;
            }
        }

        private void btnOutFile_Click(object sender, EventArgs e)
        {
            //方式一
            //格式化文本 这一要第三方软件多得是，就不参与设计了，以免出错
            //加主指定的log
            //通过全局搜索{} 然后判断里面还有没有{}  直到最里层，然后只在最里层或代码层输出log
            //方式二
            //前面太难,现在降低难度,只要求找到方法
            //对方法的判断,只用正则无法全面的匹配成功
            if (txtFile.Text == "")
            {
                return;
            }
           
            System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(outPutCodeLog));
            th.Start(this.txtFile.Text);
        }

        private void outPutCodeLog(object obj)
        {
            string filename = (string)obj;
            System.IO.Path.GetFileName(filename);
            string path = System.IO.Path.GetFileName(filename);
            if (path.Contains(".") == false)
            {
                MessageBox.Show("没有选择文件!");
            }

            if (System.IO.File.Exists(path) == false)
            {
                int point = 0;
                point = path.IndexOf('.');
                string date = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                path = path.Insert(point, date);
            }
            StringBuilder sbContent = new StringBuilder();
            string codeContent = System.IO.File.ReadAllText(filename);
            CodeLogFactory facCode = new CodeLogFactory();
            string new_CodeContent = facCode.GetNewLogCode(codeContent, LANGUANGEType.C);
            System.IO.File.WriteAllText(path, new_CodeContent);
        }
     
    }
}
