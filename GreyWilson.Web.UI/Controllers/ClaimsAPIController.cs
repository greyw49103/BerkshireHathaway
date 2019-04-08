using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreyWilson.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreyWilson.Web.UI.Controllers
{
    [Route("api/Claims")]
    [ApiController]
    public class ClaimsAPIController : ControllerBase
    {

        private readonly ClaimRepository ClaimRepository;
        public ClaimsAPIController()
        {
            ClaimRepository = new ClaimRepository();
        }


        // GET: api/Claims
        [HttpGet]
        public IEnumerable<Claim> Get()
        {
            return ClaimRepository.GetAll();
        }

        // GET: api/Claims/5
        [HttpGet("{id}", Name = "Get")]
        public Claim Get(int id)
        {
            return ClaimRepository.GetByID(id);
        }

        // POST: api/Claims
        [HttpPost]
        public void Post([FromBody] Claim claim)
        {
            if (ModelState.IsValid)
            {
                ClaimRepository.Create(claim);
            }

        }

        // PUT: api/Claims/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Claim claim)
        {
            claim.ID = id;
            if (ModelState.IsValid)
            {
                ClaimRepository.Update(claim);
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ClaimRepository.Delete(id);
        }


    }
}