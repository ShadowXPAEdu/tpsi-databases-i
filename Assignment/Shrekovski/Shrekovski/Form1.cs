using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shrekovski
{
    public partial class Form1 : Form
    {
        public const int NUM_MAX_CHARS = 999999999;
        public const int NUM_INDEX_COMBO_BOX = -1;
        public const int NUM_CHAR_USER = 1;
        public const int NUM_CHAR_PASS = 4;
        public const int NUM_FORM_CC = 4;
        public const int NUM_FORM_L = 3;
        private int LoginID;
        private String LoginAccStatus;
        private bool AdminMode;

        public Form1()
        {
            InitializeComponent();
            this.ErroCC.Text = "";
            this.SuccessCC.Text = "";
            this.ErroL.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) // Botão Criar Conta
        {
            int a = 0;

            if (VerifyErroUsernameCC())
                a++;
            if (VerifyErroEmailCC())
                a++;
            if (VerifyErroPassCC())
                a++;
            if (VerifyErroServCC())
                a++;

            if (a == NUM_FORM_CC)
            {
                DisableForm();
                // adiciona para a base de dados aqui...
                if (VerifyIfExists(false))
                {
                    EnableForm();
                    this.ErroCC.Text = "Ocurreu um erro.\nConta não foi criada.";
                }
                else
                {
                    if (AdicionarParaBaseDeDados())
                    {
                        EnableForm();
                        this.SuccessCC.Text = "Conta adicionada com sucesso.";
                    }
                    else
                    {
                        EnableForm();
                        this.ErroCC.Text = "Ocurreu um erro.\nConta não foi criada.";
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Botão Login
        {
            int a = 0;

            if (VerifyErroUsername())
                a++;
            if (VerifyPassword())
                a++;
            if (VerifyServidor()) // VerifyServidor()
                a++;

            if (a == NUM_FORM_L)
            {
                DisableForm();
                if (VerifyIfExists(true)) // VerifyIfExists(true)
                {
                    if (EfetuaLogin()) // EfetuaLogin()
                    {
                        EnableForm();
                        this.Hide();
                        Form2 manager = new Form2(AdminMode, this, LoginAccStatus, LoginID);
                        manager.Show();
                    }
                    else
                    {
                        EnableForm();
                        this.ErroL.Text = "Ocurreu um erro.\nLogin não efetuado.\nTente novamente.";
                    }
                }
                else
                {
                    EnableForm();
                }
            }
        }

        private void DisableForm()
        {
            DisableCC();
            DisableL();
            this.ErroUsernameCriarConta.Text = "";
            this.ErroEmailCriarConta.Text = "";
            this.ErroPassCriarConta.Text = "";
            this.ErroServidorCriarConta.Text = "";
            this.ErroUsernameLogin.Text = "";
            this.ErroPasswordLogin.Text = "";
            this.ErroServidorLogin.Text = "";
            this.ErroL.Text = "";
            this.ErroCC.Text = "";
            this.SuccessCC.Text = "";
        }

        private void EnableForm()
        {
            EnableCC();
            EnableL();
        }

        private void DisableCC()
        {
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.comboBox1.Enabled = false;
            this.button1.Enabled = false;
        }

        private void EnableCC()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.comboBox1.SelectedIndex = 0;
            this.textBox1.Enabled = true;
            this.textBox2.Enabled = true;
            this.textBox3.Enabled = true;
            this.comboBox1.Enabled = true;
            this.button1.Enabled = true;
        }

        private void DisableL()
        {
            this.textBox4.Enabled = false;
            this.textBox5.Enabled = false;
            this.comboBox2.Enabled = false;
            this.button2.Enabled = false;
        }

        private void EnableL()
        {
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.comboBox2.SelectedIndex = 0;
            this.textBox4.Enabled = true;
            this.textBox5.Enabled = true;
            this.comboBox2.Enabled = true;
            this.button2.Enabled = true;
        }

        private bool VerifyErroUsernameCC()
        {
            bool validate = true;

            if (this.textBox1.Text.Trim(' ').Length < NUM_CHAR_USER)
            {
                this.ErroUsernameCriarConta.Text = "* Introduza pelo\nmenos " + NUM_CHAR_USER + " caracteres.";
                validate = false;
            }
            else
            {
                foreach (char c in this.textBox1.Text.Trim(' '))
                {
                    if (c == ' ')
                    {
                        this.ErroUsernameCriarConta.Text = "* Não pode conter\nespaços no meio do nome.";
                        validate = false;
                    }
                }
            }

            if (validate)
            {
                this.ErroUsernameCriarConta.Text = "";
            }

            return validate;
        }

        private bool VerifyErroEmailCC()
        {
            bool validate = true;

            if ((this.textBox2.Text.Trim(' ').IndexOf('@') == -1) || (this.textBox2.Text.Trim(' ').IndexOf('@') > this.textBox2.Text.Trim(' ').IndexOf('.', this.textBox2.Text.Trim(' ').IndexOf('@'))))
            {
                this.ErroEmailCriarConta.Text = "* E-mail inválido.";
                validate = false;
            }
            else
            {
                this.ErroEmailCriarConta.Text = "";
            }

            return validate;
        }

        private bool VerifyErroPassCC()
        {
            bool validate = true;

            if (this.textBox3.Text.Trim(' ').Length < NUM_CHAR_PASS)
            {
                this.ErroPassCriarConta.Text = "* Introduza pelo\nmenos " + NUM_CHAR_PASS + " carateres.";
                validate = false;
            }
            else
            {
                this.ErroPassCriarConta.Text = "";
            }

            return validate;
        }

        private bool VerifyErroServCC()
        {
            bool validate = true;

            if ((decimal)this.comboBox1.SelectedValue == NUM_INDEX_COMBO_BOX)
            {
                this.ErroServidorCriarConta.Text = "* Selecione uma opção.";
                validate = false;
            }
            else
            {
                this.ErroServidorCriarConta.Text = "";
            }

            return validate;
        }

        // CCorL -> CC = false L = true
        private bool VerifyIfExists(bool CCorL)
        {
            if (CCorL) // Login
            {
                if (this.cONTATableAdapter.GetData().Select("PASSWORD_CONTA = '" + this.textBox5.Text + "' AND USERNAME = '" + this.textBox4.Text + "' AND ID_SERVIDOR = " + (decimal)this.comboBox2.SelectedValue).Length == 1)
                {
                    return true;
                }
                else
                {
                    if (this.cONTATableAdapter.GetData().Select("USERNAME = '" + this.textBox4.Text + "' AND ID_SERVIDOR = " + (decimal)this.comboBox2.SelectedValue).Length == 0)
                        this.ErroL.Text = "Erro: Conta não existe nesse servidor.";
                    if (this.cONTATableAdapter.GetData().Select("USERNAME = '" + this.textBox4.Text + "' AND PASSWORD_CONTA = '" + this.textBox5.Text + "'").Length == 0)
                        this.ErroL.Text = "Erro: Password incorreta.";
                    if (this.cONTATableAdapter.GetData().Select("USERNAME = '" + this.textBox4.Text + "'").Length == 0)
                        this.ErroL.Text = "Erro: Conta não existe.";
                    return false;
                }
            }
            else       // Criar Conta
            {
                bool valid = false;

                if (this.cONTATableAdapter.GetData().Select("USERNAME = '" + this.textBox1.Text + "'").Length == 1)
                {
                    this.ErroUsernameCriarConta.Text = "* Username já existe";
                    valid = true;
                }
                if (this.cONTATableAdapter.GetData().Select("EMAIL = '" + this.textBox2.Text + "'").Length == 1)
                {
                    this.ErroEmailCriarConta.Text = "* E-mail já existe";
                    valid = true;
                }

                return valid;
            }
        }

        private bool AdicionarParaBaseDeDados()
        {
            try
            {
                List<int> IDs = new List<int>();

                for (int i = 0; i < this.cONTABindingSource.Count; i++)
                {
                    IDs.Add(int.Parse(this.cONTATableAdapter.GetData().Select()[i].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ID_CONTA")].ToString()));
                }

                IDs.Sort();

                for (int i = 0; i < NUM_MAX_CHARS; i++)
                {
                    if (!IDs.Contains(i))
                    {
                        this.cONTATableAdapter.Insert(i, (decimal)this.comboBox1.SelectedValue, this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, 0, 0, 0);
                        break;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool EfetuaLogin()
        {
            try
            {
                this.LoginID = int.Parse(this.cONTATableAdapter.GetData().Select("PASSWORD_CONTA = '" + this.textBox5.Text + "' AND USERNAME = '" + this.textBox4.Text + "' AND ID_SERVIDOR = " + (decimal)this.comboBox2.SelectedValue)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ID_CONTA")].ToString());
                if (int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.LoginID)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ISGM")].ToString()) == 0)
                    this.AdminMode = false;
                else
                    this.AdminMode = true;
                if (int.Parse(this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.LoginID)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ISBANNED")].ToString()) == 0)
                    this.LoginAccStatus = "";
                else
                    this.LoginAccStatus = "Account is banned.";
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool VerifyErroUsername()
        {
            bool validate = true;

            if (this.textBox4.Text.Trim(' ').Length < NUM_CHAR_USER)
            {
                this.ErroUsernameLogin.Text = "* Introduza pelo\nmenos " + NUM_CHAR_USER + " caracteres.";
                validate = false;
            }
            else
            {
                foreach (char c in this.textBox4.Text.Trim(' '))
                {
                    if (c == ' ')
                    {
                        this.ErroUsernameLogin.Text = "* Não pode conter\nespaços no meio do nome.";
                        validate = false;
                    }
                }
            }

            if (validate)
            {
                this.ErroUsernameLogin.Text = "";
            }

            return validate;
        }

        private bool VerifyPassword()
        {
            bool validate = true;

            if (this.textBox5.Text.Trim(' ').Length < NUM_CHAR_PASS)
            {
                this.ErroPasswordLogin.Text = "* Introduza pelo\nmenos " + NUM_CHAR_PASS + " carateres.";
                validate = false;
            }
            else
            {
                this.ErroPasswordLogin.Text = "";
            }

            return validate;
        }

        private bool VerifyServidor()
        {
            bool validate = true;

            if ((decimal)this.comboBox2.SelectedValue == NUM_INDEX_COMBO_BOX)
            {
                this.ErroServidorLogin.Text = "* Selecione uma opção.";
                validate = false;
            }
            else
            {
                this.ErroServidorLogin.Text = "";
            }

            return validate;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.CONTA' table. You can move, or remove it, as needed.
            this.cONTATableAdapter.Fill(this.dataSet2.CONTA);
            // TODO: This line of code loads data into the 'dataSet1.SERVIDOR' table. You can move, or remove it, as needed.
            this.sERVIDORTableAdapter.Fill(this.dataSet2.SERVIDOR);
            // TODO: This line of code loads data into the 'dataSet1.SERVIDOR' table. You can move, or remove it, as needed.
            this.sERVIDORTableAdapter.Fill(this.dataSet2.SERVIDOR);
        }
    }
}
