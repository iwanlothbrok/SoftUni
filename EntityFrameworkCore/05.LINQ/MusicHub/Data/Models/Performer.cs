using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public Performer()
        {
            PerformerSongs = new HashSet<SongPerformer>();
        }
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public decimal NetWorth { get; set; }

        public ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
//⦁	Id – Integer, Primary Key
//⦁	FirstName – text with max length 20 (required) 
//⦁	LastName – text with max length 20 (required) 
//⦁	Age – Integer(required)
//⦁	NetWorth – decimal(required)
//⦁	PerformerSongs – collection of type SongPerformer
