using System.Threading.Tasks;
using ELibrary.Data.EF;
using ELibrary.Utilities.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ELibrary.Utilities.Constants.BookBorrowing;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;

namespace ELibrary.Service.AdminService.implements
{
  public class ConfirmBookService : IConfirmBookService
  {
    private readonly ELibraryDbContext _context;
    private readonly ILogger<ConfirmBookService> _logger;
    public ConfirmBookService(ELibraryDbContext context, ILogger<ConfirmBookService> logger)
    {
      _context = context;
      _logger = logger;
    }
    public async Task<bool> ConfirmBorrowedBooks(BookConfirmRequestDTO requestDTO)
    {
      using var transaction = await _context.Database.BeginTransactionAsync();
      try
      {
        var borrowedBooksRequest = await _context.BookBorrowingRequests.Where(x => x.Id == requestDTO.Id).Include(x => x.Users).FirstOrDefaultAsync();
        if (borrowedBooksRequest == null || borrowedBooksRequest.Status == BorrowConstant.ApproveStatus
        || borrowedBooksRequest.Status == BorrowConstant.RejectStatus)
        {
          return false;
        }

        borrowedBooksRequest.Status = requestDTO.Status;
        var userConfirm = await _context.Users.FindAsync(requestDTO.UserId);
        borrowedBooksRequest.Users.Add(userConfirm);
        borrowedBooksRequest.ManagerId = userConfirm.Id;
        _context.BookBorrowingRequests.Update(borrowedBooksRequest);
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();
        return true;
      }
      catch
      {
        _logger.LogInformation("Errors happen when using database");
      }
      return false;
    }

    public async Task<PagingResult<BookBorrowingRequestDTO>> ViewBorrowedBooks(PagingRequest request)
    {
      var borrowedBooks = from borrowBook in _context.BookBorrowingRequests
                          join borrowBookDetail in _context.BookBorrowingRequestDetails on borrowBook.Id equals borrowBookDetail.RequestId
                          join book in _context.Books on borrowBookDetail.BookId equals book.Id
                          join user in _context.Users on borrowBook.UserId equals user.Id
                          orderby borrowBook.Id
                          select new { borrowBook, book, user };

      int totalRow = await borrowedBooks.CountAsync();

      var data = await borrowedBooks.Skip((request.PageIndex - 1) * request.PageSize)
          .Take(request.PageSize)
          .Select(x => new BookBorrowingRequestDTO()
          {
            Id = x.borrowBook.Id,
            UserName = x.user.FullName,
            DateRequest = x.borrowBook.DateRequest,
            Status = x.borrowBook.Status,
            NameBook = x.book.Name,
          }).ToListAsync();

      var pagedResult = new PagingResult<BookBorrowingRequestDTO>()
      {
        Items = data,
        TotalRecords = totalRow,
        PageSize = request.PageSize,
        PageIndex = request.PageIndex,
      };

      return pagedResult;
    }
  }
}