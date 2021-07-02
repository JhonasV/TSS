using System;
using System.Collections.Generic;

#nullable disable

namespace TSS.Models
{
    public partial class RegistroEmpleadoTss
    {
        public int Id { get; set; }
        public string TipoEmpleador { get; set; }
        public string RazonSocial { get; set; }
        public string Rnc { get; set; }
        public string NombreComercial { get; set; }
        public string ActividadComercial { get; set; }
        public string Calle { get; set; }
        public string No { get; set; }
        public string Sector { get; set; }
        public string Municipio { get; set; }
        public string Provincia { get; set; }
        public string ReferenciaDireccion { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string EmailEmpresa { get; set; }
        public string NombreEmpleado { get; set; }
        public string CedulaEmpleado { get; set; }
    }
}
