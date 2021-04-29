using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCurso.Filter
{
    public class ApiLogginFilter : IActionFilter
    {

        private readonly ILogger<ApiLogginFilter> _logger;

        public ApiLogginFilter(ILogger<ApiLogginFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("***************************");
            _logger.LogInformation("Processo iniciado");
            _logger.LogInformation(DateTime.Now.ToString());
            _logger.LogInformation("***************************");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("***************************");
            _logger.LogInformation("Processo finalizado");
            _logger.LogInformation(DateTime.Now.ToString());
            _logger.LogInformation("***************************");
        }

        
    }
}
