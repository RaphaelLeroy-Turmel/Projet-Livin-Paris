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
            cmbTriClient = new ComboBox();
            button1 = new Button();
            picLogo = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lblTitre.AutoSize = true;
            lblTitre.BorderStyle = BorderStyle.FixedSingle;
            lblTitre.FlatStyle = FlatStyle.Flat;
            lblTitre.Font = new Font("Comic Sans MS", 20F);
            lblTitre.ForeColor = Color.Black;
            lblTitre.Location = new Point(272, 9);
            lblTitre.Name = "lblTitre";
            lblTitre.RightToLeft = RightToLeft.No;
            lblTitre.Size = new Size(309, 40);
            lblTitre.TabIndex = 0;
            lblTitre.Text = "Tableau de bord Admin";
            lblTitre.TextAlign = ContentAlignment.TopCenter;
            lblTitre.Click += lblTitre_Click;
            // 
            // btnCuisiniers
            // 
            btnCuisiniers.Font = new Font("Comic Sans MS", 9F);
            btnCuisiniers.Location = new Point(271, 292);
            btnCuisiniers.Name = "btnCuisiniers";
            btnCuisiniers.Size = new Size(148, 23);
            btnCuisiniers.TabIndex = 1;
            btnCuisiniers.Text = "Lister Cuisniers";
            btnCuisiniers.UseVisualStyleBackColor = true;
            btnCuisiniers.Click += btnCuisiniers_Click;
            // 
            // btnClient
            // 
            btnClient.Font = new Font("Comic Sans MS", 9F);
            btnClient.Location = new Point(271, 263);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(148, 23);
            btnClient.TabIndex = 2;
            btnClient.Text = "Lister Clients";
            btnClient.UseVisualStyleBackColor = true;
            btnClient.Click += btnClient_Click;
            // 
            // btnDeconnexion
            // 
            btnDeconnexion.BackColor = Color.IndianRed;
            btnDeconnexion.Font = new Font("Comic Sans MS", 9F);
            btnDeconnexion.Location = new Point(705, 590);
            btnDeconnexion.Name = "btnDeconnexion";
            btnDeconnexion.Size = new Size(117, 23);
            btnDeconnexion.TabIndex = 3;
            btnDeconnexion.Text = "Déconnexion";
            btnDeconnexion.UseVisualStyleBackColor = false;
            btnDeconnexion.Click += btnDeconnexion_Click;
            // 
            // lstResultats
            // 
            lstResultats.BackColor = SystemColors.MenuBar;
            lstResultats.FormattingEnabled = true;
            lstResultats.ItemHeight = 15;
            lstResultats.Location = new Point(12, 54);
            lstResultats.Name = "lstResultats";
            lstResultats.Size = new Size(253, 559);
            lstResultats.TabIndex = 4;
            // 
            // btnPlats
            // 
            btnPlats.Font = new Font("Comic Sans MS", 9F);
            btnPlats.Location = new Point(271, 234);
            btnPlats.Name = "btnPlats";
            btnPlats.Size = new Size(148, 23);
            btnPlats.TabIndex = 5;
            btnPlats.Text = "Lister Plats";
            btnPlats.UseVisualStyleBackColor = true;
            btnPlats.Click += btnPlats_Click;
            // 
            // cmbTriClient
            // 
            cmbTriClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTriClient.FormattingEnabled = true;
            cmbTriClient.Location = new Point(271, 321);
            cmbTriClient.MaxLength = 3;
            cmbTriClient.Name = "cmbTriClient";
            cmbTriClient.Size = new Size(166, 23);
            cmbTriClient.TabIndex = 6;
            // 
            // button1
            // 
            button1.Font = new Font("Comic Sans MS", 9F);
            button1.Location = new Point(443, 321);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Trier";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // picLogo
            // 
            picLogo.ErrorImage = Properties.Resources.Logo;
            picLogo.Image = Properties.Resources.Logo;
            picLogo.Location = new Point(672, 9);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(150, 150);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 9;
            picLogo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold | FontStyle.Underline);
            label1.Location = new Point(97, 22);
            label1.Name = "label1";
            label1.Size = new Size(65, 23);
            label1.TabIndex = 10;
            label1.Text = "Console";
            // 
            // FormEspaceAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(834, 617);
            Controls.Add(label1);
            Controls.Add(picLogo);
            Controls.Add(button1);
            Controls.Add(cmbTriClient);
            Controls.Add(btnPlats);
            Controls.Add(lstResultats);
            Controls.Add(btnDeconnexion);
            Controls.Add(btnClient);
            Controls.Add(btnCuisiniers);
            Controls.Add(lblTitre);
            Name = "FormEspaceAdmin";
            Load += comboBox1_SelectedIndexChanged;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
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
        private ComboBox cmbTriClient;
        private Button button1;
        private PictureBox picLogo;
        private Label label1;
    }
}