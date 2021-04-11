using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class PhotoGraphy
    {
        
        public int Id { get; set; }

        public string Title { get; set; }

        public string Path { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }

    }

}
