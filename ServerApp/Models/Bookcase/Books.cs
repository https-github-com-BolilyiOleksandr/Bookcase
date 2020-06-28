using System;
using System.Collections.Generic;

namespace ServerApp.Models.Bookcase
{
    public partial class Books
    {
        public Books()
        {
            AuthorsBooks = new HashSet<AuthorsBooks>();
        }

        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int NumberOfPages { get; set; }
        public string Comment { get; set; }
        public bool? Active { get; set; }
        public int PublisherId { get; set; }
        public int LanguageId { get; set; }
        public int GenreId { get; set; }
        public int RatingId { get; set; }

        public virtual Genres Genre { get; set; }
        public virtual Languages Language { get; set; }
        public virtual Publishers Publisher { get; set; }
        public virtual Ratings Rating { get; set; }
        public virtual ICollection<AuthorsBooks> AuthorsBooks { get; set; }
    }
}
