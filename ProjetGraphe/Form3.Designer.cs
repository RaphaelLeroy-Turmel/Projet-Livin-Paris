
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
            f = new Label();
            txtIngredients = new TextBox();
            b = new Label();
            chkVegan = new CheckBox();
            g = new Label();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            DateFab = new DateTimePicker();
            DatePer = new DateTimePicker();
            btnrecherche = new Button();
            txtDepart = new TextBox();
            txtArrivee = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnPlatsFreq
            // 
            btnPlatsFreq.Location = new Point(191, 718);
            btnPlatsFreq.Margin = new Padding(3, 4, 3, 4);
            btnPlatsFreq.Name = "btnPlatsFreq";
            btnPlatsFreq.Size = new Size(173, 31);
            btnPlatsFreq.TabIndex = 0;
            btnPlatsFreq.Text = "Plats par fréquences";
            btnPlatsFreq.UseVisualStyleBackColor = true;
            btnPlatsFreq.Click += btnPlatsFreq_Click;
            // 
            // btnDeconnexion
            // 
            btnDeconnexion.BackColor = Color.IndianRed;
            btnDeconnexion.Location = new Point(907, 816);
            btnDeconnexion.Margin = new Padding(3, 4, 3, 4);
            btnDeconnexion.Name = "btnDeconnexion";
            btnDeconnexion.Size = new Size(115, 31);
            btnDeconnexion.TabIndex = 1;
            btnDeconnexion.Text = "Déconnexion";
            btnDeconnexion.UseVisualStyleBackColor = false;
            btnDeconnexion.Click += btnDeconnexion_Click;
            // 
            // btnClient
            // 
            btnClient.Location = new Point(191, 679);
            btnClient.Margin = new Padding(3, 4, 3, 4);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(173, 31);
            btnClient.TabIndex = 2;
            btnClient.Text = "Commandes Par Clients";
            btnClient.UseVisualStyleBackColor = true;
            btnClient.Click += btnClient_Click;
            // 
            // lstPlats
            // 
            lstPlats.FormattingEnabled = true;
            lstPlats.Location = new Point(12, 88);
            lstPlats.Margin = new Padding(3, 4, 3, 4);
            lstPlats.Name = "lstPlats";
            lstPlats.Size = new Size(541, 544);
            lstPlats.TabIndex = 4;
            lstPlats.SelectedIndexChanged += lstPlats_SelectedIndexChanged_1;
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.BorderStyle = BorderStyle.FixedSingle;
            lblTitre.Font = new Font("Comic Sans MS", 20F, FontStyle.Bold | FontStyle.Underline);
            lblTitre.Location = new Point(295, 24);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(465, 50);
            lblTitre.TabIndex = 5;
            lblTitre.Text = "Tableau de Bord Cuisiniers";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Comic Sans MS", 15F, FontStyle.Bold | FontStyle.Underline);
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(104, 37);
            label1.TabIndex = 6;
            label1.Text = "Console";
            // 
            // lblSucces
            // 
            lblSucces.AutoSize = true;
            lblSucces.ForeColor = Color.Green;
            lblSucces.Location = new Point(742, 612);
            lblSucces.Name = "lblSucces";
            lblSucces.Size = new Size(53, 20);
            lblSucces.TabIndex = 47;
            lblSucces.Text = "Succès";
            lblSucces.Visible = false;
            // 
            // chkVegetarien
            // 
            chkVegetarien.AutoSize = true;
            chkVegetarien.Location = new Point(600, 533);
            chkVegetarien.Margin = new Padding(3, 4, 3, 4);
            chkVegetarien.Name = "chkVegetarien";
            chkVegetarien.Size = new Size(102, 24);
            chkVegetarien.TabIndex = 45;
            chkVegetarien.Text = "Végétatien";
            chkVegetarien.UseVisualStyleBackColor = true;
            // 
            // txtTypePlat
            // 
            txtTypePlat.Location = new Point(601, 387);
            txtTypePlat.Margin = new Padding(3, 4, 3, 4);
            txtTypePlat.Name = "txtTypePlat";
            txtTypePlat.Size = new Size(189, 27);
            txtTypePlat.TabIndex = 44;
            // 
            // e
            // 
            e.AutoSize = true;
            e.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            e.Location = new Point(601, 360);
            e.Name = "e";
            e.Size = new Size(112, 20);
            e.TabIndex = 43;
            e.Text = "Type de plat";
            e.Click += label13_Click;
            // 
            // txtNomPlat
            // 
            txtNomPlat.Location = new Point(601, 313);
            txtNomPlat.Margin = new Padding(3, 4, 3, 4);
            txtNomPlat.Name = "txtNomPlat";
            txtNomPlat.Size = new Size(189, 27);
            txtNomPlat.TabIndex = 42;
            // 
            // d
            // 
            d.AutoSize = true;
            d.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            d.ForeColor = SystemColors.ActiveCaptionText;
            d.Location = new Point(601, 287);
            d.Name = "d";
            d.Size = new Size(110, 20);
            d.TabIndex = 41;
            d.Text = "Nom du plat";
            // 
            // lblErreur
            // 
            lblErreur.AutoSize = true;
            lblErreur.ForeColor = Color.Red;
            lblErreur.Location = new Point(781, 612);
            lblErreur.Name = "lblErreur";
            lblErreur.Size = new Size(48, 20);
            lblErreur.TabIndex = 40;
            lblErreur.Text = "Erreur";
            lblErreur.Visible = false;
            // 
            // txtNationalite
            // 
            txtNationalite.Location = new Point(810, 313);
            txtNationalite.Margin = new Padding(3, 4, 3, 4);
            txtNationalite.Name = "txtNationalite";
            txtNationalite.Size = new Size(219, 27);
            txtNationalite.TabIndex = 39;
            // 
            // c
            // 
            c.AutoSize = true;
            c.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            c.Location = new Point(810, 287);
            c.Name = "c";
            c.Size = new Size(99, 20);
            c.TabIndex = 38;
            c.Text = "Nationalité";
            // 
            // txtNbPersonnes
            // 
            txtNbPersonnes.Location = new Point(601, 467);
            txtNbPersonnes.Margin = new Padding(3, 4, 3, 4);
            txtNbPersonnes.Name = "txtNbPersonnes";
            txtNbPersonnes.Size = new Size(189, 27);
            txtNbPersonnes.TabIndex = 37;
            // 
            // a
            // 
            a.AutoSize = true;
            a.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            a.ForeColor = SystemColors.ActiveCaptionText;
            a.Location = new Point(601, 440);
            a.Name = "a";
            a.Size = new Size(193, 20);
            a.TabIndex = 36;
            a.Text = "Nombre de personnes";
            // 
            // button1
            // 
            button1.Location = new Point(706, 578);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(190, 31);
            button1.TabIndex = 35;
            button1.Text = "Ajouter mon plat";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // f
            // 
            f.AutoSize = true;
            f.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            f.Location = new Point(810, 444);
            f.Name = "f";
            f.Size = new Size(170, 20);
            f.TabIndex = 33;
            f.Text = "Date de fabrication";
            // 
            // txtIngredients
            // 
            txtIngredients.Location = new Point(810, 387);
            txtIngredients.Margin = new Padding(3, 4, 3, 4);
            txtIngredients.Name = "txtIngredients";
            txtIngredients.Size = new Size(219, 27);
            txtIngredients.TabIndex = 32;
            // 
            // b
            // 
            b.AutoSize = true;
            b.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            b.ForeColor = SystemColors.ActiveCaptionText;
            b.Location = new Point(810, 360);
            b.Name = "b";
            b.Size = new Size(102, 20);
            b.TabIndex = 31;
            b.Text = "Ingrédients";
            // 
            // chkVegan
            // 
            chkVegan.AutoSize = true;
            chkVegan.Location = new Point(706, 533);
            chkVegan.Margin = new Padding(3, 4, 3, 4);
            chkVegan.Name = "chkVegan";
            chkVegan.Size = new Size(72, 24);
            chkVegan.TabIndex = 46;
            chkVegan.Text = "Végan";
            chkVegan.UseVisualStyleBackColor = true;
            // 
            // g
            // 
            g.AutoSize = true;
            g.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            g.Location = new Point(809, 510);
            g.Name = "g";
            g.Size = new Size(174, 20);
            g.TabIndex = 48;
            g.Text = "Date de péremption";
            g.Click += label2_Click;
            // 
            // button2
            // 
            button2.Location = new Point(191, 640);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(173, 31);
            button2.TabIndex = 50;
            button2.Text = "Lister Plats";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(851, 16);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(171, 200);
            pictureBox1.TabIndex = 51;
            pictureBox1.TabStop = false;
            // 
            // DateFab
            // 
            DateFab.Location = new Point(810, 467);
            DateFab.Name = "DateFab";
            DateFab.Size = new Size(219, 27);
            DateFab.TabIndex = 52;
            DateFab.ValueChanged += DateFab_ValueChanged;
            // 
            // DatePer
            // 
            DatePer.Location = new Point(809, 533);
            DatePer.Name = "DatePer";
            DatePer.Size = new Size(220, 27);
            DatePer.TabIndex = 53;
            // 
            // btnrecherche
            // 
            btnrecherche.Location = new Point(413, 818);
            btnrecherche.Name = "btnrecherche";
            btnrecherche.Size = new Size(126, 31);
            btnrecherche.TabIndex = 54;
            btnrecherche.Text = "Rechercher";
            btnrecherche.UseVisualStyleBackColor = true;
            btnrecherche.Click += btnrecherche_Click;
            // 
            // txtDepart
            // 
            txtDepart.Location = new Point(12, 820);
            txtDepart.Name = "txtDepart";
            txtDepart.Size = new Size(125, 27);
            txtDepart.TabIndex = 55;
            txtDepart.Text = "Départ";
            // 
            // txtArrivee
            // 
            txtArrivee.Location = new Point(208, 820);
            txtArrivee.Name = "txtArrivee";
            txtArrivee.Size = new Size(125, 27);
            txtArrivee.TabIndex = 56;
            txtArrivee.Text = "Arrivée";
            // 
            // FormEspaceCuisinier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1037, 856);
            Controls.Add(txtArrivee);
            Controls.Add(txtDepart);
            Controls.Add(btnrecherche);
            Controls.Add(DatePer);
            Controls.Add(DateFab);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
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
            Controls.Add(f);
            Controls.Add(txtIngredients);
            Controls.Add(b);
            Controls.Add(label1);
            Controls.Add(lblTitre);
            Controls.Add(lstPlats);
            Controls.Add(btnClient);
            Controls.Add(btnDeconnexion);
            Controls.Add(btnPlatsFreq);
            Margin = new Padding(3, 4, 3, 4);
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
        private Label f;
        private TextBox txtIngredients;
        private Label b;
        private CheckBox chkVegan;
        private Label g;
        private Button button2;
        private PictureBox pictureBox1;
        private DateTimePicker DateFab;
        private DateTimePicker DatePer;
        private Button btnrecherche;
        private TextBox txtDepart;
        private TextBox txtArrivee;
    }
}