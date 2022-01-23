using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomeEdorJs.Models
{
    public class ModelFile
    {
        public int success { get; set; }
        public MFile file { get; set; }

    }
    public class MFile
    {
        public string url { get; set; }
    }
}