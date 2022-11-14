using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DBModels;
using Model.RequestModel;
using Model.ResponseModel;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Implementing WebAPI on DataBase 
    /// </summary>
    [ApiController]
    [Route("admins")]
    public class AdminsController : ControllerBase
    {
        /// <summary>
        /// DB context object for Request and Response
        /// </summary>
        private readonly OrganizationContext organizationContext;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="organizationContext"></param>
        public AdminsController(OrganizationContext organizationContext)
        {
            this.organizationContext = organizationContext;
        }

        /// <summary>
        /// Fetching all admin details
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<List<AdminDTO>> FetchAdminDetails()
        {
            List<AdminDTO> Admins = await organizationContext.Admins.Select(i => new AdminDTO()
            {
                AdminId = i.AdminId,
                Manager = i.Manager,
                Email = i.Email
            }).ToListAsync();

            return Admins;
        }

        /// <summary>
        /// Adding new admin detail
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        public async Task<Admin> AddAdminDetails(AddAdminRequest addAdminRequest)
        {
            Admin Admin = new Admin()
            {
                AdminName = addAdminRequest.AdminName,
                Manager = addAdminRequest.Manager,
                Email = addAdminRequest.Email
            };

            organizationContext.Admins.Add(Admin);
            await organizationContext.SaveChangesAsync();

            AdminDTO AdminDTO = new AdminDTO()
            {
                AdminId = Admin.AdminId,
                Manager = Admin.Manager,
                Email=Admin.Email
            };
            return Admin;
        }

        /// <summary>
        /// Updating admin detail
        /// </summary>
        /// <param name="AdminDTO">Object to refrence existing object and print output</param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<AdminDTO> UpdateAdminDetails(AdminDTO AdminDTO)
        {
            var existingAdmin = organizationContext.Admins.Where(i => i.AdminId == AdminDTO.AdminId).FirstOrDefault<Admin>();

            if (existingAdmin != null)
            {
                existingAdmin.Manager = AdminDTO.Manager;
                existingAdmin.Email = AdminDTO.Email;

                await organizationContext.SaveChangesAsync();
            }
            else
            {
                return AdminDTO;
            }
            return AdminDTO;
        }

        /// <summary>
        /// Remove intern detail
        /// </summary>
        /// <param name="AdminId"></param>
        /// <returns></returns>
        [HttpDelete()]
        public async Task<string> RemoveAdminDetails(int AdminId)
        {
            var Admin = await organizationContext.Admins.FindAsync(AdminId);

            if (Admin == null)
                return "Admin NOT Found.";

            organizationContext.Admins.Remove(Admin);
            await organizationContext.SaveChangesAsync();

            return "Admin Details Removed.";
        }
    }
}
