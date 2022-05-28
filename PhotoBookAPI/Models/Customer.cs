using System.ComponentModel.DataAnnotations;

namespace PhotoBookAPI.Models
{
    public class Customer
    {
        [Key]
        public int customer_nr { get; private set; }
        public int balance { get; private set; }
        public string telephone_nr { get; private set; }
    }
}
