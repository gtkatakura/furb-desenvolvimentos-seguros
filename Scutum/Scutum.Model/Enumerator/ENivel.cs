using System;

namespace Scutum.Model.Enumerator
{
    [Flags]
    public enum ENivel
    {
        None = 0,
        Admin = 1,
        Grupo = 2,
        Atendente = 4,
        Cliente = 8,
        Solicitante = 16
    }
}