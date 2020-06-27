use Bookcase;

insert into Countries
      (Country)
values('England');

insert into Languages
      (Language)
values('German');

insert into Genres
      (Genre)
values('Fantasy'),
      ('Science Fiction'),
      ('Horror'),
      ('Western'),
      ('Romance'),
      ('Thriller'),
      ('Mystery'),
      ('Detective'),
      ('Dystopia'),
      ('Newspaper'),
      ('Adventure');

insert into Ratings
      (Rating)
values(1),
      (2),
      (3),
      (4),
      (5);

insert into Publishers
      (Publisher)
values('Ravensburger Buchverlag');

insert into Authors
      (LastName, FirstName, CountryID)
values('Bradford', 'Chris', 1);

insert into Books
      (ISBN, Title, NumberOfPages, PublisherID, LanguageID, GenreID, RatingID)
values('978-3-473-40076-8', 'Samurai - Der Ring Des Wassers', 408, 1, 1, 11, 5);

insert into AuthorsBooks
      (AuthorID, BookID)
values
      (1, 1);
