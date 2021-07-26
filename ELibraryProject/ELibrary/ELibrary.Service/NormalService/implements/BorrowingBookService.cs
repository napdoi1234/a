using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.Data.EF;
using ELibrary.Data.Entities;
using ELibrary.Utilities.Constants.BookBorrowing;
using ELibrary.Utilities.Constants.User;
using ELibrary.Utilities.DTO;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Service.NormalService.implements
{
  public class BorrowingBookService : IBorrowingBookService
  {
    private readonly ELibraryDbContext _context;
    public BorrowingBookService(ELibraryDbContext context)
    {
      _context = context;
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
        if (canRequest > 3)
        {
          bookRequest = new BookBorrowingRequestDTO { Message = BorrowConstant.LimitRequest };
          return bookRequest;
        }

        var requestEntity = new BookBorrowingRequest
        {
          UserId = requestDTO.UserId,
          DateRequest = requestDTO.DateRequest,
          Users = new List<User> { userRequest },
        };
        _context.BookBorrowingRequests.Add(requestEntity);
        await _context.SaveChangesAsync();

        BookBorrowingRequestDetails detailRequest = null;
        Book book = null;
        foreach (int bookId in requestDTO.IdBooks)
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

        return new BookBorrowingRequestDTO
        {
          Id = requestEntity.Id,
          Status = requestEntity.Status,
        };
      }
      catch
      {
        return null;
      }
    }

    public async Task<PagingResult<BookBorrowingRequestDTO>> ViewBorrowedBooks(BookBorrowingRequestDTO requestDTO)
    {
      var borrowedBooks = from bb in _context.BookBorrowingRequests
                          join d in _context.BookBorrowingRequestDetails on bb.Id equals d.RequestId
                          join b in _context.Books on d.BookId equals b.Id
                          where bb.UserId == requestDTO.UserId
                          orderby bb.Id
                          select new { bb, b };

      int totalRow = await borrowedBooks.CountAsync();

      var data = await borrowedBooks.Skip((requestDTO.PageIndex - 1) * requestDTO.PageSize)
        .Take(requestDTO.PageSize)
        .Select(x => new BookBorrowingRequestDTO()
        {
          Id = x.bb.Id,
          DateRequest = x.bb.DateRequest,
          Status = x.bb.Status,
          NameBook = x.b.Name,
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