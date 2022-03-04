using System.ComponentModel.DataAnnotations;

namespace Bbt.Campaign.Public.Dtos.Target
{
    public class TargetDto
    {
        public int Id { get; set; }
        [MaxLength(250), Required]
        public string Name { get; set; }
        [MaxLength(250), Required]
        public string Title { get; set; }
    }
}
