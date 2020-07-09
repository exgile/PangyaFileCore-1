using System;
using System.Windows.Forms;
using PangyaFileCore;

namespace PangyaFileCoreTest
{
    public partial class AppMain : Form
    {
        public AppMain()
        {
            InitializeComponent();
            new IffBaseManager();
        }

        private void BtnChar_Click(object sender, EventArgs e)
        {
            new CharacterFileIFF().ShowDialog();
        }

        private void BtnPart_Click(object sender, EventArgs e)
        {
            new PartFileIFF().ShowDialog();
        }

        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            int iFrmChildAnterior = this.MdiChildren.Length - 2; //Pega índice do penúltimo formulário.
            if (iFrmChildAnterior >= 0)
                this.MdiChildren[iFrmChildAnterior].Visible = true; //Torna ele visível novamente
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By LuisMK");
        }

        private void BtnItem_Click(object sender, EventArgs e)
        {
            new ItemFileIFF().ShowDialog();
        }
    }
}
