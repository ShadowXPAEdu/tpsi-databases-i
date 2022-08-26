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
    public partial class ChangeUsername : Form
    {
        private Form2 form;
        private int ID_Conta;
        private String EMAIL, PASSWORD_CONTA, Original_USERNAME;
        private int ISGM, ISLOGGED, ISBANNED, ID_SERVIDOR;

        private void ChangeUsername_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.CONTA' table. You can move, or remove it, as needed.
            this.cONTATableAdapter.Fill(this.dataSet2.CONTA);

        }

        public ChangeUsername(Form2 form, int ID_Conta)
        {
            InitializeComponent();
            this.form = form;
            this.ID_Conta = ID_Conta;
            this.Original_USERNAME = this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("USERNAME")].ToString();
            this.EMAIL = this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("EMAIL")].ToString();
            this.PASSWORD_CONTA = this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("PASSWORD_CONTA")].ToString();
            this.ID_SERVIDOR = int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ID_SERVIDOR")].ToString());
            this.ISGM = int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ISGM")].ToString());
            this.ISLOGGED = int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ISLOGGED")].ToString());
            this.ISBANNED = int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ISBANNED")].ToString());
        }

        private void CS_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CS_Okay_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox1.Text.Trim().Length >= Form1.NUM_CHAR_USER)
                {
                    if (this.textBox1.Text != this.Original_USERNAME)
                    {
                        bool espaços = true;
                        foreach (char c in this.textBox1.Text.Trim())
                        {
                            if (c == ' ')
                            {
                                espaços = false;
                                break;
                            }
                        }

                        if (espaços)
                        {
                            this.cONTATableAdapter.Update(ID_SERVIDOR, this.textBox1.Text.Trim(), EMAIL, PASSWORD_CONTA, (short)ISGM, (short)ISLOGGED, (short)ISBANNED, ID_Conta, ID_SERVIDOR, Original_USERNAME, EMAIL, PASSWORD_CONTA, (short)ISGM, (short)ISLOGGED, (short)ISBANNED);
                            MessageBox.Show("Username alterado com sucesso!");
                            this.Close();
                            this.form.Reload();
                        }
                        else
                        {
                            MessageBox.Show("Erro: O username não pode conter espaços no meio do nome.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro: O username é o mesmo.");
                    }
                }
                else
                {
                    MessageBox.Show("Erro: Introduza pelo menos " + Form1.NUM_CHAR_USER + " caracteres.");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);
            }
        }
    }
}
