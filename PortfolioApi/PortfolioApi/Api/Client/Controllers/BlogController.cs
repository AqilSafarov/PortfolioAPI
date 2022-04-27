using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Api.Client.DTOs.BlogDto;
using PortfolioApi.Data;
using PortfolioApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BlogController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Blog> blog = await _context.Blogs.ToListAsync();


            List<BlogGetDto> blogGetDto = _mapper.Map<List<BlogGetDto>>(blog);
            foreach (var item in blogGetDto)
            {
                if (item.Desc.Length > 50)
                {
                    item.Desc = item.Desc.Substring(0, 50);

                }

            }
            return Ok(blogGetDto);
        }
        [HttpGet("{id}")]
        public IActionResult SingleGet(int id)
        {
            var query = from b in _context.Blogs
                        join r in _context.TagToBlogs
                        on b.Id equals r.BlogId
                        join t in _context.Tags
                        on r.TagId equals t.Id
                        where b.Id == id
                        select
                        new
                        {
                            b.Title,
                            b.Desc,
                            b.Image,
                            b.CreatedAt,
                            t.TagName
                        };



            return Ok(query);

        }
    }
}
