using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using NetFighter.Attributes;
using NetFighter.Models;
using NetFighter.Data;

namespace NetFighter.Controllers
{ 
    [ApiController]
    [Authorize]
    public class RequestsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RequestsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/requests")]
        [ValidateModelState]
        [SwaggerOperation("RequestsDelete")]
        public async Task<IActionResult> RequestsDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "url_id")]string urlId, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "method")]string method, [FromQuery (Name = "status")]string status, [FromQuery (Name = "response")]string response, [FromQuery (Name = "info")]string info, [FromQuery (Name = "raw_request")]string rawRequest, [FromHeader (Name = "Prefer")]string prefer)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/requests")]
        [ValidateModelState]
        [SwaggerOperation("RequestsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Requests>), description: "OK")]
        public async Task<IActionResult> RequestsGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "url_id")]string urlId, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "method")]string method, [FromQuery (Name = "status")]string status, [FromQuery (Name = "response")]string response, [FromQuery (Name = "info")]string info, [FromQuery (Name = "raw_request")]string rawRequest, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"raw_request\" : \"raw_request\",\r\n  \"method\" : \"method\",\r\n  \"response\" : \"response\",\r\n  \"created_at\" : \"CURRENT_TIMESTAMP\",\r\n  \"id\" : 0,\r\n  \"url_id\" : 6,\r\n  \"status\" : 1,\r\n  \"info\" : \"info\"\r\n}, {\r\n  \"raw_request\" : \"raw_request\",\r\n  \"method\" : \"method\",\r\n  \"response\" : \"response\",\r\n  \"created_at\" : \"CURRENT_TIMESTAMP\",\r\n  \"id\" : 0,\r\n  \"url_id\" : 6,\r\n  \"status\" : 1,\r\n  \"info\" : \"info\"\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Requests>>(exampleJson)
            : default(List<Requests>);
            return new ObjectResult(example);
        }
        [HttpPatch]
        [Route("/requests")]
        [ValidateModelState]
        [SwaggerOperation("RequestsPatch")]
        public async Task<IActionResult> RequestsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "url_id")]string urlId, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "method")]string method, [FromQuery (Name = "status")]string status, [FromQuery (Name = "response")]string response, [FromQuery (Name = "info")]string info, [FromQuery (Name = "raw_request")]string rawRequest, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Requests requests)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/requests")]
        [ValidateModelState]
        [SwaggerOperation("RequestsPost")]
        public async Task<IActionResult> RequestsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Requests requests)
        {

            throw new NotImplementedException();
        }
    }
}
