namespace GUI
{
    partial class frmBuscaSubCategoria
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
            this.dgvSubCategoria = new System.Windows.Forms.DataGridView();
            this.btnBuscaSubCategoria = new System.Windows.Forms.Button();
            this.txtConsultaSubCategoria = new System.Windows.Forms.TextBox();
            this.lblSubCategoria = new System.Windows.Forms.Label();
            this.projetoEstagioDataSet = new GUI.ProjetoEstagioDataSet();
            this.projetoEstagioDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subcategoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subcategoriaTableAdapter = new GUI.ProjetoEstagioDataSetTableAdapters.subcategoriaTableAdapter();
            this.subCategoriacodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subCategorianomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriacodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetoEstagioDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetoEstagioDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subcategoriaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSubCategoria
            // 
            this.dgvSubCategoria.AllowUserToAddRows = false;
            this.dgvSubCategoria.AllowUserToDeleteRows = false;
            this.dgvSubCategoria.AutoGenerateColumns = false;
            this.dgvSubCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubCategoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subCategoriacodDataGridViewTextBoxColumn,
            this.subCategorianomeDataGridViewTextBoxColumn,
            this.categoriacodDataGridViewTextBoxColumn});
            this.dgvSubCategoria.DataSource = this.subcategoriaBindingSource;
            this.dgvSubCategoria.Location = new System.Drawing.Point(12, 51);
            this.dgvSubCategoria.Name = "dgvSubCategoria";
            this.dgvSubCategoria.ReadOnly = true;
            this.dgvSubCategoria.Size = new System.Drawing.Size(672, 285);
            this.dgvSubCategoria.TabIndex = 7;
            this.dgvSubCategoria.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubCategoria_CellDoubleClick);
            // 
            // btnBuscaSubCategoria
            // 
            this.btnBuscaSubCategoria.Location = new System.Drawing.Point(690, 25);
            this.btnBuscaSubCategoria.Name = "btnBuscaSubCategoria";
            this.btnBuscaSubCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnBuscaSubCategoria.TabIndex = 6;
            this.btnBuscaSubCategoria.Text = "Buscar";
            this.btnBuscaSubCategoria.UseVisualStyleBackColor = true;
            this.btnBuscaSubCategoria.Click += new System.EventHandler(this.btnBuscaSubCategoria_Click);
            // 
            // txtConsultaSubCategoria
            // 
            this.txtConsultaSubCategoria.Location = new System.Drawing.Point(12, 25);
            this.txtConsultaSubCategoria.Name = "txtConsultaSubCategoria";
            this.txtConsultaSubCategoria.Size = new System.Drawing.Size(672, 20);
            this.txtConsultaSubCategoria.TabIndex = 5;
            // 
            // lblSubCategoria
            // 
            this.lblSubCategoria.AutoSize = true;
            this.lblSubCategoria.Location = new System.Drawing.Point(12, 9);
            this.lblSubCategoria.Name = "lblSubCategoria";
            this.lblSubCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblSubCategoria.TabIndex = 4;
            this.lblSubCategoria.Text = "Categoria";
            // 
            // projetoEstagioDataSet
            // 
            this.projetoEstagioDataSet.DataSetName = "ProjetoEstagioDataSet";
            this.projetoEstagioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // projetoEstagioDataSetBindingSource
            // 
            this.projetoEstagioDataSetBindingSource.DataSource = this.projetoEstagioDataSet;
            this.projetoEstagioDataSetBindingSource.Position = 0;
            // 
            // subcategoriaBindingSource
            // 
            this.subcategoriaBindingSource.DataMember = "subcategoria";
            this.subcategoriaBindingSource.DataSource = this.projetoEstagioDataSetBindingSource;
            // 
            // subcategoriaTableAdapter
            // 
            this.subcategoriaTableAdapter.ClearBeforeFill = true;
            // 
            // subCategoriacodDataGridViewTextBoxColumn
            // 
            this.subCategoriacodDataGridViewTextBoxColumn.DataPropertyName = "subCategoria_cod";
            this.subCategoriacodDataGridViewTextBoxColumn.HeaderText = "subCategoria_cod";
            this.subCategoriacodDataGridViewTextBoxColumn.Name = "subCategoriacodDataGridViewTextBoxColumn";
            this.subCategoriacodDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subCategorianomeDataGridViewTextBoxColumn
            // 
            this.subCategorianomeDataGridViewTextBoxColumn.DataPropertyName = "subCategoria_nome";
            this.subCategorianomeDataGridViewTextBoxColumn.HeaderText = "subCategoria_nome";
            this.subCategorianomeDataGridViewTextBoxColumn.Name = "subCategorianomeDataGridViewTextBoxColumn";
            this.subCategorianomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoriacodDataGridViewTextBoxColumn
            // 
            this.categoriacodDataGridViewTextBoxColumn.DataPropertyName = "categoria_cod";
            this.categoriacodDataGridViewTextBoxColumn.HeaderText = "categoria_cod";
            this.categoriacodDataGridViewTextBoxColumn.Name = "categoriacodDataGridViewTextBoxColumn";
            this.categoriacodDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmBuscaSubCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 347);
            this.Controls.Add(this.dgvSubCategoria);
            this.Controls.Add(this.btnBuscaSubCategoria);
            this.Controls.Add(this.txtConsultaSubCategoria);
            this.Controls.Add(this.lblSubCategoria);
            this.Name = "frmBuscaSubCategoria";
            this.Text = "frmBuscaSubCategoria";
            this.Load += new System.EventHandler(this.frmBuscaSubCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetoEstagioDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetoEstagioDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subcategoriaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSubCategoria;
        private System.Windows.Forms.Button btnBuscaSubCategoria;
        private System.Windows.Forms.TextBox txtConsultaSubCategoria;
        private System.Windows.Forms.Label lblSubCategoria;
        private System.Windows.Forms.BindingSource projetoEstagioDataSetBindingSource;
        private ProjetoEstagioDataSet projetoEstagioDataSet;
        private System.Windows.Forms.BindingSource subcategoriaBindingSource;
        private ProjetoEstagioDataSetTableAdapters.subcategoriaTableAdapter subcategoriaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn subCategoriacodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subCategorianomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriacodDataGridViewTextBoxColumn;
    }
}