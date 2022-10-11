using System.ComponentModel.DataAnnotations;

namespace DapperDeneme.Model
{
    public class Factory
    {
        
      
        public int BaseFactory { get; set; }
        public string FactoryId { get; set; }
        [Required]
        public string FactoryName { get; set; }
    }
    public class Factory2
    {


        public int BaseFactory { get; set; }

        [Required]
        public string FactoryName { get; set; }
    }
}
