using Microsoft.EntityFrameworkCore;

namespace Rectangles.Db.Models
{
    public sealed class RectangleEntity
    {
        public long Id { get; set; }
        
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double X3 { get; set; }
        public double Y3 { get; set; }
        public double X4 { get; set; }
        public double Y4 { get; set; }
    }
}
