using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDotNet.Models
{
    [Table("C#_Table")]//equal table
    public class TestModel
    {
        [Key]
        //[Column("Id")]//column=field if not equal Database
        public int Id { get; set; }

        public string Customer_Name { get; set; }

        public string Customer_Address { get; set; }

        public string Item_Name { get; set; }


    }
}
