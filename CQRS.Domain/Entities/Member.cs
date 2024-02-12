using CQRS.Domain.Validation;
using System.Text.Json.Serialization;

namespace CQRS.Domain.Entities;

public sealed class Member : Entity
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Gender { get; private set; }
    public string? Email { get; private set; }
    public bool? IsActive { get; private set; }

    public Member()
    {
    }

    public Member(int id, string firstName, string lastName, string gender, string email, bool? active)
    {
        DomainValidation.When(id < 0, "Invalid id, must be greater than zero");
        ValidateDomain(firstName, lastName, gender, email, active);
    }

    [JsonConstructor]
    public Member(string firstName, string lastName, string gender, string email, bool? active) : base()
    {
        ValidateDomain(firstName, lastName, gender, email, active);
    }

    public void Update(string firstName, string lastName, string gender, string email, bool? active)
    {
        ValidateDomain(firstName, lastName, gender, email, active);
        UpdatedAt = DateTime.Now;
    }

    private void ValidateDomain(string firstname, string lastName, string gender, string email, bool? active)
    {
        DomainValidation.When(string.IsNullOrEmpty(firstname), "First name is required");

        DomainValidation.When(firstname.Length < 3, "First name must be at least 3 characters");

        DomainValidation.When(string.IsNullOrEmpty(lastName), "Last name is required");

        DomainValidation.When(lastName.Length < 3, "Last name must be at least 3 characters");

        DomainValidation.When(email?.Length > 250, "Invalid email, too long, maximum 250 characters");

        DomainValidation.When(email?.Length < 5, "Invalid email, too short, minimum 5 characters");

        DomainValidation.When(string.IsNullOrEmpty(gender), "Invalid email, too short, minimum 6 characters");

        DomainValidation.When(!active.HasValue, "Invalid active, must be true or false");

        FirstName = firstname;
        LastName = lastName;
        Gender = gender;
        Email = email;
        IsActive = active;
    }
}
