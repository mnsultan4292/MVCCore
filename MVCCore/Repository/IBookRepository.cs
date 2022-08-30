using MVCCore.Models;

namespace MVCCore.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<MasterBook>> GetBooks();
        Task<MasterBook> GetBookById(int BookId);
        Task<int> PostBook(MasterBook masterBook);
        Task<int> UpdateBook(MasterBook masterBook);
        Task<int> DeleteBook(int BookId);
    }
}
