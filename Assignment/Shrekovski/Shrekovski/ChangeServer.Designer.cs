namespace Shrekovski
{
    partial class ChangeServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeServer));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sERVIDORBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new Shrekovski.DataSet2();
            this.sERVIDORTableAdapter = new Shrekovski.DataSet2TableAdapters.SERVIDORTableAdapter();
            this.CS_Okay = new System.Windows.Forms.Button();
            this.CS_Cancel = new System.Windows.Forms.Button();
            this.CS_Label1 = new System.Windows.Forms.Label();
            this.cONTABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cONTATableAdapter = new Shrekovski.DataSet2TableAdapters.CONTATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sERVIDORBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cONTABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.sERVIDORBindingSource;
            this.comboBox1.DisplayMember = "NOME_SERV";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(40, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "ID_SERVIDOR";
            // 
            // sERVIDORBindingSource
            // 
            this.sERVIDORBindingSource.DataMember = "SERVIDOR";
            this.sERVIDORBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sERVIDORTableAdapter
            // 
            this.sERVIDORTableAdapter.ClearBeforeFill = true;
            // 
            // CS_Okay
            // 
            this.CS_Okay.Location = new System.Drawing.Point(105, 105);
            this.CS_Okay.Name = "CS_Okay";
            this.CS_Okay.Size = new System.Drawing.Size(75, 23);
            this.CS_Okay.TabIndex = 1;
            this.CS_Okay.Text = "OK";
            this.CS_Okay.UseVisualStyleBackColor = true;
            this.CS_Okay.Click += new System.EventHandler(this.CS_Okay_Click);
            // 
            // CS_Cancel
            // 
            this.CS_Cancel.Location = new System.Drawing.Point(186, 105);
            this.CS_Cancel.Name = "CS_Cancel";
            this.CS_Cancel.Size = new System.Drawing.Size(75, 23);
            this.CS_Cancel.TabIndex = 2;
            this.CS_Cancel.Text = "Cancelar";
            this.CS_Cancel.UseVisualStyleBackColor = true;
            this.CS_Cancel.Click += new System.EventHandler(this.CS_Cancel_Click);
            // 
            // CS_Label1
            // 
            this.CS_Label1.AutoSize = true;
            this.CS_Label1.Location = new System.Drawing.Point(37, 25);
            this.CS_Label1.Name = "CS_Label1";
            this.CS_Label1.Size = new System.Drawing.Size(141, 13);
            this.CS_Label1.TabIndex = 3;
            this.CS_Label1.Text = "Selecione um novo servidor:";
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
            // ChangeServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 146);
            this.Controls.Add(this.CS_Label1);
            this.Controls.Add(this.CS_Cancel);
            this.Controls.Add(this.CS_Okay);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mudar Servidor";
            this.Load += new System.EventHandler(this.ChangeServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sERVIDORBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cONTABindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource sERVIDORBindingSource;
        private DataSet2TableAdapters.SERVIDORTableAdapter sERVIDORTableAdapter;
        private System.Windows.Forms.Button CS_Okay;
        private System.Windows.Forms.Button CS_Cancel;
        private System.Windows.Forms.Label CS_Label1;
        private System.Windows.Forms.BindingSource cONTABindingSource;
        private DataSet2TableAdapters.CONTATableAdapter cONTATableAdapter;
    }
}