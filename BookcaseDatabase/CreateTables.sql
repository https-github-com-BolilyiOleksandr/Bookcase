use Bookcase;

create table Countries
(
    ID int identity(1, 1) primary key not null,
    Country nvarchar(60) unique not null,
    Active bit not null default 1
)

create table Languages
(
    ID int identity(1, 1) primary key not null,
    Language nvarchar(50) unique not null,
    Active bit not null default 1
)

create table Genres
(
    ID int identity(1, 1) primary key not null,
    Genre nvarchar(50) unique not null,
    Active bit not null default 1
)

create table Ratings
(
    ID int identity(1, 1) primary key not null,
    Rating int unique not null,
    Active bit not null default 1
)

create table Publishers
(
    ID int identity(1, 1) primary key not null,
    Publisher nvarchar(100) unique not null,
    Active bit not null default 1
)

create table Authors
(
    ID int identity(1, 1) primary key not null,
    LastName nvarchar(50) not null,
    FirstName nvarchar(50) not null,
    MiddleName nvarchar(50) default '',
    Active bit not null default 1,
    CountryID int not null,

    constraint FK_Authors_Countries foreign key (CountryID) references Countries (ID)
)

create table Books
(
    ID int identity(1, 1) primary key not null,
    ISBN nvarchar(50) not null,
    Title nvarchar(max) not null,
    NumberOfPages int not null,
    Comment nvarchar(100) default '',
    Active bit not null default 1,
    PublisherID int not null,
    LanguageID int not null,
    GenreID int not null,
    RatingID int not null,

    constraint FK_Books_Publishers foreign key (PublisherID) references Publishers (ID),
    constraint FK_Books_Languages foreign key (LanguageID) references Languages (ID),
    constraint FK_Books_Genres foreign key (GenreID) references Genres (ID),
    constraint FK_Books_Ratings foreign key (RatingID) references Ratings (ID)
)

create table AuthorsBooks
(
    AuthorID int not null,
    BookID int not null,
    Active bit not null default 1,

    constraint PK_AuthorsBooks primary key (AuthorID, BookID),
    constraint FK_AuthorsBooks_Authors foreign key (AuthorID) references Authors (ID),
    constraint FK_AuthorsBooks_Books foreign key (BookID) references Books (ID)
)
