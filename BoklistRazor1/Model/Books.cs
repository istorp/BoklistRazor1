using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoklistRazor1.Model
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Auther { get; set; }
        public string ISBN { get; set; }

    }
}
