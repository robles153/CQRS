namespace CQRS.Application.Members.Commands.UpdateMember;

public class UpdateMemberCommand : MemberCommandBase
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

}
