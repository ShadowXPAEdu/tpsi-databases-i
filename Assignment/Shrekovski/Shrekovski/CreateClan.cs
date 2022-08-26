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
    public partial class CreateClan : Form
    {
        private Form2 form;
        private int ID_Personagem;

        public CreateClan(Form2 form, int ID_Personagem)
        {
            InitializeComponent();

            this.form = form;
            this.ID_Personagem = ID_Personagem;
        }

        private void CreateClan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.PERTENCE' table. You can move, or remove it, as needed.
            this.pERTENCETableAdapter.Fill(this.dataSet2.PERTENCE);
            // TODO: This line of code loads data into the 'dataSet2.CLAN' table. You can move, or remove it, as needed.
            this.cLANTableAdapter.Fill(this.dataSet2.CLAN);
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
                        List<int> ID_Clan_Existentes = new List<int>();
                        
                        for (int i = 0; i < this.cLANBindingSource.Count; i++)
                        {
                            ID_Clan_Existentes.Add(int.Parse(this.cLANTableAdapter.GetData().Select()[i].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("ID_CLAN")].ToString()));
                        }

                        ID_Clan_Existentes.Sort();
                        
                        for (int i = 0; i < Form1.NUM_MAX_CHARS; i++)
                        {
                            if (!ID_Clan_Existentes.Contains(i))
                            {
                                this.cLANTableAdapter.Insert(i, this.textBox1.Text.Trim());
                                this.pERTENCETableAdapter.Insert(i, this.ID_Personagem, 1, 0);
                                MessageBox.Show("Clan criado com sucesso!");
                                this.Close();
                                this.form.Reload();
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro: O nome do clan não pode conter espaços no meio.");
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
