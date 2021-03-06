﻿namespace swopsy
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
            this.checkBoxReverse = new System.Windows.Forms.CheckBox();
            this.trackBarDelay = new System.Windows.Forms.TrackBar();
            this.labelDelay = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statisticBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelPort = new System.Windows.Forms.Label();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.labelRequestWait = new System.Windows.Forms.Label();
            this.trackBarRequestWait = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDelay)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRequestWait)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxReverse
            // 
            this.checkBoxReverse.AutoSize = true;
            this.checkBoxReverse.Checked = true;
            this.checkBoxReverse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxReverse.Location = new System.Drawing.Point(12, 34);
            this.checkBoxReverse.Name = "checkBoxReverse";
            this.checkBoxReverse.Size = new System.Drawing.Size(61, 17);
            this.checkBoxReverse.TabIndex = 0;
            this.checkBoxReverse.Text = "reverse";
            this.checkBoxReverse.UseVisualStyleBackColor = true;
            // 
            // trackBarDelay
            // 
            this.trackBarDelay.LargeChange = 1000;
            this.trackBarDelay.Location = new System.Drawing.Point(10, 86);
            this.trackBarDelay.Maximum = 5000;
            this.trackBarDelay.Name = "trackBarDelay";
            this.trackBarDelay.Size = new System.Drawing.Size(259, 45);
            this.trackBarDelay.TabIndex = 1;
            this.trackBarDelay.TickFrequency = 1000;
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(12, 70);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(67, 13);
            this.labelDelay.TabIndex = 2;
            this.labelDelay.Text = "bundle delay";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(9, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 148);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "stats";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.statisticBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(254, 129);
            this.dataGridView1.TabIndex = 0;
            // 
            // statDataGridViewTextBoxColumn
            // 
            this.statDataGridViewTextBoxColumn.DataPropertyName = "Stat";
            this.statDataGridViewTextBoxColumn.HeaderText = "Stat";
            this.statDataGridViewTextBoxColumn.Name = "statDataGridViewTextBoxColumn";
            this.statDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statisticBindingSource
            // 
            this.statisticBindingSource.DataSource = typeof(swopsy.Statistic);
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(220, 14);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(52, 13);
            this.labelPort.TabIndex = 4;
            this.labelPort.Text = "port 8765";
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Location = new System.Drawing.Point(12, 9);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(55, 17);
            this.checkBoxActive.TabIndex = 5;
            this.checkBoxActive.Text = "active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.labelRequestWait.AutoSize = true;
            this.labelRequestWait.Location = new System.Drawing.Point(12, 134);
            this.labelRequestWait.Name = "label1";
            this.labelRequestWait.Size = new System.Drawing.Size(104, 13);
            this.labelRequestWait.TabIndex = 6;
            this.labelRequestWait.Text = "max wait per request";
            // 
            // trackBarRequestWait
            // 
            this.trackBarRequestWait.LargeChange = 200;
            this.trackBarRequestWait.Location = new System.Drawing.Point(10, 152);
            this.trackBarRequestWait.Maximum = 1000;
            this.trackBarRequestWait.Name = "trackBarRequestWait";
            this.trackBarRequestWait.Size = new System.Drawing.Size(259, 45);
            this.trackBarRequestWait.TabIndex = 7;
            this.trackBarRequestWait.TickFrequency = 200;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 363);
            this.Controls.Add(this.trackBarRequestWait);
            this.Controls.Add(this.labelRequestWait);
            this.Controls.Add(this.checkBoxActive);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelDelay);
            this.Controls.Add(this.trackBarDelay);
            this.Controls.Add(this.checkBoxReverse);
            this.Name = "Form1";
            this.Text = "Swopsy";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDelay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRequestWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxReverse;
        private System.Windows.Forms.TrackBar trackBarDelay;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn statDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource statisticBindingSource;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.Label labelRequestWait;
        private System.Windows.Forms.TrackBar trackBarRequestWait;
    }
}

