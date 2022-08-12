using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities

{
    public class Author
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public Author()
        {                   }
        public Author(string name, string last, DateTime birthDate)
        {
            Name = name;
            LastName = LastName;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return new string(Name + " "+ LastName + " BD: "+BirthDate.Date);
        }

    }

}