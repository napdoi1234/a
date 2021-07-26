using System.Threading.Tasks;
using ELibrary.Data.EF;
using ELibrary.Utilities.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ELibrary.Utilities.Constants.BookBorrowing;

namespace ELibrary.Service.AdminService.implements
{
  public class ConfirmBookService : IConfirmBookService
  {
    private readonly ELibraryDbContext _context;
    public ConfirmBookService(ELibraryDbContext context)
    {
      _context = context;
    }
    public async Task<bool> ConfirmBorrowedBooks(BookConfirmRequestDTO requestDTO)
    {
      var borrowedBooksRequest = await _context.BookBorrowingRequests.FindAsync(requestDTO.Id);
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
      return true;
    }

    public async Task<PagingResult<BookBorrowingRequestDTO>> ViewBorrowedBooks(BookBorrowingRequestDTO requestDTO)
    {
      var borrowedBooks = from bb in _context.BookBorrowingRequests
                          join d in _context.BookBorrowingRequestDetails on bb.Id equals d.RequestId
                          join b in _context.Books on d.BookId equals b.Id
                          join u in _context.Users on bb.UserId equals u.Id
                          orderby bb.Id
                          select new { bb, b, u };

      int totalRow = await borrowedBooks.CountAsync();

      var data = await borrowedBooks.Skip((requestDTO.PageIndex - 1) * requestDTO.PageSize)
          .Take(requestDTO.PageSize)
          .Select(x => new BookBorrowingRequestDTO()
          {
            Id = x.bb.Id,
            UserName = x.u.FullName,
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