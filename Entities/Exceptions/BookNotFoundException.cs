namespace Entities.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id)
            : base($"The book with id: {id} could not found.")
        {

        }
    }

    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int id) : base($"Category with id: {id} could not found.")
        {
        }
    }
}
