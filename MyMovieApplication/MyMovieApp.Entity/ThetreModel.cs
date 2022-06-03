using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyMovieApp.Entity
{
    public class ThetreModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ThetreId { get; set; }
        public string ThetreName { get; set; }
        public string ThetreLocation { get; set; }

        public int ThetreCapacity { get; set; }

    }        
}
