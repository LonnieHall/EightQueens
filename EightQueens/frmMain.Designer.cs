namespace EightQueens
{
    partial class frmMain
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
            this.btnSolutions = new System.Windows.Forms.Button();
            this.txtGameBoard = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSolutions
            // 
            this.btnSolutions.Location = new System.Drawing.Point(51, 28);
            this.btnSolutions.Name = "btnSolutions";
            this.btnSolutions.Size = new System.Drawing.Size(138, 23);
            this.btnSolutions.TabIndex = 0;
            this.btnSolutions.Text = "Find Solutions";
            this.btnSolutions.UseVisualStyleBackColor = true;
            this.btnSolutions.Click += new System.EventHandler(this.btnSolutions_Click);
            // 
            // txtGameBoard
            // 
            this.txtGameBoard.Location = new System.Drawing.Point(51, 57);
            this.txtGameBoard.Multiline = true;
            this.txtGameBoard.Name = "txtGameBoard";
            this.txtGameBoard.Size = new System.Drawing.Size(138, 145);
            this.txtGameBoard.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 231);
            this.Controls.Add(this.txtGameBoard);
            this.Controls.Add(this.btnSolutions);
            this.Name = "frmMain";
            this.Text = "Eight Queens";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSolutions;
        private System.Windows.Forms.TextBox txtGameBoard;
    }
}

