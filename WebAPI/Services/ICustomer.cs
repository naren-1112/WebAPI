using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ICustomer
    {
        void AddBooks(Books book);

        bool Delete(int ID);
        List<Books> GetBooks();
        Books GetBookbyId(int ID);  
    }
}
