﻿using System;
using System.Windows.Forms;
using appPeluqueriaDesktop; // Asegúrate de tener este using si Session está aquí

namespace ProyectoPelu
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Abre el formulario de Login de forma modal.
            using (var loginForm = new iniciar_Sesion())
            {
                // 2. Ejecuta el login y espera el resultado.
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // 3. SOLO si el login fue exitoso (Session.Token ya está guardado), 
                    // se crea y se ejecuta la página principal.
                    Application.Run(new pagina_principal());
                }
                // Si el DialogResult no es OK, la aplicación termina aquí.
            }
        }
    }
}
