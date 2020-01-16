using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace omdbapp.Models
{
    public class RatingItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Source { get; set; }
        public string Value { get; set; }
        public int MovieDetailsModelId { get; set; }
    }
}