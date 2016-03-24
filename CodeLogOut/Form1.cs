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
            //格式化文本 这一要第三方软件多得是，就不参与设计了，以免出错
            //加主指定的log
            //通过全局搜索{} 然后判断里面还有没有{}  直到最里层，然后只在最里层或代码层输出log
            StringBuilder sbContent = new StringBuilder();
            string codeContent = System.IO.File.ReadAllText(this.txtFile.Text);

        }
     
    }
}
