using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using mvccoreappgithub.App_GlobalResources;
using Microsoft.AspNetCore.Mvc;

namespace mvccoreappgithub.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("AllPeople")]
    public class Person
    {
        public Person()
        {

        }
        public Person(int Id, string name)
        {
            ID = Id;
            Name = name;
        }
        public override string ToString()
        {
            return ID.ToString() + ":" + Name;
        }


        [System.ComponentModel.DataAnnotations.Schema.Column("PersonID", Order = 0)]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.ScaffoldColumn(scaffold: false)]
        public int ID { get; set; }


        [System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage = "وارد کردن JID اجباری است")]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        [System.ComponentModel.DataAnnotations.Schema.Column("JobID", Order = 1)]
        public int JID { get; set; }


        [Required(ErrorMessage = "وارد کردن نام اجباری است")]
        [MaxLength(5)]
        [System.ComponentModel.DataAnnotations.StringLength(maximumLength: 5)]
        [System.ComponentModel.DataAnnotations.Schema.Column("FullName",TypeName = "VarChar(16)")]
        [System.ComponentModel.DataAnnotations.Display(Name = "FistName&LastName", Order = 10003)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        //[System.ComponentModel.DataAnnotations.RegularExpression(pattern: @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        //  , ErrorMessageResourceType = typeof(Resources.mvc00Resource), ErrorMessageResourceName = "Email")]
        [System.ComponentModel.DataAnnotations.Display(ResourceType = typeof(App_GlobalResources.Captions), Name = "Email", Order = 10002)]
        public string Email { get; set; }


        [System.ComponentModel.DataAnnotations.Compare(otherProperty: "Email")]
        [System.ComponentModel.DataAnnotations.RegularExpression(pattern: @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string RepeatEmail { get; set; }


        [Infrastructure.MaxWords(5)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false)]
        [Remote(action: "CheckUserName", controller: "Home")]
        public string UserName { get; set; }

        [System.ComponentModel.DataAnnotations.Range(maximum: "100", minimum: "15", type: typeof(int)
           , ErrorMessage = "{0}")]
        public int? Age { get; set; }


        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.PhoneNumber)]
        public int? Phone { get; set; }


        [System.ComponentModel.DataAnnotations.DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0 ریال}")]
        public int Salary { get; set; }

        [System.ComponentModel.DataAnnotations.StringLength(maximumLength: 5, MinimumLength = 3)]
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string Specification
        {
            get
            {
                return string.Format("{0},{1},{2}", ID.ToString(), JID.ToString(), Name);
            }
        }


    }
}
