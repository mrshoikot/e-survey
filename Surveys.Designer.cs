
namespace E_Survry
{
    partial class Surveys
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.survey = new System.Windows.Forms.Button();
            this.surveysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbDataSet = new E_Survry.dbDataSet();
            this.surveysTableAdapter = new E_Survry.dbDataSetTableAdapters.surveysTableAdapter();
            this.Close = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.surveyTable = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surveysBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataSet)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surveyTable)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(464, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 55);
            this.button1.TabIndex = 36;
            this.button1.Text = "Surveys";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 672);
            this.panel1.TabIndex = 40;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.logout);
            this.panel2.Controls.Add(this.survey);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 672);
            this.panel2.TabIndex = 41;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(17, 307);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(161, 58);
            this.button9.TabIndex = 46;
            this.button9.Text = "Add Survey";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(17, 214);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(161, 58);
            this.button8.TabIndex = 45;
            this.button8.Text = "Dashbord";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(12, 627);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(92, 33);
            this.logout.TabIndex = 44;
            this.logout.Text = "Log Out";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // survey
            // 
            this.survey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.survey.Location = new System.Drawing.Point(17, 121);
            this.survey.Name = "survey";
            this.survey.Size = new System.Drawing.Size(161, 58);
            this.survey.TabIndex = 42;
            this.survey.Text = "Surveys";
            this.survey.UseVisualStyleBackColor = true;
            // 
            // surveysBindingSource
            // 
            this.surveysBindingSource.DataMember = "surveys";
            this.surveysBindingSource.DataSource = this.dbDataSet;
            // 
            // dbDataSet
            // 
            this.dbDataSet.DataSetName = "dbDataSet";
            this.dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // surveysTableAdapter
            // 
            this.surveysTableAdapter.ClearBeforeFill = true;
            // 
            // Close
            // 
            this.Close.Location = new System.Drawing.Point(654, 9);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(69, 28);
            this.Close.TabIndex = 45;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.Close);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(200, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(726, 43);
            this.panel3.TabIndex = 41;
            // 
            // surveyTable
            // 
            this.surveyTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.surveyTable.Location = new System.Drawing.Point(255, 215);
            this.surveyTable.Name = "surveyTable";
            this.surveyTable.Size = new System.Drawing.Size(627, 299);
            this.surveyTable.TabIndex = 42;
            this.surveyTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.surveyTable_CellContentClick);
            // 
            // Surveys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 672);
            this.Controls.Add(this.surveyTable);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "Surveys";
            this.Text = "Surveys";
            this.Load += new System.EventHandler(this.Surveys_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.surveysBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataSet)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.surveyTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button survey;
        private dbDataSet dbDataSet;
        private System.Windows.Forms.BindingSource surveysBindingSource;
        private dbDataSetTableAdapters.surveysTableAdapter surveysTableAdapter;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView surveyTable;
    }
}