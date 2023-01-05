using System.ComponentModel;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName ("Display Order")]
        public string DisplayOrder { get; set; }
        [DisplayName("Date Time ")]
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

    }
}
