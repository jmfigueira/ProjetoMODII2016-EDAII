namespace CrossingPenguins
{
    partial class Crossing
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtQuant = new System.Windows.Forms.TextBox();
            this.lblQuant = new System.Windows.Forms.Label();
            this.pEsq = new System.Windows.Forms.Panel();
            this.pDir = new System.Windows.Forms.Panel();
            this.pIce = new System.Windows.Forms.Panel();
            this.lPassos = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblEsq = new System.Windows.Forms.Label();
            this.lblIce = new System.Windows.Forms.Label();
            this.lblDir = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(26, 43);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtQuant
            // 
            this.txtQuant.Location = new System.Drawing.Point(12, 17);
            this.txtQuant.Name = "txtQuant";
            this.txtQuant.Size = new System.Drawing.Size(100, 20);
            this.txtQuant.TabIndex = 1;
            this.txtQuant.TextChanged += new System.EventHandler(this.txtQuant_TextChanged);
            // 
            // lblQuant
            // 
            this.lblQuant.AutoSize = true;
            this.lblQuant.Location = new System.Drawing.Point(9, 1);
            this.lblQuant.Name = "lblQuant";
            this.lblQuant.Size = new System.Drawing.Size(65, 13);
            this.lblQuant.TabIndex = 2;
            this.lblQuant.Text = "Quantidade:";
            // 
            // pEsq
            // 
            this.pEsq.Location = new System.Drawing.Point(130, 17);
            this.pEsq.Name = "pEsq";
            this.pEsq.Size = new System.Drawing.Size(157, 521);
            this.pEsq.TabIndex = 3;
            // 
            // pDir
            // 
            this.pDir.Location = new System.Drawing.Point(665, 17);
            this.pDir.Name = "pDir";
            this.pDir.Size = new System.Drawing.Size(157, 521);
            this.pDir.TabIndex = 4;
            // 
            // pIce
            // 
            this.pIce.Location = new System.Drawing.Point(377, 17);
            this.pIce.Name = "pIce";
            this.pIce.Size = new System.Drawing.Size(157, 521);
            this.pIce.TabIndex = 5;
            // 
            // lPassos
            // 
            this.lPassos.AutoSize = true;
            this.lPassos.Location = new System.Drawing.Point(12, 143);
            this.lPassos.Name = "lPassos";
            this.lPassos.Size = new System.Drawing.Size(44, 13);
            this.lPassos.TabIndex = 6;
            this.lPassos.Text = "Passos:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(62, 143);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 7;
            // 
            // lblEsq
            // 
            this.lblEsq.AutoSize = true;
            this.lblEsq.Location = new System.Drawing.Point(127, 1);
            this.lblEsq.Name = "lblEsq";
            this.lblEsq.Size = new System.Drawing.Size(79, 13);
            this.lblEsq.TabIndex = 8;
            this.lblEsq.Text = "Lado Esquerdo";
            // 
            // lblIce
            // 
            this.lblIce.AutoSize = true;
            this.lblIce.Location = new System.Drawing.Point(374, 1);
            this.lblIce.Name = "lblIce";
            this.lblIce.Size = new System.Drawing.Size(43, 13);
            this.lblIce.TabIndex = 9;
            this.lblIce.Text = "Iceberg";
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Location = new System.Drawing.Point(662, 1);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(64, 13);
            this.lblDir.TabIndex = 10;
            this.lblDir.Text = "Lado Direito";
            // 
            // Crossing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 550);
            this.Controls.Add(this.lblDir);
            this.Controls.Add(this.lblIce);
            this.Controls.Add(this.lblEsq);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lPassos);
            this.Controls.Add(this.pIce);
            this.Controls.Add(this.pDir);
            this.Controls.Add(this.pEsq);
            this.Controls.Add(this.lblQuant);
            this.Controls.Add(this.txtQuant);
            this.Controls.Add(this.btnSend);
            this.Name = "Crossing";
            this.Text = "CrossingPenguins";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtQuant;
        private System.Windows.Forms.Label lblQuant;
        private System.Windows.Forms.Panel pEsq;
        private System.Windows.Forms.Panel pDir;
        private System.Windows.Forms.Panel pIce;
        private System.Windows.Forms.Label lPassos;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblEsq;
        private System.Windows.Forms.Label lblIce;
        private System.Windows.Forms.Label lblDir;
    }
}

