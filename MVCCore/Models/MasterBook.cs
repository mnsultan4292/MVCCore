using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCCore.Models
{
    public partial class MasterBook
    {

        public int BookId { get; set; }
        [Required(ErrorMessage = "Book Name is required!")]
        public string BookName { get; set; } = null!;
        [Required(ErrorMessage ="Book Author Auhor is required!")]
        public string BookAuthor { get; set; } = null!;
        [Required(ErrorMessage = "Course Name Auhor is required!")]
        public string CourseName { get; set; } = null!;
        [Required(ErrorMessage = "Purchase Date is required!")]
        public DateTime PurchaseDate { get; set; }
    }
}
