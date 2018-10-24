using ApiCuentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCuentas.Repository
{
    public class PagosRepository
    {
        private ApiCuentasEntities db = new ApiCuentasEntities();

        //Devuelve todas las compras asociadas a un cliente particular
        public object Compras(int id)
        {
            var cuentas = from cliente in db.Clientes
                          join venta in db.Ventas on cliente.Id equals venta.ClienteId
                          join tipo_venta in db.TipoVenta on venta.TipoVentaId equals tipo_venta.Id
                          where venta.ClienteId == id
                          select new {
                              cliente.Id,
                              cliente.Nombre,
                              cliente.Apellido,
                              cliente.Telefono,
                              cliente.Direccion,
                              cliente.Sexo,
                              IdVenta = venta.Id,
                              venta.ClienteId,
                              venta.TipoVentaId,
                              venta.FechaVenta,
                              tipo_venta.Descripcion,
                          };

            return cuentas;
        }

        //Devuelve el monto total de la compra.
        public object MontoCompra(int id)
        {
            var montoCompra = from venta in db.Ventas
                              join detalle_venta in db.DetalleVentas on venta.Id equals detalle_venta.VentaId
                              where venta.Id == id
                              select new {
                                  detalle_venta.PrecioUnidad,
                                  detalle_venta.Cantidad
                              };

            return montoCompra.Sum(x => x.Cantidad * x.PrecioUnidad);
        }

        //Devuelve de forma detallada los productos que se compraron por cada compra.
        public object DetalleCompra(int id)
        {
            var detalleVenta = from venta in db.Ventas
                               join detalle_venta in db.DetalleVentas on venta.Id equals detalle_venta.VentaId
                               join producto in db.Productos on detalle_venta.ProductoId equals producto.Id
                               where venta.Id == id
                               select new {
                                   detalle_venta.PrecioUnidad,
                                   detalle_venta.Cantidad,
                                   IdProducto = producto.Id,
                                   producto.Nombre, producto.Marca
                               };

            return detalleVenta;
        }

        //Devuelve de forma detallada el estado de cuenta de la compra(los pagos realizados y pendientes)
        public object EstadoCuenta(int id)
        {
            var pagos = from financiamiento in db.Financiamiento
                        where financiamiento.VentaId == id
                        select new
                        {
                            financiamiento.NumeroCuotas,
                            financiamiento.TasaInteres,
                            financiamiento.MontoInteres,
                            financiamiento.Cuotas
                        };

            return pagos;
        }
    }
}