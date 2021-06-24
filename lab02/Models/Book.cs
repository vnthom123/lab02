using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab02.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image_cover;
        public Book() { }
        public int Id { get { return id; } }
        [Required(ErrorMessage ="Tieu de khong duoc de trong")]
        [StringLength(250,ErrorMessage ="Tieu de sach khong duoc vuot qua 250 ky tu")]
        [Display(Name ="Tieu de")]
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Image_cover { get => image_cover; set => image_cover = value; }

        public Book(int id, string title, string author, string image_cover)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.image_cover = image_cover;
        }
    }
}