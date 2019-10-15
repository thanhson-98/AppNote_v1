using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNote_UWP.Entity
{
    class Note
    {
        private string Name { get; set; }
        private string Content { get; set; }
        
        public Note(string name, string content)
        {
            Name = name;
            Content = content;
        }
    }
}
