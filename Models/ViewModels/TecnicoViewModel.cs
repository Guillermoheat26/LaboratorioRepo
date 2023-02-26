using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Laboratorio.Models.ViewModels
{
    public class TecnicoViewModel
    {

        public int id_tecnico { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Codigo")]
        public string codigo { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Sueldo Base")]
        public decimal? sueldo_base { get; set; }
        [Required]
        [Display(Name = "Sucursal")]
        public string nombre_sucursal { get; set; }
        public string elementos { get; set; }

    }
}