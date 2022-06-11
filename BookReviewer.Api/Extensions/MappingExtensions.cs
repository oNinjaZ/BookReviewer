using BookReviewer.Api.Dtos.Book;
using BookReviewer.Api.Models;

namespace BookReviewer.Api.Extensions;

public static class MappingExtensions
{
    public static BookDto AsDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            PublishDate = book.PublishDate,
            PageCount = book.PageCount
        };
    }
}