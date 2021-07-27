using System.Threading.Tasks;
using ELibrary.Utilities.DTO;

namespace ELibrary.Service.AdminService
{
  public interface IConfirmBookService
  {
    public Task<bool> ConfirmBorrowedBooks(BookConfirmRequestDTO requestDTO);

    public Task<PagingResult<BookBorrowingRequestDTO>> ViewBorrowedBooks(PagingRequest requestDTO);
  }
}