using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication7
{
    public class ClassEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Class_id { get; set; }

        [MaxLength(20)]
        public string Stu_class { get; set; }
    }
}
