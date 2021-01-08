using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArcherLogic_Salon_Solution
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        //public byte Photo { get; set; }
        public string HowDidYouFindUsDropDownList { get; set; }
        //public IEnumerable<HowDidYouFindUsDropDownListViewModel> HowDidYouFindUsDropDownList { get; set; }
    }

    public class HowDidYouFindUsDropDownListViewModel
    {
        public int Id { get; set; }
        public string SocialMediaName { get; set; }
    }

    public class UserBindingModel
    {
        [Required]
        public string UserName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        //public byte Photo { get; set; }
        public string HowDidYouFindUsDropDownList { get; set; }
    }
    //public class UserGetViewModel
    //{
    //    public int Id { get; set; }
    //    public string UserName { get; set; }
    //    public DateTime DateOfBirth { get; set; }
    //    public string Address { get; set; }
    //    public string Gender { get; set; }
    //    public int ContactNumber { get; set; }
    //    public byte Photo { get; set; }
    //    public string HowDidYouFindUsDropDownList { get; set; }
    //}
}
