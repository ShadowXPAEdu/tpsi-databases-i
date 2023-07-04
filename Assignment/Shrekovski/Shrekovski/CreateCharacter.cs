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
    public partial class CreateCharacter : Form
    {
        private Form2 form;
        private int ID_Conta;
        private bool[] SlotUsed;

        public CreateCharacter(Form2 form, int ID_Conta, bool[] SlotUsed)
        {
            InitializeComponent();
            this.form = form;
            this.ID_Conta = ID_Conta;
            this.SlotUsed = SlotUsed;
        }

        private void CreateCharacter_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.BANCO' table. You can move, or remove it, as needed.
            this.bANCOTableAdapter.Fill(this.dataSet2.BANCO);
            // TODO: This line of code loads data into the 'dataSet2.PERSONAGEM' table. You can move, or remove it, as needed.
            this.pERSONAGEMTableAdapter.Fill(this.dataSet2.PERSONAGEM);
            // TODO: This line of code loads data into the 'dataSet2.CLASSE' table. You can move, or remove it, as needed.
            this.cLASSETableAdapter.Fill(this.dataSet2.CLASSE);

            this.radioButton3.Enabled = !SlotUsed[0];
            this.radioButton4.Enabled = !SlotUsed[1];
            this.radioButton5.Enabled = !SlotUsed[2];
            this.radioButton6.Enabled = !SlotUsed[3];
            this.radioButton7.Enabled = !SlotUsed[4];

            // Seleciona primeiro slot válido
            for (int i = 0; i < SlotUsed.Length; i++)
            {
                if (!SlotUsed[i])
                {
                    switch (i)
                    {
                        case 0:
                            this.radioButton3.Checked = true;
                            i = 5;
                            break;
                        case 1:
                            this.radioButton4.Checked = true;
                            i = 5;
                            break;
                        case 2:
                            this.radioButton5.Checked = true;
                            i = 5;
                            break;
                        case 3:
                            this.radioButton6.Checked = true;
                            i = 5;
                            break;
                        case 4:
                            this.radioButton7.Checked = true;
                            i = 5;
                            break;
                    }
                }
            }

            // Seleciona masculino como default
            this.radioButton1.Checked = true;
        }

        private void CS_Okay_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox1.Text.Trim().Length < Form1.NUM_CHAR_USER)
                {
                    MessageBox.Show("Erro: Introduza pelo menos " + Form1.NUM_CHAR_USER + " carateres no nome da personagem.");
                }
                else
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
                        // radioButton1
                        String Genero = "M";
                        if (this.radioButton2.Checked)
                            Genero = "F";
                        // radioButton3
                        short SlotNum = 1;
                        if (this.radioButton4.Checked)
                            SlotNum = 2;
                        if (this.radioButton5.Checked)
                            SlotNum = 3;
                        if (this.radioButton6.Checked)
                            SlotNum = 4;
                        if (this.radioButton7.Checked)
                            SlotNum = 5;

                        List<int> IDs = new List<int>();

                        for (int i = 0; i < this.pERSONAGEMBindingSource.Count; i++)
                        {
                            IDs.Add(int.Parse(this.pERSONAGEMTableAdapter.GetData().Select()[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()));
                        }

                        IDs.Sort();

                        for (int i = 0; i < Form1.NUM_MAX_CHARS; i++)
                        {
                            if (!IDs.Contains(i))
                            {
                                this.pERSONAGEMTableAdapter.Insert(i, this.ID_Conta, decimal.Parse(this.comboBox1.SelectedValue.ToString()), this.textBox1.Text.Trim(), SlotNum, Genero);
                                this.bANCOTableAdapter.Insert(i, 0);
                                MessageBox.Show("Personagem criada com sucesso!");
                                this.Close();
                                this.form.Reload();
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro: O nome da personagem não pode conter espaços no meio.");
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
