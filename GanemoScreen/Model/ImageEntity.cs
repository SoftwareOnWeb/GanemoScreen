using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GanemoScreen.Model
{
    public class ImageEntity
    {
        public int Id { get; set; }
        public string ImageInfo { get; set; }
        public byte[] Image { get; set; }
    }
}
