using AutoMapper;
using BlogAPI.Data.Entities;
using BlogAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Infrastructure.Mappings
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<PostEntity, PostModel>();
            CreateMap<PostEntity, PostModel>().ReverseMap();

            CreateMap<CommentEntity, CommentModel>();
            CreateMap<CommentEntity, CommentModel>().ReverseMap();
        }
    }
}
