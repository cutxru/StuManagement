using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication7
{
    public  class StudentEntity
    {
        [Key]
        [MaxLength(20)]
        public string Stu_id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Stu_name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Stu_class { get; set; }

        [Required]
        public int Stu_age { get; set; }

        [Required]
        [MaxLength(2)]
        public string  Stu_gender { get; set; }
    }
}
