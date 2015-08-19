using System;

namespace ShopMVCAPINew.Models {
    public class News {
        public int ID { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int ViewCount { get; set; }
        public DateTime AddDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}