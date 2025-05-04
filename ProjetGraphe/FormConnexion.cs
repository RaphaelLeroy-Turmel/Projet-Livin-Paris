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
        private Label lblErreur;

        private void InitializeComponent()
        {
            txtEmail = new Label();
            textBox1 = new TextBox();
            txtPassword = new Label();
            textBox2 = new TextBox();
            btnConnexion = new Button();
            lblErreur = new Label();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.AutoSize = true;
            txtEmail.Location = new Point(367, 101);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(36, 15);
            txtEmail.TabIndex = 0;
            txtEmail.Text = "Email";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(374, 143);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.AutoSize = true;
            txtPassword.Location = new Point(445, 222);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(77, 15);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "Mot de passe";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(445, 280);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 3;
            textBox2.UseSystemPasswordChar = true;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // btnConnexion
            // 
            btnConnexion.Location = new Point(639, 143);
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
            lblErreur.Location = new Point(767, 199);
            lblErreur.Name = "lblErreur";
            lblErreur.Size = new Size(38, 15);
            lblErreur.TabIndex = 5;
            lblErreur.Text = "Erreur";
            lblErreur.Visible = false;
            // 
            // Form1
            // 
            ClientSize = new Size(1101, 623);
            Controls.Add(lblErreur);
            Controls.Add(btnConnexion);
            Controls.Add(textBox2);
            Controls.Add(txtPassword);
            Controls.Add(textBox1);
            Controls.Add(txtEmail);
            Name = "Form1";
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

    }
}
