using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class VeiculoController : ControllerBase
{
    private List<Veiculo> _veiculos = new List<Veiculo>();

    [HttpPost]
    public IActionResult PostVeiculo([FromBody] Veiculo veiculo)
    {
        if (ModelState.IsValid)
        {
            _veiculos.Add(veiculo);
            return CreatedAtAction(nameof(GetVeiculo), new { id = veiculo.IdVeiculo }, veiculo);
        }

        return BadRequest(ModelState);
    }

    [HttpGet("{id}")]
    public IActionResult GetVeiculo(int id)
    {
        var veiculo = _veiculos.FirstOrDefault(v => v.IdVeiculo == id);
        if (veiculo == null)
        {
            return NotFound();
        }

        return Ok(veiculo);
    }

    [HttpGet]
    public IActionResult GetVeiculos()
    {
        return Ok(_veiculos);
    }
}
