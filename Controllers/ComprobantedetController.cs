using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;
using System;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]

    public class ComprobantedetController : Controller
    {
        private readonly MyOptions _options;

        public ComprobantedetController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }
    }
}