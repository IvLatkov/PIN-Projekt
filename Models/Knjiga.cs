using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PINprojekt_Ivan_Latkovic.Models
{
    public class Knjiga
    {

       [Key]
        public int Id { get; set; }
       [Required]
        public string Ime { get; set; }
        public string Autor { get; set; }
        public string RedniBroj { get; set; }


    }
}
