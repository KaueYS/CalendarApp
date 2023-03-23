namespace Estudar
{
    partial class Estudo
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMinutos = new System.Windows.Forms.ComboBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.grdResumoDosCursos = new System.Windows.Forms.DataGridView();
            this.gpBoxInicial = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdResumoDosCursos)).BeginInit();
            this.gpBoxInicial.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 662);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Exportar para Excell ?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quantos minutos pretende estudar por dia?";
            // 
            // cbMinutos
            // 
            this.cbMinutos.FormattingEnabled = true;
            this.cbMinutos.Items.AddRange(new object[] {
            "30",
            "45",
            "60",
            "90",
            "120"});
            this.cbMinutos.Location = new System.Drawing.Point(7, 36);
            this.cbMinutos.Name = "cbMinutos";
            this.cbMinutos.Size = new System.Drawing.Size(121, 21);
            this.cbMinutos.TabIndex = 4;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(134, 36);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(126, 23);
            this.btnCalcular.TabIndex = 5;
            this.btnCalcular.Text = "Calcular curso";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // grdResumoDosCursos
            // 
            this.grdResumoDosCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdResumoDosCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResumoDosCursos.Location = new System.Drawing.Point(6, 31);
            this.grdResumoDosCursos.Name = "grdResumoDosCursos";
            this.grdResumoDosCursos.ReadOnly = true;
            this.grdResumoDosCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResumoDosCursos.Size = new System.Drawing.Size(848, 491);
            this.grdResumoDosCursos.TabIndex = 6;
            // 
            // gpBoxInicial
            // 
            this.gpBoxInicial.Controls.Add(this.grdResumoDosCursos);
            this.gpBoxInicial.Location = new System.Drawing.Point(7, 90);
            this.gpBoxInicial.Name = "gpBoxInicial";
            this.gpBoxInicial.Size = new System.Drawing.Size(862, 539);
            this.gpBoxInicial.TabIndex = 7;
            this.gpBoxInicial.TabStop = false;
            this.gpBoxInicial.Text = "Lista de aulas compativeis com sua escolha";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 657);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Exportar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Estudo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 707);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gpBoxInicial);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.cbMinutos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Estudo";
            this.Text = "Programe seus estudos";
            ((System.ComponentModel.ISupportInitialize)(this.grdResumoDosCursos)).EndInit();
            this.gpBoxInicial.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMinutos;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.DataGridView grdResumoDosCursos;
        private System.Windows.Forms.GroupBox gpBoxInicial;
        private System.Windows.Forms.Button button1;
    }
}

