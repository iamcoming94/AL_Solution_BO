﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArcherLogic_Salon_Solution.DAL
{
    public class PhotoDAL
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string NAME { get; set; }
        public byte[] DATA { get; set; }
        public int USER_ID { get; set; }
    }
}
