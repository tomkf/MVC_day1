using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class TechnologyProject
    {
        //Key notation to assign Primary Key
        //Optional Column Attribute
        [Key, Column(Order = 0)]
        public string TechnologyName { get; set; }

        [Key, Column(Order = 1)]
        public int ProjectId { get; set; }

        //Navigation Properties
        //Parent Tables
        public virtual Technology Technology { get; set; }
        public virtual Project Project { get; set; }

    }
}
