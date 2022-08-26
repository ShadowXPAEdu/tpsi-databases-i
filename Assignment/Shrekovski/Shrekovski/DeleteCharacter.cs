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
    public partial class DeleteCharacter : Form
    {
        private Form2 form;
        private int ID_Conta;
        private bool[] SlotUsed;
        private int Original_ID_PERSONAGEM, Original_ID_CLASS;
        private String Original_NOME_PERS, Original_GENERO;

        public DeleteCharacter(Form2 form, int ID_Conta, bool[] SlotUsed)
        {
            InitializeComponent();
            this.form = form;
            this.ID_Conta = ID_Conta;
            this.SlotUsed = SlotUsed;
        }

        private void DeleteCharacter_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.BANCO' table. You can move, or remove it, as needed.
            this.bANCOTableAdapter.Fill(this.dataSet2.BANCO);
            // TODO: This line of code loads data into the 'dataSet2.PERTENCE' table. You can move, or remove it, as needed.
            this.pERTENCETableAdapter.Fill(this.dataSet2.PERTENCE);
            // TODO: This line of code loads data into the 'dataSet2.PERSONAGEM' table. You can move, or remove it, as needed.
            this.pERSONAGEMTableAdapter.Fill(this.dataSet2.PERSONAGEM);

            this.radioButton3.Enabled = SlotUsed[0];
            this.radioButton4.Enabled = SlotUsed[1];
            this.radioButton5.Enabled = SlotUsed[2];
            this.radioButton6.Enabled = SlotUsed[3];
            this.radioButton7.Enabled = SlotUsed[4];

            // Seleciona primeiro slot válido
            for (int i = 0; i < SlotUsed.Length; i++)
            {
                if (SlotUsed[i])
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
        }

        private void CS_Okay_Click(object sender, EventArgs e)
        {
            try
            {
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

                this.Original_ID_PERSONAGEM = int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta + " AND SLOT = " + SlotNum)[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString());
                this.Original_ID_CLASS = int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta + " AND SLOT = " + SlotNum)[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_CLASS")].ToString());
                this.Original_NOME_PERS = this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta + " AND SLOT = " + SlotNum)[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString();
                this.Original_GENERO = this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.ID_Conta + " AND SLOT = " + SlotNum)[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("GENERO")].ToString();

                if (this.pERTENCETableAdapter.GetData().Select("ID_PERSONAGEM = " + this.Original_ID_PERSONAGEM).Length > 0)
                {
                    MessageBox.Show("Erro: Personagem pertence a um clan.\nPor favor remova a personagem do clan.");
                }
                else
                {
                    if (this.bANCOTableAdapter.GetData().Select("ID_PERSONAGEM = " + this.Original_ID_PERSONAGEM).Length > 0)
                        this.bANCOTableAdapter.Delete(this.Original_ID_PERSONAGEM, int.Parse(this.bANCOTableAdapter.GetData().Select("ID_PERSONAGEM = " + this.Original_ID_PERSONAGEM)[0].ItemArray[this.bANCOTableAdapter.GetData().Columns.IndexOf("CREDITOS")].ToString()));
                    this.pERSONAGEMTableAdapter.Delete(this.Original_ID_PERSONAGEM, this.ID_Conta, this.Original_ID_CLASS, this.Original_NOME_PERS, SlotNum, this.Original_GENERO);
                    MessageBox.Show("Personagem eliminada com sucesso!");
                    this.Close();
                    this.form.Reload();
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
