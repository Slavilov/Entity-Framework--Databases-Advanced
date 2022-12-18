using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Content { get; set; }

        public ContenType ContenType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; } // - Казваме, че това ще бъде Foreign Key, тоест това е името на PrimaryKey-a във класът Student
        public virtual Student Student { get; set; } // - А със навигационното пропърти казваме към кой клас(таблица във БД) да насочим Foreign Key-a 

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
