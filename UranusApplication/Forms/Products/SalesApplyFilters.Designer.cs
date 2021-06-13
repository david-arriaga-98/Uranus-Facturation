
namespace ProyectoPuntoNet.Forms.Products
{
    partial class SalesApplyFilters
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
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnApplyFilter = new FontAwesome.Sharp.IconButton();
            this.BtnClose = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DTmFrom = new System.Windows.Forms.DateTimePicker();
            this.DTmTO = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.CBoxState = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 25;
            this.iconPictureBox2.Location = new System.Drawing.Point(23, 9);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(27, 25);
            this.iconPictureBox2.TabIndex = 34;
            this.iconPictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.label1.Location = new System.Drawing.Point(43, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 34);
            this.label1.TabIndex = 33;
            this.label1.Text = "Filtros de búsqueda";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnApplyFilter
            // 
            this.BtnApplyFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.BtnApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnApplyFilter.FlatAppearance.BorderSize = 0;
            this.BtnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnApplyFilter.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApplyFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.BtnApplyFilter.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.BtnApplyFilter.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.BtnApplyFilter.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.BtnApplyFilter.IconSize = 17;
            this.BtnApplyFilter.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnApplyFilter.Location = new System.Drawing.Point(89, 208);
            this.BtnApplyFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnApplyFilter.Name = "BtnApplyFilter";
            this.BtnApplyFilter.Size = new System.Drawing.Size(78, 25);
            this.BtnApplyFilter.TabIndex = 37;
            this.BtnApplyFilter.Text = "Aplicar";
            this.BtnApplyFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnApplyFilter.UseVisualStyleBackColor = false;
            this.BtnApplyFilter.Click += new System.EventHandler(this.BtnApplyFilter_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.BtnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.BtnClose.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.BtnClose.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.BtnClose.IconSize = 17;
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClose.Location = new System.Drawing.Point(183, 209);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(89, 24);
            this.BtnClose.TabIndex = 38;
            this.BtnClose.Text = "Cancelar";
            this.BtnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.label5.Location = new System.Drawing.Point(19, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 23);
            this.label5.TabIndex = 46;
            this.label5.Text = "Fecha Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.label2.Location = new System.Drawing.Point(209, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 47;
            this.label2.Text = "Fecha Hasta:";
            // 
            // DTmFrom
            // 
            this.DTmFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.DTmFrom.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.DTmFrom.CalendarTrailingForeColor = System.Drawing.Color.Green;
            this.DTmFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTmFrom.Location = new System.Drawing.Point(23, 82);
            this.DTmFrom.Name = "DTmFrom";
            this.DTmFrom.Size = new System.Drawing.Size(146, 24);
            this.DTmFrom.TabIndex = 48;
            // 
            // DTmTO
            // 
            this.DTmTO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTmTO.Location = new System.Drawing.Point(186, 82);
            this.DTmTO.Name = "DTmTO";
            this.DTmTO.Size = new System.Drawing.Size(146, 24);
            this.DTmTO.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.label3.Location = new System.Drawing.Point(19, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 50;
            this.label3.Text = "Estado:";
            // 
            // CBoxState
            // 
            this.CBoxState.BackColor = System.Drawing.Color.White;
            this.CBoxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBoxState.FormattingEnabled = true;
            this.CBoxState.Items.AddRange(new object[] {
            "Abierto",
            "Cerrado"});
            this.CBoxState.Location = new System.Drawing.Point(23, 153);
            this.CBoxState.Name = "CBoxState";
            this.CBoxState.Size = new System.Drawing.Size(146, 27);
            this.CBoxState.TabIndex = 51;
            // 
            // SalesApplyFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(359, 242);
            this.Controls.Add(this.CBoxState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DTmTO);
            this.Controls.Add(this.DTmFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnApplyFilter);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalesApplyFilters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aplicar Filtros";
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton BtnApplyFilter;
        private FontAwesome.Sharp.IconButton BtnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTmFrom;
        private System.Windows.Forms.DateTimePicker DTmTO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBoxState;
    }
}