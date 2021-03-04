using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ThingToDo
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [Column (TypeName="nvarchar(100)")]
        public string Content { get; set; }
        public bool IsDone { get; set; }
    }
}
