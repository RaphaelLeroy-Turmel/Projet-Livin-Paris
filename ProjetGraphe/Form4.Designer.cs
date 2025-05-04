namespace ProjetGraphe
{
    partial class FormEspaceAdmin
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
            lblTitre = new Label();
            btnCuisiniers = new Button();
            btnClient = new Button();
            btnDeconnexion = new Button();
            lstResultats = new ListBox();
            btnPlats = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.Location = new Point(357, 79);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(130, 15);
            lblTitre.TabIndex = 0;
            lblTitre.Text = "Tableau de bord Admin";
            lblTitre.Click += lblTitre_Click;
            // 
            // btnCuisiniers
            // 
            btnCuisiniers.Location = new Point(407, 178);
            btnCuisiniers.Name = "btnCuisiniers";
            btnCuisiniers.Size = new Size(148, 23);
            btnCuisiniers.TabIndex = 1;
            btnCuisiniers.Text = "Lister Cuisniers";
            btnCuisiniers.UseVisualStyleBackColor = true;
            btnCuisiniers.Click += btnCuisiniers_Click;
            // 
            // btnClient
            // 
            btnClient.Location = new Point(424, 244);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(148, 23);
            btnClient.TabIndex = 2;
            btnClient.Text = "Lister Clients";
            btnClient.UseVisualStyleBackColor = true;
            btnClient.Click += btnClient_Click;
            // 
            // btnDeconnexion
            // 
            btnDeconnexion.Location = new Point(579, 79);
            btnDeconnexion.Name = "btnDeconnexion";
            btnDeconnexion.Size = new Size(117, 23);
            btnDeconnexion.TabIndex = 3;
            btnDeconnexion.Text = "Déconnexion";
            btnDeconnexion.UseVisualStyleBackColor = true;
            btnDeconnexion.Click += btnDeconnexion_Click;
            // 
            // lstResultats
            // 
            lstResultats.FormattingEnabled = true;
            lstResultats.ItemHeight = 15;
            lstResultats.Location = new Point(0, 0);
            lstResultats.Name = "lstResultats";
            lstResultats.Size = new Size(213, 454);
            lstResultats.TabIndex = 4;
            // 
            // btnPlats
            // 
            btnPlats.Location = new Point(621, 229);
            btnPlats.Name = "btnPlats";
            btnPlats.Size = new Size(75, 23);
            btnPlats.TabIndex = 5;
            btnPlats.Text = "Lister Plats";
            btnPlats.UseVisualStyleBackColor = true;
            btnPlats.Click += btnPlats_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(276, 123);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // FormEspaceAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 460);
            Controls.Add(comboBox1);
            Controls.Add(btnPlats);
            Controls.Add(lstResultats);
            Controls.Add(btnDeconnexion);
            Controls.Add(btnClient);
            Controls.Add(btnCuisiniers);
            Controls.Add(lblTitre);
            Name = "FormEspaceAdmin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitre;
        private Button btnCuisiniers;
        private Button btnClient;
        private Button btnDeconnexion;
        private ListBox lstResultats;
        private Button btnPlats;
        private ComboBox comboBox1;
    }
}