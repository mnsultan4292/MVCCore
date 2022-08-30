using Microsoft.EntityFrameworkCore;
using MVCCore.Models;

namespace MVCCore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDBContext _db;
        public BookRepository(BookDBContext bookDBContext)
        {
            _db = bookDBContext;
        }
        public async Task<IEnumerable<MasterBook>> GetBooks()
        {
            if (_db != null)
            {
                return await _db.MasterBooks.ToListAsync();
            }
            return null;
        }
        public async Task<MasterBook> GetBookById(int BookId)
        {
            if (_db != null)
            {
                var data=await _db.MasterBooks.FirstOrDefaultAsync(x => x.BookId == BookId);
                if(data!=null)
                    return data;
            }
            return null;
        }
        public async Task<int> PostBook(MasterBook masterBook)
        {
            int result = 0;
            if (_db != null)
            {
                _db.MasterBooks.Add(masterBook);
                result=await _db.SaveChangesAsync();
            }
            return result;
        }
        public async Task<int> UpdateBook(MasterBook masterBook)
        {
            int result = 0;
            if (_db != null)
            {
                _db.MasterBooks.Update(masterBook);
                result = await _db.SaveChangesAsync();
            }
            return result;
        }
        public async Task<int> DeleteBook(int BookId)
        {
            int result = 0;
            if (_db != null)
            {
                var data =await _db.MasterBooks.FirstOrDefaultAsync(x => x.BookId == BookId);
                if (data != null)
                {
                    _db.MasterBooks.Remove(data);
                    result = await _db.SaveChangesAsync();
                }
            }
            return result;
        }
    }
}
