namespace MemoryAllocation
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.holeSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startingAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.holeStartT = new System.Windows.Forms.TextBox();
            this.holeSizeT = new System.Windows.Forms.TextBox();
            this.holeB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startB = new System.Windows.Forms.Button();
            this.processB = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.proSizeT = new System.Windows.Forms.TextBox();
            this.proNameT = new System.Windows.Forms.TextBox();
            this.noOfProT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.restB = new System.Windows.Forms.Button();
            this.bestfit = new System.Windows.Forms.RadioButton();
            this.firstfit = new System.Windows.Forms.RadioButton();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.holeSize,
            this.startingAddress});
            this.dataGridView1.Location = new System.Drawing.Point(261, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(243, 283);
            this.dataGridView1.TabIndex = 0;
            // 
            // holeSize
            // 
            this.holeSize.HeaderText = "Hole Size";
            this.holeSize.Name = "holeSize";
            // 
            // startingAddress
            // 
            this.startingAddress.HeaderText = "Starting Address";
            this.startingAddress.Name = "startingAddress";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.size});
            this.dataGridView2.Location = new System.Drawing.Point(261, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(243, 283);
            this.dataGridView2.TabIndex = 1;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            // 
            // size
            // 
            this.size.HeaderText = "Size";
            this.size.Name = "size";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.holeStartT);
            this.groupBox1.Controls.Add(this.holeSizeT);
            this.groupBox1.Controls.Add(this.holeB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 316);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Holes";
            // 
            // holeStartT
            // 
            this.holeStartT.Location = new System.Drawing.Point(135, 184);
            this.holeStartT.Name = "holeStartT";
            this.holeStartT.Size = new System.Drawing.Size(100, 20);
            this.holeStartT.TabIndex = 6;
            // 
            // holeSizeT
            // 
            this.holeSizeT.Location = new System.Drawing.Point(135, 150);
            this.holeSizeT.Name = "holeSizeT";
            this.holeSizeT.Size = new System.Drawing.Size(100, 20);
            this.holeSizeT.TabIndex = 5;
            // 
            // holeB
            // 
            this.holeB.Font = new System.Drawing.Font("Tahoma", 9F);
            this.holeB.Location = new System.Drawing.Point(64, 255);
            this.holeB.Name = "holeB";
            this.holeB.Size = new System.Drawing.Size(108, 47);
            this.holeB.TabIndex = 0;
            this.holeB.Text = "Add Hole";
            this.holeB.UseVisualStyleBackColor = true;
            this.holeB.Click += new System.EventHandler(this.holeB_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Starting Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Size:";
            // 
            // startB
            // 
            this.startB.Font = new System.Drawing.Font("Tahoma", 9F);
            this.startB.Location = new System.Drawing.Point(46, 177);
            this.startB.Name = "startB";
            this.startB.Size = new System.Drawing.Size(108, 47);
            this.startB.TabIndex = 8;
            this.startB.Text = "Start";
            this.startB.UseVisualStyleBackColor = true;
            this.startB.Click += new System.EventHandler(this.startB_Click);
            // 
            // processB
            // 
            this.processB.Font = new System.Drawing.Font("Tahoma", 9F);
            this.processB.Location = new System.Drawing.Point(71, 255);
            this.processB.Name = "processB";
            this.processB.Size = new System.Drawing.Size(108, 47);
            this.processB.TabIndex = 7;
            this.processB.Text = "Add Process";
            this.processB.UseVisualStyleBackColor = true;
            this.processB.Click += new System.EventHandler(this.processB_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.processB);
            this.groupBox2.Controls.Add(this.proSizeT);
            this.groupBox2.Controls.Add(this.proNameT);
            this.groupBox2.Controls.Add(this.noOfProT);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(528, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 316);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Process";
            // 
            // proSizeT
            // 
            this.proSizeT.Location = new System.Drawing.Point(145, 184);
            this.proSizeT.Name = "proSizeT";
            this.proSizeT.Size = new System.Drawing.Size(100, 20);
            this.proSizeT.TabIndex = 12;
            // 
            // proNameT
            // 
            this.proNameT.Location = new System.Drawing.Point(145, 147);
            this.proNameT.Name = "proNameT";
            this.proNameT.Size = new System.Drawing.Size(100, 20);
            this.proNameT.TabIndex = 11;
            // 
            // noOfProT
            // 
            this.noOfProT.Location = new System.Drawing.Point(145, 116);
            this.noOfProT.Name = "noOfProT";
            this.noOfProT.Size = new System.Drawing.Size(100, 20);
            this.noOfProT.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Name:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "no. of Processes:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.restB);
            this.groupBox3.Controls.Add(this.startB);
            this.groupBox3.Controls.Add(this.bestfit);
            this.groupBox3.Controls.Add(this.firstfit);
            this.groupBox3.Location = new System.Drawing.Point(1054, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(211, 316);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Method";
            // 
            // restB
            // 
            this.restB.Font = new System.Drawing.Font("Tahoma", 9F);
            this.restB.Location = new System.Drawing.Point(46, 255);
            this.restB.Name = "restB";
            this.restB.Size = new System.Drawing.Size(108, 47);
            this.restB.TabIndex = 8;
            this.restB.Text = "Reset";
            this.restB.UseVisualStyleBackColor = true;
            this.restB.Click += new System.EventHandler(this.restB_Click);
            // 
            // bestfit
            // 
            this.bestfit.AutoSize = true;
            this.bestfit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestfit.Location = new System.Drawing.Point(58, 96);
            this.bestfit.Name = "bestfit";
            this.bestfit.Size = new System.Drawing.Size(66, 18);
            this.bestfit.TabIndex = 3;
            this.bestfit.TabStop = true;
            this.bestfit.Text = "Best Fit";
            this.bestfit.UseVisualStyleBackColor = true;
            // 
            // firstfit
            // 
            this.firstfit.AutoSize = true;
            this.firstfit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstfit.Location = new System.Drawing.Point(58, 56);
            this.firstfit.Name = "firstfit";
            this.firstfit.Size = new System.Drawing.Size(64, 18);
            this.firstfit.TabIndex = 1;
            this.firstfit.TabStop = true;
            this.firstfit.Text = "First Fit";
            this.firstfit.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView3.Location = new System.Drawing.Point(276, 348);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(343, 282);
            this.dataGridView3.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "size";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Address";
            this.Column3.Name = "Column3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 653);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button startB;
        private System.Windows.Forms.Button processB;
        private System.Windows.Forms.TextBox holeStartT;
        private System.Windows.Forms.TextBox holeSizeT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox proSizeT;
        private System.Windows.Forms.TextBox proNameT;
        private System.Windows.Forms.TextBox noOfProT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button holeB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton bestfit;
        private System.Windows.Forms.RadioButton firstfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn holeSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn startingAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.Button restB;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

