using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace giantbombTest.Models
{
    public class GameItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int GbID { get; set; }
        public string Platform { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}
