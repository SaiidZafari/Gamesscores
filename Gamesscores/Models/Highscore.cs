using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gamesscores.Models
{
    public class Highscore
    {        
        public int Id { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "FullName shoold be more than 2 char.")]
        [MaxLength(22, ErrorMessage = "FullName can't be more than 20 char.")]
        public string Fullname { get; set; }

        [Required]
        [Display(Name = "Name Of game")]
        public string Game { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
