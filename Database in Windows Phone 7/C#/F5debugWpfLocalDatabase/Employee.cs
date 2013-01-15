
using System.Data.Linq.Mapping;

namespace F5debugWpfLocalDatabase
{
        [Table]
        public class Employee
        {
            [Column(IsPrimaryKey = true)]
            public int EmployeeID
            {
                get;
                set;
            }
            [Column(CanBeNull = false)]
            public string EmployeeName
            {
                get;
                set;
            }
            [Column(CanBeNull = false)]
            public string EmployeeAge
            {
                get;
                set;
            }
        }
}
