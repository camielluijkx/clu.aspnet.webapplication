using clu.aspnet.webapplication.mvc.core.api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.core.api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public IEnumerable<Customer> Get()
        {
            // Fill content here
            return new List<Customer>();
        }

        public void Post(Customer item)
        {
            // Fill content here
        }

        public void Put(int id, Customer item)
        {
            // Fill content here
        }

        public void Delete(int id)
        {
            // Fill content here    
        }
    }
}