using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDotNet.EFCore
{
    public class EFCoreCRUD
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();//Because AppDbContext include SqlConnectionStringBuilder
            List< Model> lst = db.TestModel.ToList();
            //List<Model> lst=db.TestModel.ToList();
            foreach (Model item in lst)
            {
                //Console.WriteLine(item.Id);
                //Console.WriteLine(item.Customer_Name);
                //Console.WriteLine(item.Customer_Address);
                //Console.WriteLine(item.Item_Name);
            }
        }
    }
}
