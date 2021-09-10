using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDespesas.Models.ViewModels;
using GerenciadorDespesas.Data;

namespace GerenciadorDespesas.Models.ViewComponents
{
    public class EstatisticasViewComponent : ViewComponent
    {
        private readonly Context _context;
        public EstatisticasViewComponent(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Estatisticas estatisticas = new Estatisticas();
            estatisticas.MenorDespesa = _context.Despesas.Min(x => x.Valor);
            estatisticas.MaiorDespesa = _context.Despesas.Max(x => x.Valor);
            estatisticas.QuantidadeDespesas = _context.Despesas.Count();

            return View(estatisticas);
        }
    }
}
