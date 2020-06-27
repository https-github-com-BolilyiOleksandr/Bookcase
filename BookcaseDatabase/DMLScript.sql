use Bookcase;

-- select *
-- from Countries;
-- select *
-- from Languages;
-- select *
-- from Genres;
-- select *
-- from Ratings;
-- select *
-- from Publishers;
-- select *
-- from Authors;
-- select *
-- from Books;
-- select *
-- from AuthorsBooks;

select --A.ID as 'Author ID',
       A.LastName,
       A.FirstName,
       A.MiddleName,
       --C.ID as 'Country ID',
       C.Country,
       --B.ID as 'Book ID',
       B.ISBN,
       B.Title,
       B.NumberOfPages,
       B.Comment,
       --P.ID as 'Publisher ID',
       P.Publisher,
       --L.ID as 'Language ID',
       L.[Language],
       --G.ID as 'Genre ID',
       G.Genre,
       --R.ID as 'Rating ID',
       R.Rating
from AuthorsBooks as AB
inner join Authors as A
on AB.AuthorID = A.ID
inner join Books as B
on AB.BookID = B.ID
inner join Countries as C
on A.CountryID = C.ID
inner join Publishers as P
on B.PublisherID = P.ID
inner join Languages as L
on B.LanguageID = L.ID
inner join Genres as G
on B.GenreID = G.ID
inner join Ratings as R
on B.RatingID = R.ID
where AB.AuthorID = 1
and AB.BookID = 1
and AB.Active = 1;
