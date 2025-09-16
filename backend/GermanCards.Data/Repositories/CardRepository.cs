using GermanCards.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GermanCards.Data.Repositories;

public class CardRepository : ICardRepository
{
    private readonly AppContext _context;
    public CardRepository(AppContext context)
    {
        _context = context;
    }
    public async Task<Card> AddAsync(Card card, CancellationToken cancellationToken = default)
    {
        await _context.Cards.AddAsync(card, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return card;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var card = await _context.Cards.FindAsync(new object[]{ id }, cancellationToken);
        if (card is null) return;
        _context.Cards.Remove(card);
        await _context.SaveChangesAsync(cancellationToken);
        
    }

    public async Task<IEnumerable<Card>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Cards
                             .AsNoTracking()
                             .ToListAsync(cancellationToken);
    }

    public async Task<Card?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Cards
                             .AsNoTracking()
                             .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task UpdateAsync(Card card, CancellationToken cancellationToken = default)
    {
        _context.Cards.Update(card);
        await _context.SaveChangesAsync(cancellationToken);  
    }
}