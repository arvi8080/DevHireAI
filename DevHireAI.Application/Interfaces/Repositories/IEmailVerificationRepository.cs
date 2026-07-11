using DevHireAI.Domain.Entities;

namespace DevHireAI.Application.Interfaces.Repositories;

public interface IEmailVerificationRepository
{
    Task AddAsync(EmailVerificationToken token);

    Task<EmailVerificationToken?> GetByTokenAsync(string token);

    Task UpdateAsync(EmailVerificationToken token);
}