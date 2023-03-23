using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balta.ContentContext
{
    public class Career : Content
    {
        public Career(string title, string Url) : base(title, Url)
        {
        }

        List<CareerItem> Items { get; set; } = new List<CareerItem>();
        public int TotalCourses => Items.Count;
        
    }



}
