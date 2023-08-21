namespace Aurora
{
    partial class Index
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.actionsBox = new System.Windows.Forms.GroupBox();
            this.textInput = new System.Windows.Forms.TextBox();
            this.tokenizeButton = new System.Windows.Forms.Button();
            this.actionsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionsBox
            // 
            this.actionsBox.Controls.Add(this.tokenizeButton);
            this.actionsBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionsBox.Location = new System.Drawing.Point(10, 10);
            this.actionsBox.Name = "actionsBox";
            this.actionsBox.Size = new System.Drawing.Size(780, 64);
            this.actionsBox.TabIndex = 0;
            this.actionsBox.TabStop = false;
            this.actionsBox.Text = "Actions";
            // 
            // textInput
            // 
            this.textInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInput.Location = new System.Drawing.Point(10, 74);
            this.textInput.Multiline = true;
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(780, 366);
            this.textInput.TabIndex = 1;
            // 
            // tokenizeButton
            // 
            this.tokenizeButton.Location = new System.Drawing.Point(6, 35);
            this.tokenizeButton.Name = "tokenizeButton";
            this.tokenizeButton.Size = new System.Drawing.Size(75, 23);
            this.tokenizeButton.TabIndex = 0;
            this.tokenizeButton.Text = "Tokenize";
            this.tokenizeButton.UseVisualStyleBackColor = true;
            this.tokenizeButton.Click += new System.EventHandler(this.tokenizeButton_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textInput);
            this.Controls.Add(this.actionsBox);
            this.Name = "Index";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form1";
            this.actionsBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox actionsBox;
        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.Button tokenizeButton;
    }
}

