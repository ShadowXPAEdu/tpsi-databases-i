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
    public partial class JoinClan : Form
    {
        private Form2 form;
        private int ID_Personagem;

        public JoinClan(Form2 form, int ID_Personagem)
        {
            InitializeComponent();

            this.form = form;
            this.ID_Personagem = ID_Personagem;
        }

        private void JoinClan_Load(object sender, EventArgs e)
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
                this.pERTENCETableAdapter.Insert(decimal.Parse(this.comboBox1.SelectedValue.ToString()), this.ID_Personagem, 0, 0);
                MessageBox.Show("Aderiu ao clan com sucesso!");
                this.Close();
                this.form.Reload();
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
