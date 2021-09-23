using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EastIndia.Services
{
    public class Node
    {
        public string name { get; set; }

        public Node connectionOne { get; set; }

        public Node connectionTwo { get; set; }
    }
}