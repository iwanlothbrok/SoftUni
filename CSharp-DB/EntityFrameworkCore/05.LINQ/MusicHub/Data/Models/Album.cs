using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            Albums = new HashSet<Album>();
            Songs = new HashSet<Song>();
        }
        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }

        public decimal Price
          => this.Songs.Sum(s => s.Price);

        public int? ProducerId { get; set; }
        public Producer Producer { get; set; }

        public ICollection<Album> Albums { get; set; }
        public ICollection<Song> Songs { get; set; }


    }
}
//⦁	Id – Integer, Primary Key
//⦁	Name – Text with max length 40 (required)
//⦁	ReleaseDate – Date(required)
//⦁	Price – calculated property(the sum of all song prices in the album)
//⦁	ProducerId – integer, Foreign key
//⦁	Producer – the album’s producer
//⦁	Songs – collection of all Songs in the Album 
