using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvalRaulClaros.Models
{
    public class EvalClaros
    {
        [Key]
        [Display(Name= "Nombre del Pais")]
        public string Name { get; set; }


        [Display(Name = "Nombre de la capital")]
        public string Capital { get; set; }

        [Range(-90, 90)]
        public int Latitud { get; set; }

        [Range(-180, 180)]
        public int Longitud { get; set; }

        [RegularExpression(@"^(0[1-9]|1[0-2]):[0-5][0-9] (am|pm|AM|PM)$", ErrorMessage = "Invalid Time.")]
        public int Timezones { get; set; }

        [Display(Name = "Ingresar nombre de la moneda")]
        public string Currencies { get; set; }

        [Url()]
        public int Flag { get; set; }
    }
}