using Microsoft.EntityFrameworkCore;
using Primera_Tarea.DAL;
using Primera_Tarea.Models;
using System.Linq.Expressions;

namespace Primera_Tarea.Services;

public class ProductosService
{
	private readonly Contexto _contexto;

	public ProductosService(Contexto contexto) {
		_contexto = contexto;
	}


	public async Task<bool> Crear(Productos producto) {
		if (!await Existe(producto.ProductoId))
			return await Insertar(producto);
		else
			return await Modificar(producto);
	}

	private async Task<bool> Existe(int productoId) {
		return await _contexto.Productos.AnyAsync(p => p.ProductoId == productoId);
	}

	private async Task<bool> Insertar(Productos producto) {
		_contexto.Productos.Add(producto);
		return await _contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Modificar(Productos producto) {
		_contexto.Update(producto);
		var modificado = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(producto).State = EntityState.Detached;
		return modificado;
	}

	public async Task<bool> Eliminar(Productos producto) {
		return await _contexto.Productos
			.AsNoTracking()
			.Where(p => p.ProductoId == producto.ProductoId)
			.ExecuteDeleteAsync() > 0;
	}

	public async Task<Productos?> BuscarProductoId(int productoId) {
		return await _contexto.Productos
			.AsNoTracking()
			.FirstOrDefaultAsync(p => p.ProductoId == productoId);
	}

	public async Task<List<Productos>> ListarProducto(Expression<Func<Productos, bool>> criterio) {
		return await _contexto.Productos
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}
}
