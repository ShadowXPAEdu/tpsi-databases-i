namespace Shrekovski
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuccessCC = new System.Windows.Forms.Label();
            this.ErroCC = new System.Windows.Forms.Label();
            this.ErroServidorCriarConta = new System.Windows.Forms.Label();
            this.ErroPassCriarConta = new System.Windows.Forms.Label();
            this.ErroEmailCriarConta = new System.Windows.Forms.Label();
            this.ErroUsernameCriarConta = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sERVIDORBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new Shrekovski.DataSet2();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ErroL = new System.Windows.Forms.Label();
            this.ErroServidorLogin = new System.Windows.Forms.Label();
            this.ErroPasswordLogin = new System.Windows.Forms.Label();
            this.ErroUsernameLogin = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.sERVIDORBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sERVIDORTableAdapter = new Shrekovski.DataSet2TableAdapters.SERVIDORTableAdapter();
            this.cONTABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cONTATableAdapter = new Shrekovski.DataSet2TableAdapters.CONTATableAdapter();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sERVIDORBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sERVIDORBindingSource1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cONTABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 176);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.8538F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(978, 334);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SuccessCC);
            this.groupBox1.Controls.Add(this.ErroCC);
            this.groupBox1.Controls.Add(this.ErroServidorCriarConta);
            this.groupBox1.Controls.Add(this.ErroPassCriarConta);
            this.groupBox1.Controls.Add(this.ErroEmailCriarConta);
            this.groupBox1.Controls.Add(this.ErroUsernameCriarConta);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 328);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criar Conta";
            // 
            // SuccessCC
            // 
            this.SuccessCC.AutoSize = true;
            this.SuccessCC.ForeColor = System.Drawing.Color.Green;
            this.SuccessCC.Location = new System.Drawing.Point(298, 261);
            this.SuccessCC.Name = "SuccessCC";
            this.SuccessCC.Size = new System.Drawing.Size(0, 13);
            this.SuccessCC.TabIndex = 14;
            // 
            // ErroCC
            // 
            this.ErroCC.AutoSize = true;
            this.ErroCC.ForeColor = System.Drawing.Color.Red;
            this.ErroCC.Location = new System.Drawing.Point(297, 261);
            this.ErroCC.Name = "ErroCC";
            this.ErroCC.Size = new System.Drawing.Size(0, 13);
            this.ErroCC.TabIndex = 13;
            // 
            // ErroServidorCriarConta
            // 
            this.ErroServidorCriarConta.AutoSize = true;
            this.ErroServidorCriarConta.ForeColor = System.Drawing.Color.Red;
            this.ErroServidorCriarConta.Location = new System.Drawing.Point(348, 196);
            this.ErroServidorCriarConta.Name = "ErroServidorCriarConta";
            this.ErroServidorCriarConta.Size = new System.Drawing.Size(0, 13);
            this.ErroServidorCriarConta.TabIndex = 12;
            // 
            // ErroPassCriarConta
            // 
            this.ErroPassCriarConta.AutoSize = true;
            this.ErroPassCriarConta.ForeColor = System.Drawing.Color.Red;
            this.ErroPassCriarConta.Location = new System.Drawing.Point(348, 147);
            this.ErroPassCriarConta.Name = "ErroPassCriarConta";
            this.ErroPassCriarConta.Size = new System.Drawing.Size(0, 13);
            this.ErroPassCriarConta.TabIndex = 11;
            // 
            // ErroEmailCriarConta
            // 
            this.ErroEmailCriarConta.AutoSize = true;
            this.ErroEmailCriarConta.ForeColor = System.Drawing.Color.Red;
            this.ErroEmailCriarConta.Location = new System.Drawing.Point(348, 96);
            this.ErroEmailCriarConta.Name = "ErroEmailCriarConta";
            this.ErroEmailCriarConta.Size = new System.Drawing.Size(0, 13);
            this.ErroEmailCriarConta.TabIndex = 10;
            // 
            // ErroUsernameCriarConta
            // 
            this.ErroUsernameCriarConta.AutoSize = true;
            this.ErroUsernameCriarConta.ForeColor = System.Drawing.Color.Red;
            this.ErroUsernameCriarConta.Location = new System.Drawing.Point(347, 46);
            this.ErroUsernameCriarConta.Name = "ErroUsernameCriarConta";
            this.ErroUsernameCriarConta.Size = new System.Drawing.Size(0, 13);
            this.ErroUsernameCriarConta.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Criar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.sERVIDORBindingSource;
            this.comboBox1.DisplayMember = "NOME_SERV";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(141, 196);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.ValueMember = "ID_SERVIDOR";
            // 
            // sERVIDORBindingSource
            // 
            this.sERVIDORBindingSource.DataMember = "SERVIDOR";
            this.sERVIDORBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet1";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Servidor:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(141, 147);
            this.textBox3.MaxLength = 15;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(200, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(141, 96);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "E-mail:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(141, 46);
            this.textBox1.MaxLength = 12;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome de Utilizador:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ErroL);
            this.groupBox2.Controls.Add(this.ErroServidorLogin);
            this.groupBox2.Controls.Add(this.ErroPasswordLogin);
            this.groupBox2.Controls.Add(this.ErroUsernameLogin);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(492, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 328);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Login";
            // 
            // ErroL
            // 
            this.ErroL.AutoSize = true;
            this.ErroL.ForeColor = System.Drawing.Color.Red;
            this.ErroL.Location = new System.Drawing.Point(297, 260);
            this.ErroL.Name = "ErroL";
            this.ErroL.Size = new System.Drawing.Size(0, 13);
            this.ErroL.TabIndex = 10;
            // 
            // ErroServidorLogin
            // 
            this.ErroServidorLogin.AutoSize = true;
            this.ErroServidorLogin.ForeColor = System.Drawing.Color.Red;
            this.ErroServidorLogin.Location = new System.Drawing.Point(348, 147);
            this.ErroServidorLogin.Name = "ErroServidorLogin";
            this.ErroServidorLogin.Size = new System.Drawing.Size(0, 13);
            this.ErroServidorLogin.TabIndex = 9;
            // 
            // ErroPasswordLogin
            // 
            this.ErroPasswordLogin.AutoSize = true;
            this.ErroPasswordLogin.ForeColor = System.Drawing.Color.Red;
            this.ErroPasswordLogin.Location = new System.Drawing.Point(348, 96);
            this.ErroPasswordLogin.Name = "ErroPasswordLogin";
            this.ErroPasswordLogin.Size = new System.Drawing.Size(0, 13);
            this.ErroPasswordLogin.TabIndex = 8;
            // 
            // ErroUsernameLogin
            // 
            this.ErroUsernameLogin.AutoSize = true;
            this.ErroUsernameLogin.ForeColor = System.Drawing.Color.Red;
            this.ErroUsernameLogin.Location = new System.Drawing.Point(348, 46);
            this.ErroUsernameLogin.Name = "ErroUsernameLogin";
            this.ErroUsernameLogin.Size = new System.Drawing.Size(0, 13);
            this.ErroUsernameLogin.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(191, 260);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.sERVIDORBindingSource1;
            this.comboBox2.DisplayMember = "NOME_SERV";
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(141, 147);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 21);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.ValueMember = "ID_SERVIDOR";
            // 
            // sERVIDORBindingSource1
            // 
            this.sERVIDORBindingSource1.DataMember = "SERVIDOR";
            this.sERVIDORBindingSource1.DataSource = this.dataSet2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Servidor:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(141, 96);
            this.textBox5.MaxLength = 15;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(200, 20);
            this.textBox5.TabIndex = 3;
            this.textBox5.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Password:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(141, 46);
            this.textBox4.MaxLength = 12;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(200, 20);
            this.textBox4.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nome de Utilizador:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.7232F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.2768F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(984, 513);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(365, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(253, 167);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // sERVIDORTableAdapter
            // 
            this.sERVIDORTableAdapter.ClearBeforeFill = true;
            // 
            // cONTABindingSource
            // 
            this.cONTABindingSource.DataMember = "CONTA";
            this.cONTABindingSource.DataSource = this.dataSet2;
            // 
            // cONTATableAdapter
            // 
            this.cONTATableAdapter.ClearBeforeFill = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1035, 543);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "label8";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 537);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tableLayoutPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shrekovski ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sERVIDORBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sERVIDORBindingSource1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cONTABindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ErroUsernameCriarConta;
        private System.Windows.Forms.Label ErroEmailCriarConta;
        private System.Windows.Forms.Label ErroPassCriarConta;
        private System.Windows.Forms.Label ErroServidorCriarConta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label ErroUsernameLogin;
        private System.Windows.Forms.Label ErroPasswordLogin;
        private System.Windows.Forms.Label ErroServidorLogin;
        private System.Windows.Forms.Label ErroCC;
        private System.Windows.Forms.Label ErroL;
        private System.Windows.Forms.Label SuccessCC;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource sERVIDORBindingSource;
        private DataSet2TableAdapters.SERVIDORTableAdapter sERVIDORTableAdapter;
        private System.Windows.Forms.BindingSource cONTABindingSource;
        private DataSet2TableAdapters.CONTATableAdapter cONTATableAdapter;
        private System.Windows.Forms.BindingSource sERVIDORBindingSource1;
        private System.Windows.Forms.Label label8;
    }
}

