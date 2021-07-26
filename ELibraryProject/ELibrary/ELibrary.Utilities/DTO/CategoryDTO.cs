namespace ELibrary.Utilities.DTO
{
  public class CategoryDTO : PagingRequest<CategoryDTO>
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}