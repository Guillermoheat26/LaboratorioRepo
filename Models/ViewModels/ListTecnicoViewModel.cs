using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio.Models.ViewModels
{
    public class ListTecnicoViewModel
    {
        public int id_tecnico { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public decimal? sueldo_base { get; set; }


    }
}