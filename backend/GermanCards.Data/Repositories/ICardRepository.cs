using GermanCards.Core.Models;

namespace GermanCards.Data.Repositories;

public interface ICardRepository
{
        Task<IEnumerable<Card>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Card?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Card> AddAsync(Card card, CancellationToken cancellationToken = default);
        Task UpdateAsync(Card card, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}