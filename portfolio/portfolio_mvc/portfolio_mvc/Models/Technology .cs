using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Technology
    {
        //Key notation to assign Primary Key
        //Optional DatabaseGenerated Attribute
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }

        //Navigation Properties
        //Child Tables
        public virtual ICollection<TechnologyProject> TechnologyProjects { get; set; }
    }
}
