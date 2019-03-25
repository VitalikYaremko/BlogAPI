using BlogAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Interfaces
{
    public interface IBlogContext
    {
        DbSet<PostEntity> PostEntities { get; set; }
        DbSet<CommentEntity> CommentEntities { get; set; }
    }
}
