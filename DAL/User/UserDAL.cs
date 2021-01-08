using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArcherLogic_Salon_Solution.DAL
{
    public class UserDAL
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string USERNAME { get; set; }
        [Required]
        public string DATE_OF_BIRTH { get; set; }
        [Required]
        public string ADDRESS { get; set; }
        [Required]
        public string GENDER { get; set; }
        [Required]
        public string CONTACT_NUMBER { get; set; }
        //[Required]
        //public byte[] PHOTO { get; set; }
        [Required]
        public string HOW_DID_YOU_FIND_US { get; set; }
        public int IS_ACTIVE { get; set; }
    }
}
