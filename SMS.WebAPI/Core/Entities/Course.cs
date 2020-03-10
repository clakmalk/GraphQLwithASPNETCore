using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.Core.Entities
{
    public class Course
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public string Title { set; get; }
        public string Description { set; get; }
        public int Credits { set; get; }
    }
}
