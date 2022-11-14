using System;
using System.Drawing;
using System.Windows.Forms;
using HashUtils;

namespace PracticaHashing
{
    public partial class frmHashing : Form
    {
        public frmHashing()
        {
            InitializeComponent();
        }

        HashUser hs = new HashUser();

        private void frmHashing_Load(object sender, EventArgs e)
        {
            //Seleccionar el tipo de Hash aplicado
            string fechaActual = DateTime.Now.ToString("yyyyMMdd");
            txtOriginalSalt.Text = hs.createSalt(fechaActual);

            txtOriginalPassword.Text = hs.createPassword(txtOriginalSalt.Text.ToString());

            //txtHashedPassword.Text = txtOriginalPassword.Text;
        }

        private void btnValida_Click(object sender, EventArgs e)
        {
            string confirmacion;
            confirmacion = hs.validatePassword(txtOriginalSalt.Text, txtPassword.Text.ToString());
            txtHashedPassword.Text = confirmacion.ToString();
            if (txtOriginalPassword.Text == txtHashedPassword.Text)
            {
                lblResult.BackColor = Color.Green;
                lblResult.Text = "Correcte!";
            }
            else
            {
                lblResult.BackColor = Color.Red;
                lblResult.Text = "Inorrecte";
            }
        }
    }
}
