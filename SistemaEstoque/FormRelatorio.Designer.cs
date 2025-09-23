
namespace SistemaEstoque
{
    partial class FormRelatorio
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
            this.dgvRelatorio = new System.Windows.Forms.DataGridView();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.btnAtualizarRel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRelatorio
            // 
            this.dgvRelatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatorio.Location = new System.Drawing.Point(67, 63);
            this.dgvRelatorio.Name = "dgvRelatorio";
            this.dgvRelatorio.RowHeadersWidth = 62;
            this.dgvRelatorio.RowTemplate.Height = 28;
            this.dgvRelatorio.Size = new System.Drawing.Size(659, 230);
            this.dgvRelatorio.TabIndex = 0;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.Location = new System.Drawing.Point(62, 9);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(130, 29);
            this.lblValorTotal.TabIndex = 1;
            this.lblValorTotal.Text = "Valor Total";
            // 
            // btnAtualizarRel
            // 
            this.btnAtualizarRel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarRel.Location = new System.Drawing.Point(67, 316);
            this.btnAtualizarRel.Name = "btnAtualizarRel";
            this.btnAtualizarRel.Size = new System.Drawing.Size(174, 111);
            this.btnAtualizarRel.TabIndex = 2;
            this.btnAtualizarRel.Text = "Atualizar";
            this.btnAtualizarRel.UseVisualStyleBackColor = true;
            this.btnAtualizarRel.Click += new System.EventHandler(this.btnAtualizarRel_Click);
            // 
            // FormRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAtualizarRel);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.dgvRelatorio);
            this.Name = "FormRelatorio";
            this.Text = "FormRelatorio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRelatorio;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Button btnAtualizarRel;
    }
}