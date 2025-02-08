using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppv2.Data;
using ppv2.Models;
using System;


namespace ppv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TagController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(template: "List")]
        public IActionResult ListTag()
        {
            var allTags = dbContext.Tags.ToList();

            return Ok(allTags);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetTagById(int id)
        {
            var tag = dbContext.Tags.Find(id);

            if (tag == null) { return NotFound(); }

            return Ok(tag);
        }

        [HttpPost]
        public IActionResult AddTag(TagDto tagDto)
        {
            var TagEntity = new Tag()
            {
                TagName = tagDto.TagName,
            };


            dbContext.Tags.Add(TagEntity);
            dbContext.SaveChanges();

            return Ok(TagEntity);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult UpdateTag(int id, TagDto tagDto)
        {
            var tag = dbContext.Tags.Find(id);
            if (tag == null) { return NotFound(); };
            tag.TagName = tagDto.TagName;


            dbContext.SaveChanges();

            return Ok(tag);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteTag(int id)
        {
            var tag = dbContext.Tags.Find(id);
            if (tag == null) { return NotFound(); };

            dbContext.Tags.Remove(tag);
            dbContext.SaveChanges();
            return Ok(tag);
        }
    }
}
