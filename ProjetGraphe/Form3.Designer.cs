
namespace ProjetGraphe
{
    partial class FormEspaceCuisinier

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
            btnPlatsFreq = new Button();
            btnDeconnexion = new Button();
            btnClient = new Button();
            lstPlats = new ListBox();
            lblTitre = new Label();
            SuspendLayout();
            // 
            // btnPlatsFreq
            // 
            btnPlatsFreq.Location = new Point(585, 186);
            btnPlatsFreq.Name = "btnPlatsFreq";
            btnPlatsFreq.Size = new Size(75, 23);
            btnPlatsFreq.TabIndex = 0;
            btnPlatsFreq.Text = "button1";
            btnPlatsFreq.UseVisualStyleBackColor = true;
            btnPlatsFreq.Click += btnPlatsFreq_Click;
            // 
            // btnDeconnexion
            // 
            btnDeconnexion.Location = new Point(585, 226);
            btnDeconnexion.Name = "btnDeconnexion";
            btnDeconnexion.Size = new Size(101, 23);
            btnDeconnexion.TabIndex = 1;
            btnDeconnexion.Text = "Déconnexion";
            btnDeconnexion.UseVisualStyleBackColor = true;
            btnDeconnexion.Click += btnDeconnexion_Click;
            // 
            // btnClient
            // 
            btnClient.Location = new Point(371, 107);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(75, 23);
            btnClient.TabIndex = 2;
            btnClient.Text = "button1";
            btnClient.UseVisualStyleBackColor = true;
            btnClient.Click += btnClient_Click;
            // 
            // lstPlats
            // 
            lstPlats.FormattingEnabled = true;
            lstPlats.ItemHeight = 15;
            lstPlats.Location = new Point(350, 243);
            lstPlats.Name = "lstPlats";
            lstPlats.Size = new Size(120, 94);
            lstPlats.TabIndex = 4;
            lstPlats.SelectedIndexChanged += lstPlats_SelectedIndexChanged_1;
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.Location = new Point(476, 65);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(145, 15);
            lblTitre.TabIndex = 5;
            lblTitre.Text = "Tableau de Bord Cuisiniers";
            // 
            // FormEspaceCuisinier
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitre);
            Controls.Add(lstPlats);
            Controls.Add(btnClient);
            Controls.Add(btnDeconnexion);
            Controls.Add(btnPlatsFreq);
            Name = "FormEspaceCuisinier";
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button btnPlatsFreq;
        private Button btnDeconnexion;
        private Button btnClient;
        private ListBox lstPlats;
        private Label lblTitre;
    }
}