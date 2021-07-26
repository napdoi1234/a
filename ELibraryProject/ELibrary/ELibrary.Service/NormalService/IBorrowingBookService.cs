using System.Collections.Generic;
using System.Threading.Tasks;
using ELibrary.Utilities.DTO;

namespace ELibrary.Service.NormalService
{
  public interface IBorrowingBookService
  {
    public Task<BookBorrowingRequestDTO> BorrowBooks(BookBorrowingRequestDTO requestDTO);

    public Task<PagingResult<BookBorrowingRequestDTO>> ViewBorrowedBooks(BookBorrowingRequestDTO requestDTO);
  }
}