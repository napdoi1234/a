using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.Data.EF;
using ELibrary.Data.Entities;
using ELibrary.Utilities.Constants.BookBorrowing;
using ELibrary.Utilities.Constants.User;
using ELibrary.Utilities.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ELibrary.Service.NormalService.implements
{
  public class BorrowingBookService : IBorrowingBookService
  {
    private readonly ELibraryDbContext _context;
    private readonly ILogger<BorrowingBookService> _logger;
    public BorrowingBookService(ELibraryDbContext context, ILogger<BorrowingBookService> logger)
    {
      _context = context;
      _logger = logger;
    }
    public async Task<BookBorrowingRequestDTO> BorrowBooks(BookBorrowingRequestDTO requestDTO)
    {

      BookBorrowingRequestDTO bookRequest = null;
      using var transaction = await _context.Database.BeginTransactionAsync();

      try
      {
        var userRequest = await _context.Users.FindAsync(requestDTO.UserId);
        if (userRequest == null)
        {
          bookRequest = new BookBorrowingRequestDTO { Message = UserConstant.NotFoundUser };
          return bookRequest;
        };

        var nowDay = System.DateTime.Now;
        var newestDay = nowDay.AddMonths(-1);
        var canRequest = await _context.BookBorrowingRequests.CountAsync(x =>
        x.UserId == userRequest.Id
        && x.DateRequest <= nowDay
        && x.DateRequest > newestDay);
        if (canRequest >= 3)
        {
          bookRequest = new BookBorrowingRequestDTO { Message = BorrowConstant.LimitRequest };
          return bookRequest;
        }

        var requestEntity = new BookBorrowingRequest
        {
          Id = new Guid(),
          UserId = requestDTO.UserId,
          DateRequest = requestDTO.DateRequest,
          Users = new List<User> { userRequest },
        };
        _context.BookBorrowingRequests.Add(requestEntity);
        await _context.SaveChangesAsync();

        BookBorrowingRequestDetails detailRequest = null;
        Book book = null;
        foreach (Guid bookId in requestDTO.IdBooks)
        {
          book = await _context.Books.FindAsync(bookId);
          detailRequest = new BookBorrowingRequestDetails
          {
            BookId = book.Id,
            Book = book,
            Request = requestEntity,
            RequestId = requestEntity.Id,
          };
          _context.BookBorrowingRequestDetails.Add(detailRequest);
        }
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();

        bookRequest = new BookBorrowingRequestDTO
        {
          Id = requestEntity.Id,
          Status = requestEntity.Status,
        };
      }
      catch
      {
        _logger.LogInformation("Some errors happen when using database");
      }
      return bookRequest;
    }

    public async Task<PagingResult<BookBorrowingRequestDTO>> ViewBorrowedBooks(BookBorrowingRequestDTO requestDTO)
    {
      var borrowedBooks = from borrowBook in _context.BookBorrowingRequests
                          join borrowBookDetail in _context.BookBorrowingRequestDetails on borrowBook.Id equals borrowBookDetail.RequestId
                          join book in _context.Books on borrowBookDetail.BookId equals book.Id
                          where borrowBook.UserId == requestDTO.UserId
                          orderby borrowBook.Id
                          select new { borrowBook, book };

      int totalRow = await borrowedBooks.CountAsync();

      var data = await borrowedBooks.Skip((requestDTO.PageIndex - 1) * requestDTO.PageSize)
        .Take(requestDTO.PageSize)
        .Select(x => new BookBorrowingRequestDTO()
        {
          Id = x.borrowBook.Id,
          DateRequest = x.borrowBook.DateRequest,
          Status = x.borrowBook.Status,
          NameBook = x.book.Name,
        }).ToListAsync();

      var pagedResult = new PagingResult<BookBorrowingRequestDTO>()
      {
        Items = data,
        TotalRecords = totalRow,
        PageSize = requestDTO.PageSize,
        PageIndex = requestDTO.PageIndex,
      };

      return pagedResult;
    }
  }
}