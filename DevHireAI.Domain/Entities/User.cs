using DevHireAI.Domain.Common;
using DevHireAI.Domain.Enums;

namespace DevHireAI.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public UserRole Role { get; set; } = UserRole.Candidate;

    public bool EmailVerified { get; set; }

    public bool IsActive { get; set; } = true;
}