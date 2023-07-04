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
    public partial class Form2 : Form
    {
        // ID_Personagem Tab = Personagem
        // X = 121 Y = 43
        public const int Pers_ID_PersX = 121;
        public const int Pers_ID_PersY = 43;
        // Nome_Clan Tab = Personagem
        // X = 714 Y = 163
        public const int Pers_Nome_ClanX = 714;
        public const int Pers_Nome_ClanY = 163;

        private Form1 form;
        private bool AdminMode;
        private String AccountStatus = "";
        private String Username = "";
        private bool[] SlotUsed;
        private bool[] ClanUsed;
        private List<int> ClanIDs;
        private List<String> CharNames;
        // TEMPORARY VAR - DO NOT USE ELSEWHERE
        private int ClanID;

        public Form2(bool AdminMode, Form1 form, String AccountStatus, int AccountID)
        {
            InitializeComponent();

            this.AdminMode = AdminMode;
            this.form = form;
            // verifica se é admin
            //AdminMode = ?;

            // Conta
            this.IDValue.Text = "" + AccountID;
            this.AccountStatusValue.Text = AccountStatus;
            this.AccountStatus = AccountStatus;
        }

        public static String convertGenero(String genero)
        {
            if (genero == "M")
            {
                return "Masculino";
            }
            else if (genero == "F")
            {
                return "Feminino";
            }
            else
            {
                return "Gender Error.";
            }
        }

        private void MudarServidor(object sender, EventArgs e)
        {
            new ChangeServer(this, int.Parse(this.IDValue.Text)).ShowDialog();
        }

        private void buttonMudarUsername_Click(object sender, EventArgs e)
        {
            new ChangeUsername(this, int.Parse(this.IDValue.Text)).ShowDialog();
        }

        private void buttonMudarPass_Click(object sender, EventArgs e)
        {
            new ChangePassword(this, int.Parse(this.IDValue.Text)).ShowDialog();
        }

        private void buttonCriarPers_Click(object sender, EventArgs e)
        {
            int SlotsAvailable = 0;

            for (int i = 0; i < this.SlotUsed.Length; i++)
            {
                if (!this.SlotUsed[i])
                {
                    SlotsAvailable++;
                    break;
                }
            }

            if (SlotsAvailable != 0)
                new CreateCharacter(this, int.Parse(this.IDValue.Text), SlotUsed).ShowDialog();
            else
                MessageBox.Show("Erro: Não é possivel criar mais personagens.");
        }

        private void buttonApagPers_Click(object sender, EventArgs e)
        {
            int DeleteAvailable = 0;

            for (int i = 0; i < this.SlotUsed.Length; i++)
            {
                if (this.SlotUsed[i])
                {
                    DeleteAvailable++;
                    break;
                }
            }

            if (DeleteAvailable != 0)
                new DeleteCharacter(this, int.Parse(this.IDValue.Text), SlotUsed).ShowDialog();
            else
                MessageBox.Show("Erro: A conta não contem personagens para apagar.");
        }

        private void DisolverClan1(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Dejesa mesmo dissolver o clan?", "", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                try
                {
                    for (int i = (this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label72.Text)).Length - 1); i >= 0; i--)
                    {
                        int Original_ID_PERSONAGEM = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label72.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString());
                        int Original_ISLEADER = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label72.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ISLEADER")].ToString());
                        int Original_ISSUBLEADER = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label72.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ISSUBLEADER")].ToString());
                        this.pERTENCETableAdapter.Delete(int.Parse(this.label72.Text), Original_ID_PERSONAGEM, (short)Original_ISLEADER, (short)Original_ISSUBLEADER);
                    }

                    this.cLANTableAdapter.Delete(int.Parse(this.label72.Text), this.cLANTableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label72.Text))[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("NOME_CLAN")].ToString());

                    Reload();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message);
                }
            }
        }

        private void DisolverClan2(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Dejesa mesmo dissolver o clan?", "", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                try
                {
                    for (int i = (this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label83.Text)).Length - 1); i >= 0; i--)
                    {
                        int Original_ID_PERSONAGEM = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label83.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString());
                        int Original_ISLEADER = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label83.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ISLEADER")].ToString());
                        int Original_ISSUBLEADER = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label83.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ISSUBLEADER")].ToString());
                        this.pERTENCETableAdapter.Delete(int.Parse(this.label83.Text), Original_ID_PERSONAGEM, (short)Original_ISLEADER, (short)Original_ISSUBLEADER);
                    }

                    this.cLANTableAdapter.Delete(int.Parse(this.label83.Text), this.cLANTableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label83.Text))[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("NOME_CLAN")].ToString());

                    Reload();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message);
                }
            }
        }

        private void DisolverClan3(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Dejesa mesmo dissolver o clan?", "", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                try
                {
                    for (int i = (this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label90.Text)).Length - 1); i >= 0; i--)
                    {
                        int Original_ID_PERSONAGEM = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label90.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString());
                        int Original_ISLEADER = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label90.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ISLEADER")].ToString());
                        int Original_ISSUBLEADER = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label90.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ISSUBLEADER")].ToString());
                        this.pERTENCETableAdapter.Delete(int.Parse(this.label90.Text), Original_ID_PERSONAGEM, (short)Original_ISLEADER, (short)Original_ISSUBLEADER);
                    }

                    this.cLANTableAdapter.Delete(int.Parse(this.label90.Text), this.cLANTableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label90.Text))[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("NOME_CLAN")].ToString());

                    Reload();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message);
                }
            }
        }

        private void DisolverClan4(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Dejesa mesmo dissolver o clan?", "", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                try
                {
                    for (int i = (this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label97.Text)).Length - 1); i >= 0; i--)
                    {
                        int Original_ID_PERSONAGEM = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label97.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString());
                        int Original_ISLEADER = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label97.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ISLEADER")].ToString());
                        int Original_ISSUBLEADER = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label97.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ISSUBLEADER")].ToString());
                        this.pERTENCETableAdapter.Delete(int.Parse(this.label97.Text), Original_ID_PERSONAGEM, (short)Original_ISLEADER, (short)Original_ISSUBLEADER);
                    }

                    this.cLANTableAdapter.Delete(int.Parse(this.label97.Text), this.cLANTableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label97.Text))[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("NOME_CLAN")].ToString());

                    Reload();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message);
                }
            }
        }

        private void DisolverClan5(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Dejesa mesmo dissolver o clan?", "", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                try
                {
                    for (int i = (this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label104.Text)).Length - 1); i >= 0; i--)
                    {
                        int Original_ID_PERSONAGEM = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label104.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString());
                        int Original_ISLEADER = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label104.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ISLEADER")].ToString());
                        int Original_ISSUBLEADER = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label104.Text))[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ISSUBLEADER")].ToString());
                        this.pERTENCETableAdapter.Delete(int.Parse(this.label104.Text), Original_ID_PERSONAGEM, (short)Original_ISLEADER, (short)Original_ISSUBLEADER);
                    }

                    this.cLANTableAdapter.Delete(int.Parse(this.label104.Text), this.cLANTableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.label104.Text))[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("NOME_CLAN")].ToString());

                    Reload();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message);
                }
            }
        }

        private void CriarClan(object sender, EventArgs e)
        {
            // MUDAR AS COORDENADAS CASO O LAYOUT MUDE
            new CreateClan(this, int.Parse((((Button)sender).Parent.GetChildAtPoint(new Point(Pers_ID_PersX, Pers_ID_PersY)).Text))).ShowDialog();
        }

        private void AderirClan(object sender, EventArgs e)
        {
            new JoinClan(this, int.Parse((((Button)sender).Parent.GetChildAtPoint(new Point(Pers_ID_PersX, Pers_ID_PersY)).Text))).ShowDialog();
        }

        private void SairClan(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Dejesa mesmo sair do clan?", "", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                try
                {
                    int ID_Pers = int.Parse(((Button)sender).Parent.GetChildAtPoint(new Point(Pers_ID_PersX, Pers_ID_PersY)).Text);
                    String Nome_Clan = ((Button)sender).Parent.GetChildAtPoint(new Point(Pers_Nome_ClanX, Pers_Nome_ClanY)).Text;
                    int ID_Clan = int.Parse(this.cLANTableAdapter.GetData().Select("NOME_CLAN = '" + Nome_Clan + "'")[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("ID_CLAN")].ToString());
                    short IS_LEADER = short.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + ID_Clan + " AND ID_PERSONAGEM = " + ID_Pers)[0].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ISLEADER")].ToString());

                    if (IS_LEADER == 1)
                    {
                        DialogResult res2 = MessageBox.Show("Personagem é leader do clan.\nSair do clan terá mesmo efeito que dissolver o clan.\nDejesa continuar?", "", MessageBoxButtons.YesNo);

                        if (res2 == DialogResult.Yes)
                        {
                            for (int i = (this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + ID_Clan).Length - 1); i >= 0; i--)
                            {
                                int ID_Cur_Pers = int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + ID_Clan)[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString());
                                short IS_Cur_Leader = short.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + ID_Clan)[i].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ISLEADER")].ToString());
                                this.pERTENCETableAdapter.Delete(ID_Clan, ID_Cur_Pers, IS_Cur_Leader, 0);
                            }
                            this.cLANTableAdapter.Delete(ID_Clan, Nome_Clan);
                            MessageBox.Show("Saiu do clan com sucesso!\nO clan foi dissolvido com sucesso!");

                            Reload();
                        }
                    }
                    else
                    {
                        this.pERTENCETableAdapter.Delete(ID_Clan, ID_Pers, IS_LEADER, 0);
                        MessageBox.Show("Saiu do clan com sucesso!");

                        Reload();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro: " + erro.Message);
                }
            }
        }

        private void CriarServAdmin(object sender, EventArgs e)
        {
            this.sERVIDORBindingSource.AddNew();
            this.iD_SERVIDORTextBox.Text = this.sERVIDORTableAdapter.getNextID_Serv().ToString();
        }

        private void AlterarServAdmin(object sender, EventArgs e)
        {
            this.Validate();
            this.sERVIDORBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet2);
            Reload();
        }

        private void ApagarServAdmin(object sender, EventArgs e)
        {
            try
            {
                this.sERVIDORBindingSource.RemoveCurrent();
            }
            catch
            {
                MessageBox.Show("Existem contas no servidor!");
            }
            this.tableAdapterManager.UpdateAll(this.dataSet2);
            Reload();
        }
        
        private void CriarContaAdmin(object sender, EventArgs e)
        {
            this.cONTABindingSource.AddNew();
            this.iD_CONTATextBox.Text = this.cONTATableAdapter.getNextID_Conta().ToString();
        }

        private void AlterarContaAdmin(object sender, EventArgs e)
        {
            this.iSLOGGEDTextBox.Text = "0";
            this.Validate();
            this.cONTABindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet2);
        }

        private void ApagarContaAdmin(object sender, EventArgs e)
        {
            try
            {
                this.cONTABindingSource.RemoveCurrent();
                this.tableAdapterManager.UpdateAll(this.dataSet2);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: Não é possível remover conta com personagens");
            }
        }

        private void CriarPersAdmin(object sender, EventArgs e)
        {
            this.pERSONAGEMBindingSource.AddNew();
            this.bANCOBindingSource1.AddNew();
            if (this.iD_CLANTextBox.Text != "")
                this.pERTENCEBindingSource1.AddNew();
            this.iD_PERSONAGEMTextBox.Text = this.pERSONAGEMTableAdapter.getNextID_Pers().ToString();
        }

        private void AlterarPersAdmin(object sender, EventArgs e)
        {
            String tempvar = this.iD_CLANTextBox.Text;
            String tempvarisLeader = this.iSLEADERTextBox.Text;

            if (this.cREDITOSTextBox.Text == "")
            {
                this.cREDITOSTextBox.Text = "0";
            }
            
            String tempvarCreds = this.cREDITOSTextBox.Text;

            if (this.iD_PERSONAGEMTextBox_Banco.Text == "")
            {
                this.iD_PERSONAGEMTextBox_Banco.Text = this.iD_PERSONAGEMTextBox.Text;
                this.bANCOBindingSource1.AddNew();
            }

            if (tempvar != "")
            {
                this.iD_PERSONAGEMTextBox_lan.Text = this.iD_PERSONAGEMTextBox.Text;
                this.pERTENCEBindingSource1.AddNew();
            }

            this.cREDITOSTextBox.Text = tempvarCreds;
            this.iD_CLANTextBox.Text = tempvar;
            this.iSLEADERTextBox.Text = tempvarisLeader;
            this.iSSUBLEADERTextBox.Text = (0).ToString();
            this.Validate();
            this.pERSONAGEMBindingSource.EndEdit();
            this.bANCOBindingSource1.EndEdit();
            this.pERTENCEBindingSource1.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet2);
            Reload();
        }

        private void ApagarPersAdmin(object sender, EventArgs e)
        {
            try
            {
                this.pERTENCEBindingSource1.RemoveCurrent();
            }
            catch { }
            try
            {
                this.bANCOBindingSource1.RemoveCurrent();
            }
            catch { }
            this.pERSONAGEMBindingSource.RemoveCurrent();
            this.tableAdapterManager.UpdateAll(this.dataSet2);
            Reload();
        }

        private void CriarClanAdmin(object sender, EventArgs e)
        {
            this.cLANBindingSource.AddNew();
            this.iD_CLANTextBox1.Text = this.cLANTableAdapter.getNextID_Clan().ToString();
        }

        private void AlterarClanAdmin(object sender, EventArgs e)
        {
            this.Validate();
            this.cLANBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet2);
        }

        private void ApagarClanAdmin(object sender, EventArgs e)
        {
            try
            {
                this.cLANBindingSource.RemoveCurrent();
            }
            catch
            {
                MessageBox.Show("Existem personagens neste clan!");
            }
            this.tableAdapterManager.UpdateAll(this.dataSet2);
        }

        private void CriarClasseAdmin(object sender, EventArgs e)
        {
            this.cLASSEBindingSource.AddNew();
            this.iD_CLASSTextBox1.Text = this.cLASSETableAdapter.getNextID_Class().ToString();
        }

        private void AlterarClasseAdmin(object sender, EventArgs e)
        {
            this.Validate();
            this.cLASSEBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet2);
        }

        private void ApagarClasseAdmin(object sender, EventArgs e)
        {
            try
            {
                this.cLASSEBindingSource.RemoveCurrent();
            }
            catch
            {
                MessageBox.Show("Existem personagens com esta classe!");
            }
            this.tableAdapterManager.UpdateAll(this.dataSet2);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.BANCO' table. You can move, or remove it, as needed.
            this.bANCOTableAdapter.Fill(this.dataSet2.BANCO);
            // TODO: This line of code loads data into the 'dataSet2.CLASSE' table. You can move, or remove it, as needed.
            this.cLASSETableAdapter.Fill(this.dataSet2.CLASSE);
            // TODO: This line of code loads data into the 'dataSet2.PERSONAGEM' table. You can move, or remove it, as needed.
            this.pERSONAGEMTableAdapter.Fill(this.dataSet2.PERSONAGEM);
            // TODO: This line of code loads data into the 'dataSet2.PERTENCE' table. You can move, or remove it, as needed.
            this.pERTENCETableAdapter.Fill(this.dataSet2.PERTENCE);
            // TODO: This line of code loads data into the 'dataSet1.CLAN' table. You can move, or remove it, as needed.
            this.cLANTableAdapter.Fill(this.dataSet2.CLAN);
            // TODO: This line of code loads data into the 'dataSet1.SERVIDOR' table. You can move, or remove it, as needed.
            this.sERVIDORTableAdapter.Fill(this.dataSet2.SERVIDOR);
            // TODO: This line of code loads data into the 'dataSet1.CONTA' table. You can move, or remove it, as needed.
            this.cONTATableAdapter.Fill(this.dataSet2.CONTA);

            this.UsernameValue.Text = this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("USERNAME")].ToString();
            this.Username = this.UsernameValue.Text;
            this.ServerValue.Text = this.sERVIDORTableAdapter.GetData().Select("ID_SERVIDOR = " + this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ID_SERVIDOR")].ToString())[0].ItemArray[this.sERVIDORTableAdapter.GetData().Columns.IndexOf("NOME_SERV")].ToString();
            this.RegionValue.Text = this.sERVIDORTableAdapter.GetData().Select("ID_SERVIDOR = " + this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("ID_SERVIDOR")].ToString())[0].ItemArray[this.sERVIDORTableAdapter.GetData().Columns.IndexOf("REGIAO")].ToString();
            this.EmailValue.Text = this.cONTATableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[0].ItemArray[this.cONTATableAdapter.GetData().Columns.IndexOf("EMAIL")].ToString();

            try
            {
                this.pictureBox2.Image = Image.FromFile(@"imgs\" + this.ServerValue.Text + ".png");
            }
            catch
            {
                this.pictureBox2.Image = this.pictureBox2.BackgroundImage;
            }

            if (AdminMode)
            {
                this.Text = "Shrekovski (Admin): " + this.Username; // username do admin...
            }
            else
            {
                this.Text = "Shrekovski (User): " + this.Username;
                // desativar funções de administrador para utilizadores normais
                this.tabControl1.TabPages.Remove(this.tabAdmin);
            }

            if (this.AccountStatus != "")
            {
                this.tabControl1.Enabled = false;
            }
            else
            {
                this.tabControl1.TabPages.Clear();

                this.tabControl1.TabPages.Add(this.tabPerfil);
                this.tabControl1.TabPages.Add(this.tabConta);
                this.tabControl1.TabPages.Add(this.tabPersonagens);
                this.tabControl1.TabPages.Add(this.tabClan);
                if (AdminMode)
                    this.tabControl1.TabPages.Add(this.tabAdmin);

                this.tabControl2.TabPages.Clear();
                this.tabControl3.TabPages.Clear();

                this.tabControl2.TabPages.Add(this.tabPers1);
                this.tabControl2.TabPages.Add(this.tabPers2);
                this.tabControl2.TabPages.Add(this.tabPers3);
                this.tabControl2.TabPages.Add(this.tabPers4);
                this.tabControl2.TabPages.Add(this.tabPers5);

                this.tabControl3.TabPages.Add(this.tabClan1);
                this.tabControl3.TabPages.Add(this.tabClan2);
                this.tabControl3.TabPages.Add(this.tabClan3);
                this.tabControl3.TabPages.Add(this.tabClan4);
                this.tabControl3.TabPages.Add(this.tabClan5);

                this.listBox1.Items.Clear();
                this.listBox2.Items.Clear();
                this.listBox3.Items.Clear();
                this.listBox4.Items.Clear();
                this.listBox5.Items.Clear();

                SlotUsed = new bool[5] { false, false, false, false, false };
                ClanUsed = new bool[5] { false, false, false, false, false };

                ClanIDs = new List<int>();
                CharNames = new List<String>();
                ClanID = -1;

                this.button1.Enabled = true;
                this.button2.Enabled = true;
                this.button3.Enabled = true;
                this.button4.Enabled = true;
                this.button5.Enabled = true;
                this.button6.Enabled = true;
                this.button7.Enabled = true;
                this.button8.Enabled = true;
                this.button9.Enabled = true;
                this.button10.Enabled = true;
                this.button11.Enabled = false;
                this.button12.Enabled = false;
                this.button13.Enabled = false;
                this.button14.Enabled = false;
                this.button15.Enabled = false;
                this.button16.Enabled = true;
                this.button17.Enabled = true;
                this.button18.Enabled = true;
                this.button19.Enabled = true;
                this.button20.Enabled = true;

                this.label76.Text = "";
                this.label79.Text = "";
                this.label86.Text = "";
                this.label93.Text = "";
                this.label100.Text = "";

                if (this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text).Length > 0)
                {
                    for (int i = 0; i < this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text).Length; i++)
                    {
                        switch (int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("SLOT")].ToString()))
                        {
                            // PERSONAGEM 1
                            case 1:
                                SlotUsed[0] = true;
                                // EDITAR PERSONAGENS TAB e CLAN
                                // ID
                                this.label69.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString();
                                // NOME
                                this.label67.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString();
                                this.CharNames.Add(this.label67.Text);
                                // GENERO
                                this.label65.Text = convertGenero(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("GENERO")].ToString());
                                // NOME CLASS
                                this.label59.Text = this.cLASSETableAdapter.GetData().Select("ID_CLASS = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_CLASS")].ToString()))[0].ItemArray[this.cLASSETableAdapter.GetData().Columns.IndexOf("NOME_CLASS")].ToString();
                                // CRÉDITOS (Dinheiro)
                                if (this.bANCOTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.label69.Text)).Length == 1)
                                {
                                    this.label57.Text = this.bANCOTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.label69.Text))[0].ItemArray[this.bANCOTableAdapter.GetData().Columns.IndexOf("CREDITOS")].ToString() + " $hrek";
                                }
                                else
                                {
                                    this.label57.Text = "0 $hrek";
                                }

                                try
                                {
                                    this.pictureBox3.Image = Image.FromFile(@"imgs\" + this.label59.Text + ".png");
                                }
                                catch
                                {
                                    this.pictureBox3.Image = this.pictureBox3.BackgroundImage;
                                }

                                // Verificação de clan
                                if (this.cLANTableAdapter.GetData().Select().Length > 0)
                                {
                                    // NOME CLAN
                                    if (this.pERTENCETableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString())).Length == 1)
                                    {
                                        // CRIAR CLAN
                                        this.button10.Enabled = false;
                                        // ADERIR CLAN
                                        this.button16.Enabled = false;
                                        // ID CLAN
                                        this.ClanID = int.Parse(this.cLANTableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_CLAN")].ToString()))[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("ID_CLAN")].ToString());
                                        // NOME CLAN
                                        this.label63.Text = this.cLANTableAdapter.GetData().Select("ID_CLAN = " + this.ClanID)[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("NOME_CLAN")].ToString();
                                        if (!ClanIDs.Contains(ClanID))
                                        {
                                            ClanUsed[0] = true;
                                            ClanIDs.Add(ClanID);
                                            this.tabClan1.Text = "Clan - " + this.label63.Text;
                                            // ADICIONA MEMBROS Á LISTA
                                            for (int j = 0; j < this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID).Length; j++)
                                            {
                                                this.listBox1.Items.Add(this.pERSONAGEMTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID)[j].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString());
                                            }
                                            // ID CLAN
                                            this.label72.Text = this.ClanID.ToString();
                                            // NOME CLAN TABCLAN
                                            this.label74.Text = this.label63.Text;
                                            // LEADER CLAN
                                            this.label76.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID + " AND ISLEADER = " + 1)[0].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString();
                                        }
                                    }
                                    else
                                    {
                                        this.label63.Text = "Nenhum";
                                        this.button9.Enabled = false;
                                    }
                                }
                                break;
                            // PERSONAGEM 2
                            case 2:
                                SlotUsed[1] = true;
                                // EDITAR PERSONAGENS TAB e CLAN
                                // ID
                                this.label13.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString();
                                // NOME
                                this.label11.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString();
                                this.CharNames.Add(this.label11.Text);
                                // GENERO
                                this.label9.Text = convertGenero(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("GENERO")].ToString());
                                // NOME CLASS
                                this.label3.Text = this.cLASSETableAdapter.GetData().Select("ID_CLASS = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_CLASS")].ToString()))[0].ItemArray[this.cLASSETableAdapter.GetData().Columns.IndexOf("NOME_CLASS")].ToString();
                                // CRÉDITOS (Dinheiro)
                                if (this.bANCOTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.label13.Text)).Length == 1)
                                {
                                    this.label1.Text = this.bANCOTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.label13.Text))[0].ItemArray[this.bANCOTableAdapter.GetData().Columns.IndexOf("CREDITOS")].ToString() + " $hrek";
                                }
                                else
                                {
                                    this.label1.Text = "0 $hrek";
                                }

                                try
                                {
                                    this.pictureBox4.Image = Image.FromFile(@"imgs\" + this.label3.Text + ".png");
                                }
                                catch
                                {
                                    this.pictureBox4.Image = this.pictureBox4.BackgroundImage;
                                }

                                // Verificação de clan
                                if (this.cLANTableAdapter.GetData().Select().Length > 0)
                                {
                                    // NOME CLAN
                                    if (this.pERTENCETableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString())).Length == 1)
                                    {
                                        // CRIAR CLAN
                                        this.button2.Enabled = false;
                                        // ADERIR CLAN
                                        this.button17.Enabled = false;
                                        // ID CLAN
                                        this.ClanID = int.Parse(this.cLANTableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_CLAN")].ToString()))[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("ID_CLAN")].ToString());
                                        // NOME CLAN
                                        this.label7.Text = this.cLANTableAdapter.GetData().Select("ID_CLAN = " + this.ClanID)[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("NOME_CLAN")].ToString();
                                        if (!ClanIDs.Contains(ClanID))
                                        {
                                            ClanUsed[1] = true;
                                            ClanIDs.Add(ClanID);
                                            this.tabClan2.Text = "Clan - " + this.label7.Text;
                                            // ADICIONA MEMBROS Á LISTA
                                            for (int j = 0; j < this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID).Length; j++)
                                            {
                                                this.listBox2.Items.Add(this.pERSONAGEMTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID)[j].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString());
                                            }
                                            // ID CLAN
                                            this.label83.Text = this.ClanID.ToString();
                                            // NOME CLAN TABCLAN
                                            this.label81.Text = this.label7.Text;
                                            // LEADER CLAN
                                            this.label79.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID + " AND ISLEADER = " + 1)[0].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString();
                                        }
                                    }
                                    else
                                    {
                                        this.label7.Text = "Nenhum";
                                        this.button1.Enabled = false;
                                    }
                                }
                                break;
                            // PERSONAGEM 3
                            case 3:
                                SlotUsed[2] = true;
                                // EDITAR PERSONAGENS TAB e CLAN
                                // ID
                                this.label27.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString();
                                // NOME
                                this.label25.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString();
                                this.CharNames.Add(this.label25.Text);
                                // GENERO
                                this.label23.Text = convertGenero(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("GENERO")].ToString());
                                // NOME CLASS
                                this.label17.Text = this.cLASSETableAdapter.GetData().Select("ID_CLASS = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_CLASS")].ToString()))[0].ItemArray[this.cLASSETableAdapter.GetData().Columns.IndexOf("NOME_CLASS")].ToString();
                                // CRÉDITOS (Dinheiro)
                                if (this.bANCOTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.label27.Text)).Length == 1)
                                {
                                    this.label15.Text = this.bANCOTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.label27.Text))[0].ItemArray[this.bANCOTableAdapter.GetData().Columns.IndexOf("CREDITOS")].ToString() + " $hrek";
                                }
                                else
                                {
                                    this.label15.Text = "0 $hrek";
                                }
                                
                                try
                                {
                                    this.pictureBox5.Image = Image.FromFile(@"imgs\" + this.label17.Text + ".png");
                                }
                                catch
                                {
                                    this.pictureBox5.Image = this.pictureBox5.BackgroundImage;
                                }

                                // Verificação de clan
                                if (this.cLANTableAdapter.GetData().Select().Length > 0)
                                {
                                    // NOME CLAN
                                    if (this.pERTENCETableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString())).Length == 1)
                                    {
                                        // CRIAR CLAN
                                        this.button4.Enabled = false;
                                        // ADERIR CLAN
                                        this.button18.Enabled = false;
                                        // ID CLAN
                                        this.ClanID = int.Parse(this.cLANTableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_CLAN")].ToString()))[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("ID_CLAN")].ToString());
                                        // NOME CLAN
                                        this.label21.Text = this.cLANTableAdapter.GetData().Select("ID_CLAN = " + this.ClanID)[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("NOME_CLAN")].ToString();
                                        if (!ClanIDs.Contains(ClanID))
                                        {
                                            ClanUsed[2] = true;
                                            ClanIDs.Add(ClanID);
                                            this.tabClan3.Text = "Clan - " + this.label21.Text;
                                            // ADICIONA MEMBROS Á LISTA
                                            for (int j = 0; j < this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID).Length; j++)
                                            {
                                                this.listBox3.Items.Add(this.pERSONAGEMTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID)[j].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString());
                                            }
                                            // ID CLAN
                                            this.label90.Text = this.ClanID.ToString();
                                            // NOME CLAN TABCLAN
                                            this.label88.Text = this.label21.Text;
                                            // LEADER CLAN
                                            this.label86.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID + " AND ISLEADER = " + 1)[0].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString();
                                        }
                                    }
                                    else
                                    {
                                        this.label21.Text = "Nenhum";
                                        this.button3.Enabled = false;
                                    }
                                }
                                break;
                            // PERSONAGEM 4
                            case 4:
                                SlotUsed[3] = true;
                                // EDITAR PERSONAGENS TAB e CLAN
                                // ID
                                this.label41.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString();
                                // NOME
                                this.label39.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString();
                                this.CharNames.Add(this.label39.Text);
                                // GENERO
                                this.label37.Text = convertGenero(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("GENERO")].ToString());
                                // NOME CLASS
                                this.label31.Text = this.cLASSETableAdapter.GetData().Select("ID_CLASS = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_CLASS")].ToString()))[0].ItemArray[this.cLASSETableAdapter.GetData().Columns.IndexOf("NOME_CLASS")].ToString();
                                // CRÉDITOS (Dinheiro)
                                if (this.bANCOTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.label41.Text)).Length == 1)
                                {
                                    this.label29.Text = this.bANCOTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.label41.Text))[0].ItemArray[this.bANCOTableAdapter.GetData().Columns.IndexOf("CREDITOS")].ToString() + " $hrek";
                                }
                                else
                                {
                                    this.label29.Text = "0 $hrek";
                                }

                                try
                                {
                                    this.pictureBox6.Image = Image.FromFile(@"imgs\" + this.label31.Text + ".png");
                                }
                                catch
                                {
                                    this.pictureBox6.Image = this.pictureBox6.BackgroundImage;
                                }

                                // Verificação de clan
                                if (this.cLANTableAdapter.GetData().Select().Length > 0)
                                {
                                    if (this.pERTENCETableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString())).Length == 1)
                                    {
                                        // CRIAR CLAN
                                        this.button6.Enabled = false;
                                        // ADERIR CLAN
                                        this.button19.Enabled = false;
                                        // ID CLAN
                                        this.ClanID = int.Parse(this.cLANTableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_CLAN")].ToString()))[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("ID_CLAN")].ToString());
                                        // NOME CLAN
                                        this.label35.Text = this.cLANTableAdapter.GetData().Select("ID_CLAN = " + this.ClanID)[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("NOME_CLAN")].ToString();
                                        if (!ClanIDs.Contains(ClanID))
                                        {
                                            ClanUsed[3] = true;
                                            ClanIDs.Add(ClanID);
                                            this.tabClan4.Text = "Clan - " + this.label35.Text;
                                            // ADICIONA MEMBROS Á LISTA
                                            for (int j = 0; j < this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID).Length; j++)
                                            {
                                                this.listBox4.Items.Add(this.pERSONAGEMTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID)[j].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString());
                                            }
                                            // ID CLAN
                                            this.label97.Text = this.ClanID.ToString();
                                            // NOME CLAN TABCLAN
                                            this.label95.Text = this.label35.Text;
                                            // LEADER CLAN
                                            this.label93.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID + " AND ISLEADER = " + 1)[0].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString();
                                        }
                                    }
                                    else
                                    {
                                        this.label35.Text = "Nenhum";
                                        this.button5.Enabled = false;
                                    }
                                }
                                break;
                            // PERSONAGEM 5
                            case 5:
                                SlotUsed[4] = true;
                                // EDITAR PERSONAGENS TAB e CLAN
                                // ID
                                this.label55.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString();
                                // NOME
                                this.label53.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString();
                                this.CharNames.Add(this.label53.Text);
                                // GENERO
                                this.label51.Text = convertGenero(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("GENERO")].ToString());
                                // NOME CLASS
                                this.label45.Text = this.cLASSETableAdapter.GetData().Select("ID_CLASS = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_CLASS")].ToString()))[0].ItemArray[this.cLASSETableAdapter.GetData().Columns.IndexOf("NOME_CLASS")].ToString();
                                // CRÉDITOS (Dinheiro)
                                if (this.bANCOTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.label55.Text)).Length == 1)
                                {
                                    this.label43.Text = this.bANCOTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.label55.Text))[0].ItemArray[this.bANCOTableAdapter.GetData().Columns.IndexOf("CREDITOS")].ToString() + " $hrek";
                                }
                                else
                                {
                                    this.label43.Text = "0 $hrek";
                                }

                                try
                                {
                                    this.pictureBox7.Image = Image.FromFile(@"imgs\" + this.label45.Text + ".png");
                                }
                                catch
                                {
                                    this.pictureBox7.Image = this.pictureBox7.BackgroundImage;
                                }

                                // Verificação de clan
                                if (this.cLANTableAdapter.GetData().Select().Length > 0)
                                {
                                    if (this.pERTENCETableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString())).Length == 1)
                                    {
                                        // CRIAR CLAN
                                        this.button8.Enabled = false;
                                        // ADERIR CLAN
                                        this.button20.Enabled = false;
                                        // ID CLAN
                                        this.ClanID = int.Parse(this.cLANTableAdapter.GetData().Select("ID_CLAN = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERSONAGEMTableAdapter.GetData().Select("ID_CONTA = " + this.IDValue.Text)[i].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_CLAN")].ToString()))[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("ID_CLAN")].ToString());
                                        // NOME CLAN
                                        this.label49.Text = this.cLANTableAdapter.GetData().Select("ID_CLAN = " + this.ClanID)[0].ItemArray[this.cLANTableAdapter.GetData().Columns.IndexOf("NOME_CLAN")].ToString();
                                        if (!ClanIDs.Contains(ClanID))
                                        {
                                            ClanUsed[4] = true;
                                            ClanIDs.Add(ClanID);
                                            this.tabClan5.Text = "Clan - " + this.label49.Text;
                                            // ADICIONA MEMBROS Á LISTA
                                            for (int j = 0; j < this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID).Length; j++)
                                            {
                                                this.listBox5.Items.Add(this.pERSONAGEMTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID)[j].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString());
                                            }
                                            // ID CLAN
                                            this.label104.Text = this.ClanID.ToString();
                                            // NOME CLAN TABCLAN
                                            this.label102.Text = this.label49.Text;
                                            // LEADER CLAN
                                            this.label100.Text = this.pERSONAGEMTableAdapter.GetData().Select("ID_PERSONAGEM = " + int.Parse(this.pERTENCETableAdapter.GetData().Select("ID_CLAN = " + this.ClanID + " AND ISLEADER = " + 1)[0].ItemArray[this.pERTENCETableAdapter.GetData().Columns.IndexOf("ID_PERSONAGEM")].ToString()))[0].ItemArray[this.pERSONAGEMTableAdapter.GetData().Columns.IndexOf("NOME_PERS")].ToString();
                                        }
                                    }
                                    else
                                    {
                                        this.label49.Text = "Nenhum";
                                        this.button7.Enabled = false;
                                    }
                                }
                                break;
                            default:
                                MessageBox.Show("Erro...");
                                break;
                        }
                    }

                    for (int i = (SlotUsed.Length - 1); i >= 0; i--)
                    {
                        if (!SlotUsed[i])
                        {
                            switch (i)
                            {
                                case 0:
                                    this.tabControl2.TabPages.Remove(this.tabPers1);
                                    break;
                                case 1:
                                    this.tabControl2.TabPages.Remove(this.tabPers2);
                                    break;
                                case 2:
                                    this.tabControl2.TabPages.Remove(this.tabPers3);
                                    break;
                                case 3:
                                    this.tabControl2.TabPages.Remove(this.tabPers4);
                                    break;
                                case 4:
                                    this.tabControl2.TabPages.Remove(this.tabPers5);
                                    break;
                            }
                        }
                    }

                    for (int i = (ClanUsed.Length - 1); i >= 0; i--)
                    {
                        if (!ClanUsed[i])
                        {
                            switch (i)
                            {
                                case 0:
                                    this.tabControl3.TabPages.Remove(this.tabClan1);
                                    break;
                                case 1:
                                    this.tabControl3.TabPages.Remove(this.tabClan2);
                                    break;
                                case 2:
                                    this.tabControl3.TabPages.Remove(this.tabClan3);
                                    break;
                                case 3:
                                    this.tabControl3.TabPages.Remove(this.tabClan4);
                                    break;
                                case 4:
                                    this.tabControl3.TabPages.Remove(this.tabClan5);
                                    break;
                            }
                        }
                    }

                    if (this.tabControl2.TabPages.Count == 0)
                        this.tabControl1.TabPages.Remove(this.tabPersonagens);
                    if (this.tabControl3.TabPages.Count == 0)
                        this.tabControl1.TabPages.Remove(this.tabClan);
                    // Butão Dissolver clan
                    for (int i = 0; i < 5; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                if (this.CharNames.Contains(this.label76.Text))
                                    this.button11.Enabled = true;
                                break;
                            case 1:
                                if (this.CharNames.Contains(this.label79.Text))
                                    this.button12.Enabled = true;
                                break;
                            case 2:
                                if (this.CharNames.Contains(this.label86.Text))
                                    this.button13.Enabled = true;
                                break;
                            case 3:
                                if (this.CharNames.Contains(this.label93.Text))
                                    this.button14.Enabled = true;
                                break;
                            case 4:
                                if (this.CharNames.Contains(this.label100.Text))
                                    this.button15.Enabled = true;
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    this.tabControl1.TabPages.Remove(this.tabPersonagens);
                    this.tabControl1.TabPages.Remove(this.tabClan);
                }
            }
        }

        public void Reload()
        {
            Form2_Load(null, null);
        }

        private void Form2_Closed(object sender, FormClosedEventArgs e)
        {
            this.form.Show();
        }

        private void rEGIAOTextBox_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();
            ((TextBox)sender).Text = ((TextBox)sender).Text.Replace(" ", "");
            ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
        }
    }
}
