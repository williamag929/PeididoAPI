using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;
using System;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]

    public class ComprobanteController : Controller
    {
        private readonly MyOptions _options;

        public ComprobanteController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }
    }
}