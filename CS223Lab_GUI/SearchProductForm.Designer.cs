namespace CS223Lab_GUI_1
{
    partial class SearchProductForm
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchEntry = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvSearchResults = new System.Windows.Forms.DataGridView();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnPriceFilter2 = new System.Windows.Forms.Button();
            this.btnPriceFilter3 = new System.Windows.Forms.Button();
            this.btnPriceFilter1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(694, 72);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 33);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchEntry
            // 
            this.txtSearchEntry.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchEntry.Location = new System.Drawing.Point(278, 71);
            this.txtSearchEntry.Name = "txtSearchEntry";
            this.txtSearchEntry.Size = new System.Drawing.Size(410, 33);
            this.txtSearchEntry.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvSearchResults);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(234, 138);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(590, 283);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search Results";
            // 
            // dgvSearchResults
            // 
            this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResults.Location = new System.Drawing.Point(19, 37);
            this.dgvSearchResults.Name = "dgvSearchResults";
            this.dgvSearchResults.Size = new System.Drawing.Size(552, 228);
            this.dgvSearchResults.TabIndex = 18;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.White;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogOut.Location = new System.Drawing.Point(816, 19);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(146, 34);
            this.btnLogOut.TabIndex = 36;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(12, 18);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(85, 30);
            this.lblUsername.TabIndex = 35;
            this.lblUsername.Text = "user001";
            // 
            // btnPriceFilter2
            // 
            this.btnPriceFilter2.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPriceFilter2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriceFilter2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriceFilter2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPriceFilter2.Location = new System.Drawing.Point(70, 225);
            this.btnPriceFilter2.Name = "btnPriceFilter2";
            this.btnPriceFilter2.Size = new System.Drawing.Size(122, 34);
            this.btnPriceFilter2.TabIndex = 37;
            this.btnPriceFilter2.Text = "$10 - 80";
            this.btnPriceFilter2.UseVisualStyleBackColor = false;
            this.btnPriceFilter2.Click += new System.EventHandler(this.btnPriceFilter2_Click);
            // 
            // btnPriceFilter3
            // 
            this.btnPriceFilter3.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPriceFilter3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriceFilter3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriceFilter3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPriceFilter3.Location = new System.Drawing.Point(70, 275);
            this.btnPriceFilter3.Name = "btnPriceFilter3";
            this.btnPriceFilter3.Size = new System.Drawing.Size(122, 34);
            this.btnPriceFilter3.TabIndex = 38;
            this.btnPriceFilter3.Text = "$80 - 150";
            this.btnPriceFilter3.UseVisualStyleBackColor = false;
            this.btnPriceFilter3.Click += new System.EventHandler(this.btnPriceFilter3_Click);
            // 
            // btnPriceFilter1
            // 
            this.btnPriceFilter1.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPriceFilter1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriceFilter1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriceFilter1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPriceFilter1.Location = new System.Drawing.Point(70, 175);
            this.btnPriceFilter1.Name = "btnPriceFilter1";
            this.btnPriceFilter1.Size = new System.Drawing.Size(122, 34);
            this.btnPriceFilter1.TabIndex = 39;
            this.btnPriceFilter1.Text = "< $10";
            this.btnPriceFilter1.UseVisualStyleBackColor = false;
            this.btnPriceFilter1.Click += new System.EventHandler(this.btnPriceFilter1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 24);
            this.label1.TabIndex = 40;
            this.label1.Text = "Filter";
            // 
            // SearchProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 445);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPriceFilter1);
            this.Controls.Add(this.btnPriceFilter3);
            this.Controls.Add(this.btnPriceFilter2);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchEntry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SearchForm";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchEntry;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvSearchResults;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnPriceFilter2;
        private System.Windows.Forms.Button btnPriceFilter3;
        private System.Windows.Forms.Button btnPriceFilter1;
        private System.Windows.Forms.Label label1;
    }
}