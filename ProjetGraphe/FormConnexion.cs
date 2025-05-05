using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEST_Projet_Livin_Paris;
using ProjetGraphe;
using LivInParis.Data;
using MySql.Data.MySqlClient;

namespace ProjetGraphe
{
    public partial class FormConnexion : Form
    {
        public FormConnexion()
        {
            InitializeComponent();
        }

        private Label txtEmail;
        private TextBox textBox1;
        private Label txtPassword;
        private TextBox textBox2;
        private Button btnConnexion;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Button button1;
        private TextBox txtMdpInscription;
        private Label label5;
        private TextBox txtEmailInscription;
        private Label label6;
        private Label lblErreurCreation;
        private TextBox txtTel;
        private Label label9;
        private TextBox txtAdresse;
        private Label label10;
        private TextBox txtPrenom;
        private Label label13;
        private TextBox txtNom;
        private Label label14;
        private CheckBox chkClient;
        private CheckBox chkCuisinier;
        private Label lblSuccesCreation;
        private Label lblErreur;

        private void InitializeComponent()
        {
            txtEmail = new Label();
            textBox1 = new TextBox();
            txtPassword = new Label();
            textBox2 = new TextBox();
            btnConnexion = new Button();
            lblErreur = new Label();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            txtMdpInscription = new TextBox();
            label5 = new Label();
            txtEmailInscription = new TextBox();
            label6 = new Label();
            lblErreurCreation = new Label();
            txtTel = new TextBox();
            label9 = new Label();
            txtAdresse = new TextBox();
            label10 = new Label();
            txtPrenom = new TextBox();
            label13 = new Label();
            txtNom = new TextBox();
            label14 = new Label();
            chkClient = new CheckBox();
            chkCuisinier = new CheckBox();
            lblSuccesCreation = new Label();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.AutoSize = true;
            txtEmail.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            txtEmail.ForeColor = SystemColors.ActiveCaptionText;
            txtEmail.Location = new Point(116, 243);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(47, 17);
            txtEmail.TabIndex = 0;
            txtEmail.Text = "Email";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(116, 263);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(166, 23);
            textBox1.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.AutoSize = true;
            txtPassword.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            txtPassword.Location = new Point(116, 307);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(105, 17);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "Mot de passe";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(116, 327);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(166, 23);
            textBox2.TabIndex = 3;
            textBox2.UseSystemPasswordChar = true;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // btnConnexion
            // 
            btnConnexion.Location = new Point(116, 372);
            btnConnexion.Name = "btnConnexion";
            btnConnexion.Size = new Size(166, 23);
            btnConnexion.TabIndex = 4;
            btnConnexion.Text = "Se Connecter";
            btnConnexion.UseVisualStyleBackColor = true;
            btnConnexion.Click += btnConnexion_Click;
            // 
            // lblErreur
            // 
            lblErreur.AutoSize = true;
            lblErreur.ForeColor = Color.Red;
            lblErreur.Location = new Point(227, 309);
            lblErreur.Name = "lblErreur";
            lblErreur.Size = new Size(38, 15);
            lblErreur.TabIndex = 5;
            lblErreur.Text = "Erreur";
            lblErreur.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Red;
            label1.Location = new Point(169, 244);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 6;
            label1.Text = "Erreur";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MV Boli", 35F, FontStyle.Bold);
            label2.ForeColor = Color.DarkSalmon;
            label2.Location = new Point(433, 38);
            label2.Name = "label2";
            label2.Size = new Size(243, 62);
            label2.TabIndex = 7;
            label2.Text = "LivinParis";
            label2.Click += label2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(939, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(733, 426);
            button1.Name = "button1";
            button1.Size = new Size(166, 23);
            button1.TabIndex = 13;
            button1.Text = "Créer Mon Compte";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtMdpInscription
            // 
            txtMdpInscription.Location = new Point(824, 364);
            txtMdpInscription.Name = "txtMdpInscription";
            txtMdpInscription.Size = new Size(166, 23);
            txtMdpInscription.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label5.Location = new Point(824, 344);
            label5.Name = "label5";
            label5.Size = new Size(105, 17);
            label5.TabIndex = 11;
            label5.Text = "Mot de passe";
            // 
            // txtEmailInscription
            // 
            txtEmailInscription.Location = new Point(824, 309);
            txtEmailInscription.Name = "txtEmailInscription";
            txtEmailInscription.Size = new Size(166, 23);
            txtEmailInscription.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(824, 289);
            label6.Name = "label6";
            label6.Size = new Size(47, 17);
            label6.TabIndex = 9;
            label6.Text = "Email";
            // 
            // lblErreurCreation
            // 
            lblErreurCreation.AutoSize = true;
            lblErreurCreation.ForeColor = Color.Red;
            lblErreurCreation.Location = new Point(798, 452);
            lblErreurCreation.Name = "lblErreurCreation";
            lblErreurCreation.Size = new Size(38, 15);
            lblErreurCreation.TabIndex = 21;
            lblErreurCreation.Text = "Erreur";
            lblErreurCreation.Visible = false;
            // 
            // txtTel
            // 
            txtTel.Location = new Point(824, 254);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(166, 23);
            txtTel.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label9.Location = new Point(824, 234);
            label9.Name = "label9";
            label9.Size = new Size(85, 17);
            label9.TabIndex = 18;
            label9.Text = "Téléphone";
            // 
            // txtAdresse
            // 
            txtAdresse.Location = new Point(641, 364);
            txtAdresse.Name = "txtAdresse";
            txtAdresse.Size = new Size(166, 23);
            txtAdresse.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label10.ForeColor = SystemColors.ActiveCaptionText;
            label10.Location = new Point(641, 344);
            label10.Name = "label10";
            label10.Size = new Size(67, 17);
            label10.TabIndex = 16;
            label10.Text = "Adresse";
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(641, 309);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(166, 23);
            txtPrenom.TabIndex = 25;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label13.Location = new Point(641, 289);
            label13.Name = "label13";
            label13.Size = new Size(63, 17);
            label13.TabIndex = 24;
            label13.Text = "Prénom";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(641, 254);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(166, 23);
            txtNom.TabIndex = 23;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label14.ForeColor = SystemColors.ActiveCaptionText;
            label14.Location = new Point(641, 234);
            label14.Name = "label14";
            label14.Size = new Size(40, 17);
            label14.TabIndex = 22;
            label14.Text = "Nom";
            // 
            // chkClient
            // 
            chkClient.AutoSize = true;
            chkClient.Location = new Point(641, 393);
            chkClient.Name = "chkClient";
            chkClient.Size = new Size(93, 19);
            chkClient.TabIndex = 28;
            chkClient.Text = "Je suis Client";
            chkClient.UseVisualStyleBackColor = true;
            // 
            // chkCuisinier
            // 
            chkCuisinier.AutoSize = true;
            chkCuisinier.Location = new Point(733, 393);
            chkCuisinier.Name = "chkCuisinier";
            chkCuisinier.Size = new Size(108, 19);
            chkCuisinier.TabIndex = 29;
            chkCuisinier.Text = "Je suis Cuisinier";
            chkCuisinier.UseVisualStyleBackColor = true;
            // 
            // lblSuccesCreation
            // 
            lblSuccesCreation.AutoSize = true;
            lblSuccesCreation.ForeColor = Color.Green;
            lblSuccesCreation.Location = new Point(798, 452);
            lblSuccesCreation.Name = "lblSuccesCreation";
            lblSuccesCreation.Size = new Size(43, 15);
            lblSuccesCreation.TabIndex = 30;
            lblSuccesCreation.Text = "Succès";
            lblSuccesCreation.Visible = false;
            lblSuccesCreation.Click += label15_Click;
            // 
            // FormConnexion
            // 
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1101, 623);
            Controls.Add(lblSuccesCreation);
            Controls.Add(chkCuisinier);
            Controls.Add(chkClient);
            Controls.Add(txtPrenom);
            Controls.Add(label13);
            Controls.Add(txtNom);
            Controls.Add(label14);
            Controls.Add(lblErreurCreation);
            Controls.Add(txtTel);
            Controls.Add(label9);
            Controls.Add(txtAdresse);
            Controls.Add(label10);
            Controls.Add(button1);
            Controls.Add(txtMdpInscription);
            Controls.Add(label5);
            Controls.Add(txtEmailInscription);
            Controls.Add(label6);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblErreur);
            Controls.Add(btnConnexion);
            Controls.Add(textBox2);
            Controls.Add(txtPassword);
            Controls.Add(textBox1);
            Controls.Add(txtEmail);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "FormConnexion";
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string mdp = textBox2.Text;

