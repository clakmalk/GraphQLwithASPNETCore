using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.Core.Entities
{
    public class Enrollement
    {
        private int _studentId = -1;
        private int _courseId = -1;
        private DateTime _regDate = DateTime.Now;
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now;
        private string _grade = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public int StudentId { get => _studentId; set => _studentId = value; }
        public int CourseId { get => _courseId; set => _courseId = value; }
        public DateTime RegDate { get => _regDate; set => _regDate = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public string Grade { get => _grade; set => _grade = value; }
    }
}
