
using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            SongPerformers = new HashSet<SongPerformer>();
        }
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }

        public Genre Genre { get; set; }

        public int? AlbumId { get; set; }
        public Album Album { get; set; }

        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        public decimal Price { get; set; }

        public ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
//⦁	id – integer, primary key
//⦁	name – text with max length 20 (required)
//⦁	duration – timespan(required)
//⦁	createdon – date(required)
//⦁	genre – genre enumeration with possible values: "blues, rap, popmusic, rock, jazz"(required)
//⦁	albumid – integer, foreign key
//⦁	album – the song’s album
//⦁	writerid – integer, foreign key (required)
//⦁	writer – the song’s writer
//⦁	price – decimal (required)
//⦁	songperformers – collection of type songperformer
