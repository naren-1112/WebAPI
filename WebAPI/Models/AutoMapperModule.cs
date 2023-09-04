using AutoMapper;

namespace WebAPI.Models
{
    public class BookViewModel
    {
        public int BookID { get; set; }
        public string Name { get; set; }
    }

    public class AutoMapperModule: Profile
    {
        public AutoMapperModule()
        {
            CreateMap<Books, BookViewModel>();
        }
    }
}
