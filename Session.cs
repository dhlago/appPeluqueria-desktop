﻿using System;

namespace ProyectoPelu // <--- Namespace CORRECTO
{
    public static class Session
    {
        public static string Token { get; set; } = "";
        public static string? NombreUsuario { get; set; }
        public static string? Rol { get; set; }
    }
}
