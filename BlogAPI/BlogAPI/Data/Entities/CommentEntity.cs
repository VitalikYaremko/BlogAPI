using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Entities
{
    public class CommentEntity
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
        public PostEntity Post { get; set; }
    }
}
