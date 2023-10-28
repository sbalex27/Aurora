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
            this.buttonCompile = new System.Windows.Forms.Button();
            this.tokenizeButton = new System.Windows.Forms.Button();
            this.textInput = new System.Windows.Forms.TextBox();
            this.textBoxProblems = new System.Windows.Forms.TextBox();
            this.problemsLabel = new System.Windows.Forms.Label();
            this.actionsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionsBox
            // 
            this.actionsBox.Controls.Add(this.buttonCompile);
            this.actionsBox.Controls.Add(this.tokenizeButton);
            this.actionsBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionsBox.Location = new System.Drawing.Point(10, 10);
            this.actionsBox.Name = "actionsBox";
            this.actionsBox.Size = new System.Drawing.Size(829, 64);
            this.actionsBox.TabIndex = 0;
            this.actionsBox.TabStop = false;
            this.actionsBox.Text = "Actions";
            // 
            // buttonCompile
            // 
            this.buttonCompile.Location = new System.Drawing.Point(87, 35);
            this.buttonCompile.Name = "buttonCompile";
            this.buttonCompile.Size = new System.Drawing.Size(75, 23);
            this.buttonCompile.TabIndex = 1;
            this.buttonCompile.Text = "Compilar";
            this.buttonCompile.UseVisualStyleBackColor = true;
            this.buttonCompile.Click += new System.EventHandler(this.buttonCompile_Click);
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
            // textInput
            // 
            this.textInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textInput.Location = new System.Drawing.Point(10, 74);
            this.textInput.Multiline = true;
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(829, 305);
            this.textInput.TabIndex = 1;
            // 
            // textBoxProblems
            // 
            this.textBoxProblems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxProblems.Location = new System.Drawing.Point(10, 419);
            this.textBoxProblems.Multiline = true;
            this.textBoxProblems.Name = "textBoxProblems";
            this.textBoxProblems.Size = new System.Drawing.Size(829, 103);
            this.textBoxProblems.TabIndex = 2;
            // 
            // problemsLabel
            // 
            this.problemsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.problemsLabel.AutoSize = true;
            this.problemsLabel.Location = new System.Drawing.Point(16, 400);
            this.problemsLabel.Name = "problemsLabel";
            this.problemsLabel.Size = new System.Drawing.Size(56, 13);
            this.problemsLabel.TabIndex = 3;
            this.problemsLabel.Text = "Problemas";
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 532);
            this.Controls.Add(this.problemsLabel);
            this.Controls.Add(this.textBoxProblems);
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
        private System.Windows.Forms.Button buttonCompile;
        private System.Windows.Forms.TextBox textBoxProblems;
        private System.Windows.Forms.Label problemsLabel;
    }
}

