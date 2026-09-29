using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using BuildQuery.Web.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BuildQuery.Web.API
{
    [Route("api/[controller]")]
    public class TfsApiController : Controller
    {
        private IMainModelManager _manager;
        public TfsApiController(IMainModelManager manager)
        {
            _manager = manager;
        }
        // GET: api/values
        [HttpGet]
        public MainModel Get()
        {
            return _manager.MainModel;
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        
    }
}
