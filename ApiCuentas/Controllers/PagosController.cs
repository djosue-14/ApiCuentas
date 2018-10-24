using ApiCuentas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCuentas.Controllers
{
    [RoutePrefix("api/Pagos")]
    public class PagosController : ApiController
    {
        private PagosRepository repository = new PagosRepository();

        [Route("GetCompras")]
        public IHttpActionResult GetCompras(int id)
        {
            var compras = this.repository.Compras(id);
            if (compras == null)
            {
                return NotFound();
            }

            return Ok(compras);
        }

        [Route("GetMontoCompra")]
        public IHttpActionResult GetMontoCompra(int id)
        {
            var totalCompra = this.repository.MontoCompra(id);

            if (totalCompra == null)
            {
                return NotFound();
            }

            return Ok(totalCompra);
        }

        [Route("GetDetalleCompra")]
        public IHttpActionResult GetDetalleCompra(int id)
        {
            var detalleVenta = this.repository.DetalleCompra(id);

            if (detalleVenta == null)
            {
                return NotFound();
            }

            return Ok(detalleVenta);
        }

        [Route("GetEstadoCuenta")]
        public IHttpActionResult GetEstadoCuenta(int id)
        {
            var pagos = this.repository.EstadoCuenta(id);
            
            
            return Ok(pagos);
        }
    }
}
