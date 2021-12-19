using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication21.Models
{
    public class kargofollow
    {
        [Key]
        public int kargofollowid { get; set; }

        [Column(TypeName ="VarChar")]
        [StringLength(25)]
        public string kargono { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string kargodetail{ get; set; }
        public DateTime kargofoldate{ get; set; }
    }

}