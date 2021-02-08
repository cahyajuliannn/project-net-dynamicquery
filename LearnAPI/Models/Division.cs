using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearnAPI.Models
{
    [Table ("divisions")]
    public class Division
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmenId { get; set; }
        public Department department { get; set; }
    }
}