using System.ComponentModel.DataAnnotations;

namespace DLL.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
