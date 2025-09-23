using GermanCards.Core.Models;
using GermanCards.Data;
using GermanCards.Data.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GermanCards.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardRepository _cardRepo;

    public CardController(ICardRepository cardRepo)
    {
        _cardRepo = cardRepo;
    }

    // GET: api/cards
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Card>>> GetAll(CancellationToken cancellationToken)
    {
        var cards = await _cardRepo.GetAllAsync(cancellationToken);
        return Ok(cards);
    }

    // GET: api/cards/{id}
    [HttpGet("(id:int)")]
    public async Task<ActionResult<Card>> GetById(int id, CancellationToken cancellationToken)
    {
        var card = await _cardRepo.GetByIdAsync(id, cancellationToken);
        if (card is null)
            return NotFound();
        return Ok(card);
    }

    // POST: api/cards
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Card card, CancellationToken cancellationToken)
    {
        if (card is null)
            return BadRequest();
        var created = await _cardRepo.AddAsync(card, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT: api/cards/{id}
    [HttpPut("id:int")]
    public async Task<IActionResult> Update(int id, [FromBody] Card updatedCard, CancellationToken cancellationToken)
    {
        var existing = await _cardRepo.GetByIdAsync(id, cancellationToken);
        if (existing is null)
            return NotFound();

        updatedCard.Id = id;
        await _cardRepo.UpdateAsync(updatedCard, cancellationToken);
        return NoContent();
    }

    // DELETE: api/cards/{id}
    [HttpDelete("id:int")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var existing = await _cardRepo.GetByIdAsync(id, cancellationToken);
        if (existing is null)
            return NotFound();

        await _cardRepo.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}