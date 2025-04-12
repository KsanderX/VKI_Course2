﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Models
{
    public class RequestStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Request> Requests { get; set; } = new List<Request>();
    }
}
