namespace Aurora
{
    partial class TokenListForm
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
            this.tokenListView = new System.Windows.Forms.ListView();
            this.tokenTypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tokenValueColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // tokenListView
            // 
            this.tokenListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tokenTypeColumn,
            this.tokenValueColumn});
            this.tokenListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tokenListView.HideSelection = false;
            this.tokenListView.Location = new System.Drawing.Point(0, 0);
            this.tokenListView.Name = "tokenListView";
            this.tokenListView.Size = new System.Drawing.Size(284, 261);
            this.tokenListView.TabIndex = 0;
            this.tokenListView.UseCompatibleStateImageBehavior = false;
            this.tokenListView.View = System.Windows.Forms.View.Details;
            // 
            // tokenTypeColumn
            // 
            this.tokenTypeColumn.Text = "Type";
            // 
            // tokenValueColumn
            // 
            this.tokenValueColumn.Text = "Value";
            // 
            // TokenListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tokenListView);
            this.Name = "TokenListForm";
            this.Text = "TokenList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView tokenListView;
        private System.Windows.Forms.ColumnHeader tokenTypeColumn;
        private System.Windows.Forms.ColumnHeader tokenValueColumn;
    }
}