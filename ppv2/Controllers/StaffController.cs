using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppv2.Data;
using ppv2.Models;
using System;

namespace ppv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public StaffController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(template:"List")]
        public IActionResult ListStaff()
        {
            var allStaff = dbContext.Staffs.ToList();

            return Ok(allStaff);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStaffById(int id) {
            var staff = dbContext.Staffs.Find(id);

            if (staff == null) { return NotFound(); }

            return Ok(staff);
        }

        [HttpPost]
        public IActionResult AddStaff(StaffDto staffDto)
        {
            var StaffEntity = new Staff()
            {
                StaffName = staffDto.StaffName,
            };


            dbContext.Staffs.Add(StaffEntity);
            dbContext.SaveChanges();

            return Ok(StaffEntity);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult UpdateStaff(int id, StaffDto staffDto)
        {
            var staff = dbContext.Staffs.Find(id);
            if (staff == null) { return NotFound(); };
            staff.StaffName = staffDto.StaffName;

            dbContext.SaveChanges();

            return Ok(staff);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteStaff(int id)
        {
            var staff = dbContext.Staffs.Find(id); 
            if (staff == null) { return NotFound(); };

            dbContext.Staffs.Remove(staff);
            dbContext.SaveChanges();
            return Ok(staff);
        }
    }
}
