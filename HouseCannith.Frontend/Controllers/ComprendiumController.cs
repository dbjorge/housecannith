using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HouseCannith.Data;
using HouseCannith.Data.Models;

namespace HouseCannith_Frontend.Controllers
{
    [Route("api/comprendium/")]
    public class ComprendiumController : Controller
    {
        private readonly ComprendiumDbContext _comprendiumDb;

        public ComprendiumController(ComprendiumDbContext comprendiumDb) {
            _comprendiumDb = comprendiumDb;
        }

        [HttpGet("classes")]
        public IEnumerable<Class> GetClasses()
        {
            return _comprendiumDb.Class.ToList();
        }
    }
}
