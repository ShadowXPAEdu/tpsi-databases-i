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
    public partial class ChangePassword : Form
    {
        private Form2 form;
        private int ID_Conta;
        private String EMAIL, Original_PASSWORD_CONTA, USERNAME;
        private int ISGM, ISLOGGED, ISBANNED, ID_SERVIDOR;

        public ChangePassword(Form2 form, int ID_Conta)
        {
            InitializeComponent();
            this.form = form;
            this.ID_Conta = ID_Conta;
            this.USERNAME = this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("USERNAME")].ToString();
            this.EMAIL = this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("EMAIL")].ToString();
            this.Original_PASSWORD_CONTA = this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("PASSWORD_CONTA")].ToString();
            this.ID_SERVIDOR = int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ID_SERVIDOR")].ToString());
            this.ISGM = int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ISGM")].ToString());
            this.ISLOGGED = int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ISLOGGED")].ToString());
            this.ISBANNED = int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ISBANNED")].ToString());
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.CONTA' table. You can move, or remove it, as needed.
            this.cONTATableAdapter.Fill(this.dataSet2.CONTA);

        }

        private void CS_Okay_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox1.Text.Trim().Length < Form1.NUM_CHAR_PASS)
                {
                    MessageBox.Show("Erro: Introduza pelo menos " + Form1.NUM_CHAR_PASS + " carateres.");
                }
                else
                {
                    if (this.textBox1.Text.Trim() != this.textBox2.Text.Trim())
                    {
                        MessageBox.Show("Erro: Passwords não coencidem.");
                    }
                    else
                    {
                        if (this.textBox1.Text.Trim() == this.Original_PASSWORD_CONTA)
                        {
                            MessageBox.Show("Erro: Password igual à password atual. Introduza uma nova password.");
                        }
                        else
                        {
                            this.cONTATableAdapter.Update(ID_SERVIDOR, USERNAME, EMAIL, this.textBox1.Text.Trim(), (short)ISGM, (short)ISLOGGED, (short)ISBANNED, ID_Conta, ID_SERVIDOR, USERNAME, EMAIL, Original_PASSWORD_CONTA, (short)ISGM, (short)ISLOGGED, (short)ISBANNED);
                            MessageBox.Show("Password alterado com sucesso!");
                            this.Close();
                            this.form.Reload();
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);
            }
        }

        private void CS_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