            if (email == "root" && mdp == "root")
            {
                new FormEspaceAdmin().Show();
                this.Hide();
                return; // très important pour stopper ici
            }

            // Sinon, on interroge la base
            using var conn = ConnexionDB.GetConnection();
            string query = @"SELECT id_utilisateur, est_client, est_cuisinier
                 FROM utilisateurs
                 WHERE email = @Email AND mdp = @Mdp";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Mdp", mdp);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                bool isClient = reader.GetBoolean("est_client");
                bool isCuisinier = reader.GetBoolean("est_cuisinier");
                int id = reader.GetInt32("id_utilisateur");

                if (isClient && !isCuisinier)
                    new FormEspaceClient(id).Show();
                else if (isCuisinier && !isClient)
                    new FormEspaceCuisinier(id).Show();
                else
                    new FormEspaceAdmin().Show(); // multi-rôle

                this.Hide();
            }
            else
            {
                lblErreur.Text = "Identifiants incorrects.";
                lblErreur.Visible = true;
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string adresse = txtAdresse.Text.Trim();
            string tel = txtTel.Text.Trim();
            string email = txtEmailInscription.Text.Trim();
            string mdp = txtMdpInscription.Text;

            bool estClient = chkClient.Checked;
            bool estCuisinier = chkCuisinier.Checked;

            // Vérification de base
            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(mdp))
            {
                lblErreurCreation.Text = "Veuillez remplir tous les champs obligatoires.";
                lblErreurCreation.Visible = true;
                lblSuccesCreation.Visible = false;
                return;
            }
            if (mdp.Length < 6)
            {
                lblErreurCreation.Text = "Le mot de passe doit contenir au moins 6 caractères.";
                lblErreurCreation.Visible = true;
                lblSuccesCreation.Visible = false;
                return;
            }

            try
            {
                using var conn = ConnexionDB.GetConnection();
                string sql = @"INSERT INTO utilisateurs (nom, prenom, adresse, telephone, email, mdp, est_client, est_cuisinier)
                       VALUES (@nom, @prenom, @adresse, @tel, @email, @mdp, @estClient, @estCuisinier)";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@adresse", adresse);
                cmd.Parameters.AddWithValue("@tel", tel);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@mdp", mdp);
                cmd.Parameters.AddWithValue("@estClient", estClient);
                cmd.Parameters.AddWithValue("@estCuisinier", estCuisinier);

                cmd.ExecuteNonQuery();

                lblSuccesCreation.Text = "Compte créé avec succès !";
                lblSuccesCreation.Visible = true;
                lblErreurCreation.Visible = false;
            }
            catch (Exception ex)
            {
                lblErreurCreation.Text = "Erreur : " + ex.Message;
                lblErreurCreation.Visible = true;
                lblSuccesCreation.Visible = false;
            }
        }
    }
}
