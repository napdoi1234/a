using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Review2.Entities
{
    [Table("Books")]
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public ClientEntity Client { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public List<AuthorEntity> Authors { get; set; }
    }
}