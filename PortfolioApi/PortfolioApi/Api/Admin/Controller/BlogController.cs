using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Api.Admin.AdminDTOs.ABlogDto;
using PortfolioApi.Api.Admin.AdminDTOs.ATagDto;
using PortfolioApi.Data;
using PortfolioApi.Data.Models;
using PortfolioApi.Vm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Admin.Controller
{
    [Route("api/admin/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public BlogController(AppDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var query = from b in _context.Blogs
                        join r in _context.Tags
                        on b.Id equals r.Id
                        
                        select
                        new
                        {
                            b.Id,
                            b.Title,
                            b.Desc,
                            b.Image,
                            b.CreatedAt,
                            b.ModifiedAt,
                            r.TagName
                        };

            return Ok(query);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ABlogCreateDto createDto)
        {

            Blog blog = await _context.Blogs.Include(x => x.TagToBlogs).ThenInclude(x => x.Tag).FirstOrDefaultAsync();
             blog = _mapper.Map<Blog>(createDto); 

            if (createDto.ImageFile != null)
            {
                if (!(createDto.ImageFile.ContentType == "image/png" || createDto.ImageFile.ContentType == "image/jpeg" || createDto.ImageFile.ContentType == "image/gif"))
                {

                    return Conflict();
                }

                if (createDto.ImageFile.Length > 2097152)
                {

                    return Conflict();

                }

                string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + createDto.ImageFile.FileName;
                string filePath = Path.Combine(_environment.WebRootPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    createDto.ImageFile.CopyTo(stream);
                }
                blog.Image = fileName;
                fileName = createDto.Image;


            }




            await _context.Blogs.AddAsync(blog);


            await _context.SaveChangesAsync();



            #region ForList

            foreach (var item in createDto.Tags)
            {

                TagToBlog tagToBlog = new TagToBlog();
                tagToBlog.BlogId = blog.Id;
                tagToBlog.TagId = item.Id;

                _context.TagToBlogs.Add(tagToBlog);
            }
            #endregion


            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ABlogCreateDto aCreateDto)
        {

            Blog blog = await _context.Blogs.FirstOrDefaultAsync(x=>x.Id==id);
            List<TagToBlog> oldTag = _context.TagToBlogs.Where(s => s.BlogId == blog.Id).ToList();


            #region  Check404
            if (blog == null)
                return NotFound();
            #endregion

            if (aCreateDto.ImageFile != null)
            {
                if (!(aCreateDto.ImageFile.ContentType == "image/png" || aCreateDto.ImageFile.ContentType == "image/jpeg" || aCreateDto.ImageFile.ContentType == "image/gif"))
                {

                    return Conflict();
                }

                if (aCreateDto.ImageFile.Length > 2097152)
                {

                    return Conflict();

                }

                string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + aCreateDto.ImageFile.FileName;
                string filePath = Path.Combine(_environment.WebRootPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    aCreateDto.ImageFile.CopyTo(stream);
                }
                blog.Image = fileName;
                fileName = aCreateDto.Image;


            }


            blog.ImageFile = aCreateDto.ImageFile;
            blog.Title = aCreateDto.Title;
            blog.Desc = aCreateDto.Desc;
            blog.CreatedAt = aCreateDto.CreatedAt;

            _context.TagToBlogs.RemoveRange(oldTag);



            #region ForList

            foreach (var item in aCreateDto.Tags)
            {

                TagToBlog tagToBlog = new TagToBlog();
                tagToBlog.BlogId = blog.Id;
                tagToBlog.TagId = item.Id;

                _context.TagToBlogs.Add(tagToBlog);
            }
            #endregion


            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
