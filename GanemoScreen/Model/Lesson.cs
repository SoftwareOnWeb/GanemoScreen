using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GanemoScreen.Model
{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Time { get; set; }
        public int? Duration { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public Guide Guide { get; set; }
    }

}
