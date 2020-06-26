using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class UserTablaViewModel{
        
            public int Id { get; set; }
            [Required]
            [StringLength(50)]
            [Display(Name = "Nombre")] 
            public string userName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Correo electrónico")]
            public string email { get; set; }
            [Required]
            [DataType(DataType.Date)] 
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] 
            public DateTime birthDate { get; set; }
    }
}