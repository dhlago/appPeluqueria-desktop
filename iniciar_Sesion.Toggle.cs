using System;
using System.Windows.Forms;

namespace ProyectoPelu
{
    public partial class iniciar_Sesion
    {
        private void lblTogglePassword_Click(object sender, EventArgs e)
        {
            if (textBoxContrasenya.PasswordChar == '\u25CF')
            {
                textBoxContrasenya.PasswordChar = '\0'; // Show password
                lblTogglePassword.Text = "\uD83D\uDE48"; // Change icon to "hidden" (🙈)
            }
            else
            {
                textBoxContrasenya.PasswordChar = '\u25CF'; // Hide password
                lblTogglePassword.Text = "\uD83D\uDC41"; // Change icon to "visible" (👁)
            }
        }
    }
}
