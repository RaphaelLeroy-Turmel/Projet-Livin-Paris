namespace ProjetGraphe
{
    partial class FormEspaceClient
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
            lblBienvenue = new Label();
            btnCommandes = new Button();
            btnDeconnexion = new Button();
            lstCommandes = new ListBox();
            SuspendLayout();
            // 
            // lblBienvenue
            // 
            lblBienvenue.AutoSize = true;
            lblBienvenue.Location = new Point(310, 67);
            lblBienvenue.Name = "lblBienvenue";
            lblBienvenue.Size = new Size(125, 15);
            lblBienvenue.TabIndex = 0;
            lblBienvenue.Text = "Tableau de Bord Client";
            lblBienvenue.Click += lblBienvenue_Click;
            // 
            // btnCommandes
            // 
            btnCommandes.Location = new Point(371, 204);
            btnCommandes.Name = "btnCommandes";
            btnCommandes.Size = new Size(160, 23);
            btnCommandes.TabIndex = 1;
            btnCommandes.Text = "Voir mes commandes";
            btnCommandes.UseVisualStyleBackColor = true;
            btnCommandes.Click += button1_Click;
            // 
            // btnDeconnexion
            // 
            btnDeconnexion.Location = new Point(602, 216);
            btnDeconnexion.Name = "btnDeconnexion";
            btnDeconnexion.Size = new Size(125, 23);
            btnDeconnexion.TabIndex = 2;
            btnDeconnexion.Text = "Déconnexion";
            btnDeconnexion.UseVisualStyleBackColor = true;
            btnDeconnexion.Click += button2_Click;
            // 
            // lstCommandes
            // 
            lstCommandes.FormattingEnabled = true;
            lstCommandes.ItemHeight = 15;
            lstCommandes.Location = new Point(472, 149);
            lstCommandes.Name = "lstCommandes";
            lstCommandes.Size = new Size(120, 94);
            lstCommandes.TabIndex = 3;
            // 
            // FormEspaceClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstCommandes);
            Controls.Add(btnDeconnexion);
            Controls.Add(btnCommandes);
            Controls.Add(lblBienvenue);
            Name = "FormEspaceClient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenue;
        private Button btnCommandes;
        private Button btnDeconnexion;
        private ListBox lstCommandes;
    }
}