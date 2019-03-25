using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Entities
{
    public class PostEntity
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string Footer { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; } // is deleted 

        public List<CommentEntity> Comments { get; set; }
    }
}
