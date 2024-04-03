using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUICrudApp.Models
{
    public class StudentModel
    {
        [PrimaryKey, AutoIncrement]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
    }
}
