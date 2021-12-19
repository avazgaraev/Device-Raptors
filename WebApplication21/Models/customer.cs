using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class customer
    {
        [Key]
        public int customerid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        //[Required(ErrorMessage ="This line should be filled")]s
        public string customername { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        //[Required(ErrorMessage = "This line should be filled")]
        public string customersurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50/*, ErrorMessage = "You can give max 50 characters for address"*/)]
        public string customeraddress { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20/*, ErrorMessage = "You can give max 20 characters for city"*/)]
        public string customercity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        //[Required/*(ErrorMessage = "This line should be filled")*/]
        public string customermail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        //[Required/*(ErrorMessage = "This line should be filled")*/]
        public string customerphone { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        //[Required/*(ErrorMessage = "This line should be filled")*/]
        public string customerpass { get; set; }

        public bool available { get; set; }
        public ICollection<salemove> Salemoves { get; set; } 
    }
}