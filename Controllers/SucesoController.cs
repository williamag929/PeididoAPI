using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class SucesoController : Controller
    {
        private DataSuceso _data;

        private readonly MyOptions _options;

        public SucesoController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }        
        
        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            var constr = _options.constr;

            _data = new DataSuceso(constr);

            var model = _data.GetSucesobyId(id);

            return Json(model);
        }

        [HttpPost]
        public IActionResult SetSuceso([FromBody]  Suceso model)
        {

            if (model == null)
            {
                return BadRequest();
            }

            var constr = _options.constr;

            
            _data = new DataSuceso(constr);

            
            //model = _data.CreateSuceso(model);

            if (model.sucesoid == 0)
            {
                model = _data.CreateSuceso(model);
            }
            //else
            //{
            //    model = _data.u(model);
            //}

            return Json(model);

        }


        
        [HttpDelete]
        public IActionResult DeleteDet(int id)
        {
            var constr = _options.constr;

            _data = new DataSuceso(constr);

            var model = _data.GetSucesobyId(id);

            var del = _data.DeleteSuceso(model);

            return Json(model);
        }

    }
}