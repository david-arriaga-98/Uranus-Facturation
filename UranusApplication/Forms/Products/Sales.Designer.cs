
namespace ProyectoPuntoNet.Forms.Products
{
    partial class Sales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tableSales = new System.Windows.Forms.DataGridView();
            this.id_catalogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuestos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAddOrder = new FontAwesome.Sharp.IconButton();
            this.showOrder = new FontAwesome.Sharp.IconButton();
            this.BtnAddProducts = new FontAwesome.Sharp.IconButton();
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.BtnApplyFilter = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tableSales)).BeginInit();
            this.PanelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.label1.Location = new System.Drawing.Point(50, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 34);
            this.label1.TabIndex = 32;
            this.label1.Text = "Gestión de Ventas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableSales
            // 
            this.tableSales.AllowUserToAddRows = false;
            this.tableSales.AllowUserToDeleteRows = false;
            this.tableSales.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.tableSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableSales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(64)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_catalogo,
            this.Código,
            this.Estado,
            this.Subtotal,
            this.Descuento,
            this.Impuestos,
            this.Total,
            this.fecha});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableSales.DefaultCellStyle = dataGridViewCellStyle2;
            this.tableSales.EnableHeadersVisualStyles = false;
            this.tableSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.tableSales.Location = new System.Drawing.Point(28, 102);
            this.tableSales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableSales.Name = "tableSales";
            this.tableSales.ReadOnly = true;
            this.tableSales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableSales.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Poppins Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.tableSales.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.tableSales.Size = new System.Drawing.Size(566, 356);
            this.tableSales.TabIndex = 33;
            // 
            // id_catalogo
            // 
            this.id_catalogo.HeaderText = "id";
            this.id_catalogo.Name = "id_catalogo";
            this.id_catalogo.ReadOnly = true;
            this.id_catalogo.Visible = false;
            // 
            // Código
            // 
            this.Código.HeaderText = "Código";
            this.Código.Name = "Código";
            this.Código.ReadOnly = true;
            this.Código.Width = 85;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 60;
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            this.Subtotal.Width = 70;
            // 
            // Descuento
            // 
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 70;
            // 
            // Impuestos
            // 
            this.Impuestos.HeaderText = "Impuestos";
            this.Impuestos.Name = "Impuestos";
            this.Impuestos.ReadOnly = true;
            this.Impuestos.Width = 70;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 70;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha de Creación";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // BtnAddOrder
            // 
            this.BtnAddOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.BtnAddOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddOrder.FlatAppearance.BorderSize = 0;
            this.BtnAddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddOrder.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.BtnAddOrder.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.BtnAddOrder.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.BtnAddOrder.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.BtnAddOrder.IconSize = 17;
            this.BtnAddOrder.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnAddOrder.Location = new System.Drawing.Point(28, 69);
            this.BtnAddOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnAddOrder.Name = "BtnAddOrder";
            this.BtnAddOrder.Size = new System.Drawing.Size(245, 25);
            this.BtnAddOrder.TabIndex = 34;
            this.BtnAddOrder.Text = "Agregar una nueva orden de venta";
            this.BtnAddOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAddOrder.UseVisualStyleBackColor = false;
            this.BtnAddOrder.Click += new System.EventHandler(this.BtnAddOrder_Click_1);
            // 
            // showOrder
            // 
            this.showOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(250)))), ((int)(((byte)(229)))));
            this.showOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showOrder.FlatAppearance.BorderSize = 0;
            this.showOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.showOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showOrder.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.showOrder.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.showOrder.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.showOrder.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.showOrder.IconSize = 20;
            this.showOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showOrder.Location = new System.Drawing.Point(33, 466);
            this.showOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.showOrder.Name = "showOrder";
            this.showOrder.Size = new System.Drawing.Size(98, 24);
            this.showOrder.TabIndex = 35;
            this.showOrder.Text = "Ver Orden";
            this.showOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showOrder.UseVisualStyleBackColor = false;
            // 
            // BtnAddProducts
            // 
            this.BtnAddProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.BtnAddProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddProducts.FlatAppearance.BorderSize = 0;
            this.BtnAddProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddProducts.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.BtnAddProducts.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.BtnAddProducts.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.BtnAddProducts.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.BtnAddProducts.IconSize = 17;
            this.BtnAddProducts.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnAddProducts.Location = new System.Drawing.Point(137, 465);
            this.BtnAddProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnAddProducts.Name = "BtnAddProducts";
            this.BtnAddProducts.Size = new System.Drawing.Size(151, 25);
            this.BtnAddProducts.TabIndex = 36;
            this.BtnAddProducts.Text = "Agregar Productos";
            this.BtnAddProducts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAddProducts.UseVisualStyleBackColor = false;
            this.BtnAddProducts.Click += new System.EventHandler(this.BtnAddProducts_Click);
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.Controls.Add(this.BtnApplyFilter);
            this.PanelPrincipal.Controls.Add(this.iconPictureBox2);
            this.PanelPrincipal.Controls.Add(this.BtnAddProducts);
            this.PanelPrincipal.Controls.Add(this.showOrder);
            this.PanelPrincipal.Controls.Add(this.BtnAddOrder);
            this.PanelPrincipal.Controls.Add(this.tableSales);
            this.PanelPrincipal.Controls.Add(this.label1);
            this.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(622, 530);
            this.PanelPrincipal.TabIndex = 0;
            // 
            // BtnApplyFilter
            // 
            this.BtnApplyFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(254)))));
            this.BtnApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnApplyFilter.FlatAppearance.BorderSize = 0;
            this.BtnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnApplyFilter.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApplyFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(29)))), ((int)(((byte)(149)))));
            this.BtnApplyFilter.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.BtnApplyFilter.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(29)))), ((int)(((byte)(149)))));
            this.BtnApplyFilter.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.BtnApplyFilter.IconSize = 17;
            this.BtnApplyFilter.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnApplyFilter.Location = new System.Drawing.Point(480, 69);
            this.BtnApplyFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnApplyFilter.Name = "BtnApplyFilter";
            this.BtnApplyFilter.Size = new System.Drawing.Size(114, 25);
            this.BtnApplyFilter.TabIndex = 39;
            this.BtnApplyFilter.Text = "Aplicar Filtros";
            this.BtnApplyFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnApplyFilter.UseVisualStyleBackColor = false;
            this.BtnApplyFilter.Click += new System.EventHandler(this.BtnApplyFilter_Click);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 25;
            this.iconPictureBox2.Location = new System.Drawing.Point(29, 32);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(27, 25);
            this.iconPictureBox2.TabIndex = 38;
            this.iconPictureBox2.TabStop = false;
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(622, 530);
            this.Controls.Add(this.PanelPrincipal);
            this.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Sales";
            this.Text = "Sales";
            this.Load += new System.EventHandler(this.Sales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableSales)).EndInit();
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tableSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_catalogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impuestos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private FontAwesome.Sharp.IconButton BtnAddOrder;
        private FontAwesome.Sharp.IconButton showOrder;
        private FontAwesome.Sharp.IconButton BtnAddProducts;
        private System.Windows.Forms.Panel PanelPrincipal;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconButton BtnApplyFilter;
    }
}