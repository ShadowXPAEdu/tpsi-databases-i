namespace Shrekovski
{
    partial class JoinClan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoinClan));
            this.dataSet2 = new Shrekovski.DataSet2();
            this.cLANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cLANTableAdapter = new Shrekovski.DataSet2TableAdapters.CLANTableAdapter();
            this.pERTENCEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pERTENCETableAdapter = new Shrekovski.DataSet2TableAdapters.PERTENCETableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLANBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pERTENCEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cLANBindingSource
            // 
            this.cLANBindingSource.DataMember = "CLAN";
            this.cLANBindingSource.DataSource = this.dataSet2;
            // 
            // cLANTableAdapter
            // 
            this.cLANTableAdapter.ClearBeforeFill = true;
            // 
            // pERTENCEBindingSource
            // 
            this.pERTENCEBindingSource.DataMember = "PERTENCE";
            this.pERTENCEBindingSource.DataSource = this.dataSet2;
            // 
            // pERTENCETableAdapter
            // 
            this.pERTENCETableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Clan existente:";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.cLANBindingSource;
            this.comboBox1.DisplayMember = "NOME_CLAN";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(40, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.ValueMember = "ID_CLAN";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CS_Okay_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CS_Cancel_Click);
            // 
            // JoinClan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 146);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JoinClan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aderir Clan";
            this.Load += new System.EventHandler(this.JoinClan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cLANBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pERTENCEBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource cLANBindingSource;
        private DataSet2TableAdapters.CLANTableAdapter cLANTableAdapter;
        private System.Windows.Forms.BindingSource pERTENCEBindingSource;
        private DataSet2TableAdapters.PERTENCETableAdapter pERTENCETableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}