﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.WebAPI.Core.Entities
{
    public class Course
    {
        private int _id = -1;
        private string _title = string.Empty;
        private string _description = string.Empty;
        private int _credits = 0;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public string Description { get => _description; set => _description = value; }
        public int Credits { get => _credits; set => _credits = value; }
    }
}
