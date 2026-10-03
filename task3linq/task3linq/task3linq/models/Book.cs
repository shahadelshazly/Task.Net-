using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Q1: Why did the property "Id" become a Primary Key without any explicit configuration?
// Answer: Because EF Core follows the convention that any property named "Id" or "ClassNameId" automatically becomes the Primary Key.

// Q2: Why is "Country" nullable in the database while "Price" is not?
// Answer: Because "Country" is a reference type with a question mark (string?),
// making it nullable by convention, whereas "Price" is a value type (decimal) which is non-nullable by default.
namespace task3linq.models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
