using Microsoft.AspNetCore.Mvc;
using gettingstarted.Services;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace gettingstarted.Controllers {
    
    [Route("api/[controller]")]
    public class GettingStartedController : Controller {

        private readonly IGettingStartedRepo repo;
        private readonly ILogger logger;

        public GettingStartedController(IGettingStartedRepo repo, ILogger<GettingStartedController> logger) {
            this.repo = repo;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get() {
            logger.LogInformation(LoggingEvents.FETCH_ALL, "Call FetchAll");
            return this.repo.FetchAll();
        }

    }

}