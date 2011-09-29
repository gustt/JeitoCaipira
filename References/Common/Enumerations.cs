using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace References.Common
{
    public static class Enumerations
    {
        public enum TipoPerfil
        {
            [Description("Perfil Administrativo")]
            Administrador,
            [Description("Perfil de Usuário (Cliente)")]
            Cliente,
            [Description("Sem perfil definido")]
            NaoDefinido = 99
        }
    }
}
