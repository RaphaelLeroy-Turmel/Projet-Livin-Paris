
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
            label1 = new Label();
            lblSucces = new Label();
            chkVegetarien = new CheckBox();
            txtTypePlat = new TextBox();
            e = new Label();
            txtNomPlat = new TextBox();
            d = new Label();
            lblErreur = new Label();
            txtNationalite = new TextBox();
            c = new Label();
            txtNbPersonnes = new TextBox();
            a = new Label();
            button1 = new Button();
            txtFabrication = new TextBox();
            f = new Label();
            txtIngredients = new TextBox();
            b = new Label();
            chkVegan = new CheckBox();
            txtPeremption = new TextBox();
            g = new Label();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnPlatsFreq
            // 
            btnPlatsFreq.Location = new Point(244, 347);
            btnPlatsFreq.Name = "btnPlatsFreq";
            btnPlatsFreq.Size = new Size(151, 23);
            btnPlatsFreq.TabIndex = 0;
            btnPlatsFreq.Text = "Plats par fréquences";
            btnPlatsFreq.UseVisualStyleBackColor = true;
            btnPlatsFreq.Click += btnPlatsFreq_Click;
            // 
            // btnDeconnexion
            // 
            btnDeconnexion.BackColor = Color.IndianRed;
            btnDeconnexion.Location = new Point(794, 612);
            btnDeconnexion.Name = "btnDeconnexion";
            btnDeconnexion.Size = new Size(101, 23);
            btnDeconnexion.TabIndex = 1;
            btnDeconnexion.Text = "Déconnexion";
            btnDeconnexion.UseVisualStyleBackColor = false;
            btnDeconnexion.Click += btnDeconnexion_Click;
            // 
            // btnClient
            // 
            btnClient.Location = new Point(244, 318);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(151, 23);
            btnClient.TabIndex = 2;
            btnClient.Text = "Commandes Par Clients";
            btnClient.UseVisualStyleBackColor = true;
            btnClient.Click += btnClient_Click;
            // 
            // lstPlats
            // 
            lstPlats.FormattingEnabled = true;
            lstPlats.ItemHeight = 15;
            lstPlats.Location = new Point(2, 46);
            lstPlats.Name = "lstPlats";
            lstPlats.Size = new Size(236, 589);
            lstPlats.TabIndex = 4;
            lstPlats.SelectedIndexChanged += lstPlats_SelectedIndexChanged_1;
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.BorderStyle = BorderStyle.FixedSingle;
            lblTitre.Font = new Font("Comic Sans MS", 20F, FontStyle.Bold | FontStyle.Underline);
            lblTitre.Location = new Point(258, 18);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(370, 40);
            lblTitre.TabIndex = 5;
            lblTitre.Text = "Tableau de Bord Cuisiniers";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Comic Sans MS", 15F, FontStyle.Bold | FontStyle.Underline);
            label1.Location = new Point(79, 9);
            label1.Name = "label1";
            label1.Size = new Size(85, 31);
            label1.TabIndex = 6;
            label1.Text = "Console";
            // 
            // lblSucces
            // 
            lblSucces.AutoSize = true;
            lblSucces.ForeColor = Color.Green;
            lblSucces.Location = new Point(649, 451);
            lblSucces.Name = "lblSucces";
            lblSucces.Size = new Size(43, 15);
            lblSucces.TabIndex = 47;
            lblSucces.Text = "Succès";
            lblSucces.Visible = false;
            // 
            // chkVegetarien
            // 
            chkVegetarien.AutoSize = true;
            chkVegetarien.Location = new Point(710, 374);
            chkVegetarien.Name = "chkVegetarien";
            chkVegetarien.Size = new Size(81, 19);
            chkVegetarien.TabIndex = 45;
            chkVegetarien.Text = "Végétatien";
            chkVegetarien.UseVisualStyleBackColor = true;
            // 
            // txtTypePlat
            // 
            txtTypePlat.Location = new Point(526, 290);
            txtTypePlat.Name = "txtTypePlat";
            txtTypePlat.Size = new Size(166, 23);
            txtTypePlat.TabIndex = 44;
            // 
            // e
            // 
            e.AutoSize = true;
            e.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            e.Location = new Point(526, 270);
            e.Name = "e";
            e.Size = new Size(99, 17);
            e.TabIndex = 43;
            e.Text = "Type de plat";
            e.Click += label13_Click;
            // 
            // txtNomPlat
            // 
            txtNomPlat.Location = new Point(526, 235);
            txtNomPlat.Name = "txtNomPlat";
            txtNomPlat.Size = new Size(166, 23);
            txtNomPlat.TabIndex = 42;
            // 
            // d
            // 
            d.AutoSize = true;
            d.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            d.ForeColor = SystemColors.ActiveCaptionText;
            d.Location = new Point(526, 215);
            d.Name = "d";
            d.Size = new Size(95, 17);
            d.TabIndex = 41;
            d.Text = "Nom du plat";
            // 
            // lblErreur
            // 
            lblErreur.AutoSize = true;
            lblErreur.ForeColor = Color.Red;
            lblErreur.Location = new Point(683, 451);
            lblErreur.Name = "lblErreur";
            lblErreur.Size = new Size(38, 15);
            lblErreur.TabIndex = 40;
            lblErreur.Text = "Erreur";
            lblErreur.Visible = false;
            // 
            // txtNationalite
            // 
            txtNationalite.Location = new Point(709, 235);
            txtNationalite.Name = "txtNationalite";
            txtNationalite.Size = new Size(166, 23);
            txtNationalite.TabIndex = 39;
            // 
            // c
            // 
            c.AutoSize = true;
            c.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            c.Location = new Point(709, 215);
            c.Name = "c";
            c.Size = new Size(86, 17);
            c.TabIndex = 38;
            c.Text = "Nationalité";
            // 
            // txtNbPersonnes
            // 
            txtNbPersonnes.Location = new Point(709, 345);
            txtNbPersonnes.Name = "txtNbPersonnes";
            txtNbPersonnes.Size = new Size(166, 23);
            txtNbPersonnes.TabIndex = 37;
            // 
            // a
            // 
            a.AutoSize = true;
            a.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            a.ForeColor = SystemColors.ActiveCaptionText;
            a.Location = new Point(709, 325);
            a.Name = "a";
            a.Size = new Size(168, 17);
            a.TabIndex = 36;
            a.Text = "Nombre de personnes";
            // 
            // button1
            // 
            button1.Location = new Point(618, 425);
            button1.Name = "button1";
            button1.Size = new Size(166, 23);
            button1.TabIndex = 35;
            button1.Text = "Ajouter mon plat";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtFabrication
            // 
            txtFabrication.Location = new Point(526, 345);
            txtFabrication.Name = "txtFabrication";
            txtFabrication.Size = new Size(166, 23);
            txtFabrication.TabIndex = 34;
            // 
            // f
            // 
            f.AutoSize = true;
            f.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            f.Location = new Point(526, 325);
            f.Name = "f";
            f.Size = new Size(147, 17);
            f.TabIndex = 33;
            f.Text = "Date de fabrication";
            // 
            // txtIngredients
            // 
            txtIngredients.Location = new Point(709, 290);
            txtIngredients.Name = "txtIngredients";
            txtIngredients.Size = new Size(166, 23);
            txtIngredients.TabIndex = 32;
            // 
            // b
            // 
            b.AutoSize = true;
            b.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            b.ForeColor = SystemColors.ActiveCaptionText;
            b.Location = new Point(709, 270);
            b.Name = "b";
            b.Size = new Size(89, 17);
            b.TabIndex = 31;
            b.Text = "Ingrédients";
            // 
            // chkVegan
            // 
            chkVegan.AutoSize = true;
            chkVegan.Location = new Point(802, 374);
            chkVegan.Name = "chkVegan";
            chkVegan.Size = new Size(58, 19);
            chkVegan.TabIndex = 46;
            chkVegan.Text = "Végan";
            chkVegan.UseVisualStyleBackColor = true;
            // 
            // txtPeremption
            // 
            txtPeremption.Location = new Point(526, 396);
            txtPeremption.Name = "txtPeremption";
            txtPeremption.Size = new Size(166, 23);
            txtPeremption.TabIndex = 49;
            // 
            // g
            // 
            g.AutoSize = true;
            g.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            g.Location = new Point(526, 376);
            g.Name = "g";
            g.Size = new Size(151, 17);
            g.TabIndex = 48;
            g.Text = "Date de péremption";
            g.Click += label2_Click;
            // 
            // button2
            // 
            button2.Location = new Point(244, 289);
            button2.Name = "button2";
            button2.Size = new Size(151, 23);
            button2.TabIndex = 50;
            button2.Text = "Lister Plats";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(745, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.TabIndex = 51;
            pictureBox1.TabStop = false;
            // 
            // FormEspaceCuisinier
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(907, 642);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(txtPeremption);
            Controls.Add(g);
            Controls.Add(lblSucces);
            Controls.Add(chkVegan);
            Controls.Add(chkVegetarien);
            Controls.Add(txtTypePlat);
            Controls.Add(e);
            Controls.Add(txtNomPlat);
            Controls.Add(d);
            Controls.Add(lblErreur);
            Controls.Add(txtNationalite);
            Controls.Add(c);
            Controls.Add(txtNbPersonnes);
            Controls.Add(a);
            Controls.Add(button1);
            Controls.Add(txtFabrication);
            Controls.Add(f);
            Controls.Add(txtIngredients);
            Controls.Add(b);
            Controls.Add(label1);
            Controls.Add(lblTitre);
            Controls.Add(lstPlats);
            Controls.Add(btnClient);
            Controls.Add(btnDeconnexion);
            Controls.Add(btnPlatsFreq);
            Name = "FormEspaceCuisinier";
            Load += FormEspaceCuisinier_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Label label1;
        private Label lblSucces;
        private CheckBox chkVegetarien;
        private TextBox txtTypePlat;
        private Label e;
        private TextBox txtNomPlat;
        private Label d;
        private Label lblErreur;
        private TextBox txtNationalite;
        private Label c;
        private TextBox txtNbPersonnes;
        private Label a;
        private Button button1;
        private TextBox txtFabrication;
        private Label f;
        private TextBox txtIngredients;
        private Label b;
        private CheckBox chkVegan;
        private TextBox txtPeremption;
        private Label g;
        private Button button2;
        private PictureBox pictureBox1;
    }
}