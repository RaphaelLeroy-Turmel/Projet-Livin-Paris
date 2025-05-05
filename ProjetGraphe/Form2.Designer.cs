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
            pictureBox1 = new PictureBox();
            cmbPlats = new ComboBox();
            numQuantite = new NumericUpDown();
            dateLivraisonPicker = new DateTimePicker();
            CB = new RadioButton();
            Especes = new RadioButton();
            Paypal = new RadioButton();
            button1 = new Button();
            button3 = new Button();
            txtAdresse = new TextBox();
            txtMetro = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantite).BeginInit();
            SuspendLayout();
            // 
            // lblBienvenue
            // 
            lblBienvenue.AutoSize = true;
            lblBienvenue.Font = new Font("Comic Sans MS", 20F, FontStyle.Bold | FontStyle.Underline);
            lblBienvenue.Location = new Point(304, 9);
            lblBienvenue.Name = "lblBienvenue";
            lblBienvenue.Size = new Size(319, 38);
            lblBienvenue.TabIndex = 0;
            lblBienvenue.Text = "Tableau de Bord Client";
            lblBienvenue.Click += lblBienvenue_Click;
            // 
            // btnCommandes
            // 
            btnCommandes.Location = new Point(167, 209);
            btnCommandes.Name = "btnCommandes";
            btnCommandes.Size = new Size(160, 26);
            btnCommandes.TabIndex = 1;
            btnCommandes.Text = "Voir mes commandes";
            btnCommandes.UseVisualStyleBackColor = true;
            btnCommandes.Click += button1_Click;
            // 
            // btnDeconnexion
            // 
            btnDeconnexion.BackColor = Color.IndianRed;
            btnDeconnexion.Location = new Point(745, 594);
            btnDeconnexion.Name = "btnDeconnexion";
            btnDeconnexion.Size = new Size(125, 26);
            btnDeconnexion.TabIndex = 2;
            btnDeconnexion.Text = "Déconnexion";
            btnDeconnexion.UseVisualStyleBackColor = false;
            btnDeconnexion.Click += button2_Click;
            // 
            // lstCommandes
            // 
            lstCommandes.FormattingEnabled = true;
            lstCommandes.ItemHeight = 17;
            lstCommandes.Location = new Point(0, 359);
            lstCommandes.Name = "lstCommandes";
            lstCommandes.Size = new Size(469, 276);
            lstCommandes.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(720, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.TabIndex = 52;
            pictureBox1.TabStop = false;
            // 
            // cmbPlats
            // 
            this.Load += new System.EventHandler(this.FormEspaceClient_Load);
            cmbPlats.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlats.FormattingEnabled = true;
            cmbPlats.Location = new Point(8, 79);
            cmbPlats.Name = "cmbPlats";
            cmbPlats.Size = new Size(133, 25);
            cmbPlats.TabIndex = 53;

            // 
            // numQuantite
            // 
            numQuantite.Location = new Point(157, 79);
            numQuantite.Name = "numQuantite";
            numQuantite.Size = new Size(105, 24);
            numQuantite.TabIndex = 54;
            numQuantite.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dateLivraisonPicker
            // 
            dateLivraisonPicker.Location = new Point(157, 111);
            dateLivraisonPicker.Name = "dateLivraisonPicker";
            dateLivraisonPicker.Size = new Size(178, 24);
            dateLivraisonPicker.TabIndex = 56;
            // 
            // CB
            // 
            CB.AutoSize = true;
            CB.Location = new Point(8, 141);
            CB.Name = "CB";
            CB.Size = new Size(41, 21);
            CB.TabIndex = 57;
            CB.TabStop = true;
            CB.Text = "CB";
            CB.UseVisualStyleBackColor = true;
            CB.CheckedChanged += CB_CheckedChanged;
            // 
            // Especes
            // 
            Especes.AutoSize = true;
            Especes.Location = new Point(216, 141);
            Especes.Name = "Especes";
            Especes.Size = new Size(70, 21);
            Especes.TabIndex = 58;
            Especes.TabStop = true;
            Especes.Text = "Espèces";
            Especes.UseVisualStyleBackColor = true;
            // 
            // Paypal
            // 
            Paypal.AutoSize = true;
            Paypal.Location = new Point(111, 141);
            Paypal.Name = "Paypal";
            Paypal.Size = new Size(60, 21);
            Paypal.TabIndex = 59;
            Paypal.TabStop = true;
            Paypal.Text = "PayPal";
            Paypal.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(8, 168);
            button1.Name = "button1";
            button1.Size = new Size(135, 25);
            button1.TabIndex = 60;
            button1.Text = "Ajouter au panier";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(8, 209);
            button3.Name = "button3";
            button3.Size = new Size(135, 25);
            button3.TabIndex = 62;
            button3.Text = "Valider la commande";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // txtAdresse
            // 
            txtAdresse.Location = new Point(167, 168);
            txtAdresse.Name = "txtAdresse";
            txtAdresse.Size = new Size(135, 24);
            txtAdresse.TabIndex = 63;
            txtAdresse.Text = "Adresse";
            // 
            // txtMetro
            // 
            txtMetro.Location = new Point(8, 110);
            txtMetro.Name = "txtMetro";
            txtMetro.Size = new Size(135, 24);
            txtMetro.TabIndex = 64;
            txtMetro.Text = "Metro";
            txtMetro.TextChanged += textBox1_TextChanged;
            // 
            // FormEspaceClient
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(882, 632);
            Controls.Add(txtMetro);
            Controls.Add(txtAdresse);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(Paypal);
            Controls.Add(Especes);
            Controls.Add(CB);
            Controls.Add(dateLivraisonPicker);
            Controls.Add(numQuantite);
            Controls.Add(cmbPlats);
            Controls.Add(pictureBox1);
            Controls.Add(lstCommandes);
            Controls.Add(btnDeconnexion);
            Controls.Add(btnCommandes);
            Controls.Add(lblBienvenue);
            Font = new Font("Comic Sans MS", 9F);
            Name = "FormEspaceClient";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantite).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBienvenue;
        private Button btnCommandes;
        private Button btnDeconnexion;
        private ListBox lstCommandes;
        private PictureBox pictureBox1;
        private ComboBox cmbPlats;
        private NumericUpDown numQuantite;
        private DateTimePicker dateLivraisonPicker;
        private RadioButton CB;
        private RadioButton Especes;
        private RadioButton Paypal;
        private Button button1;
        private Button button3;
        private TextBox txtAdresse;
        private TextBox txtMetro;
    }
}