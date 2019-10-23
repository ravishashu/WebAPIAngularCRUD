using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Paymentdetails
    {
        [Key]
        [Required]
        public int PMID { get; set; }
        [Required]
        [Column(TypeName = ("varchar(100)"))]
        public string CardHolderName { get; set; }
        [Column(TypeName = ("varchar(16)"))]
        [Required]
        public string CardNumber { get; set; }
        [Column(TypeName = ("varchar(5)"))]
        [Required]
        public string ExpireDate { get; set; }
        [Required]
        [Column(TypeName = ("varchar(3)"))]
        public string CVV { get; set; }
    }
}
