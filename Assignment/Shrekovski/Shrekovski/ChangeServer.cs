using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shrekovski
{
    public partial class ChangeServer : Form
    {
        private Form2 form;
        private int ID_Conta;
        private String USERNAME, EMAIL, PASSWORD_CONTA;
        private int ISGM, ISLOGGED, ISBANNED, Original_ID_SERVIDOR;

        public ChangeServer(Form2 form, int ID_Conta)
        {
            InitializeComponent();
            this.form = form;
            this.ID_Conta = ID_Conta;
            this.USERNAME = this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("USERNAME")].ToString();
            this.EMAIL = this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("EMAIL")].ToString();
            this.PASSWORD_CONTA = this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("PASSWORD_CONTA")].ToString();
            this.Original_ID_SERVIDOR = int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ID_SERVIDOR")].ToString());
            this.ISGM = int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ISGM")].ToString());
            this.ISLOGGED = int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ISLOGGED")].ToString());
            this.ISBANNED = int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ISBANNED")].ToString());
        }

        private void ChangeServer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.CONTA' table. You can move, or remove it, as needed.
            this.cONTATableAdapter.Fill(this.dataSet2.CONTA);
            // TODO: This line of code loads data into the 'dataSet2.SERVIDOR' table. You can move, or remove it, as needed.
            this.sERVIDORTableAdapter.Fill(this.dataSet2.SERVIDOR);
        }

        private void CS_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CS_Okay_Click(object sender, EventArgs e)
        {
            try
            {
                if ((decimal)this.comboBox1.SelectedValue != this.Original_ID_SERVIDOR)
                {
                    this.cONTATableAdapter.Update((decimal)this.comboBox1.SelectedValue, USERNAME, EMAIL, PASSWORD_CONTA, (short)ISGM, (short)ISLOGGED, (short)ISBANNED, ID_Conta, Original_ID_SERVIDOR, USERNAME, EMAIL, PASSWORD_CONTA, (short)ISGM, (short)ISLOGGED, (short)ISBANNED);
                    MessageBox.Show("Servidor alterado com sucesso!");
                    this.Close();
                    this.form.Reload();
                }
                else
                {
                    MessageBox.Show("Erro: A conta já se encontra nesse servidor.");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);
            }
        }
    }
}
