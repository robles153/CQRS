using CQRS.Application.Members.Commands.CreateMember;
using CQRS.Application.Members.Commands.Delete;
using CQRS.Application.Members.Commands.UpdateMember;
using CQRS.Application.Members.Queries.GetAllMembers;
using CQRS.Application.Members.Queries.GetMemberById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly IMediator _mediator;

    public MembersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMember([FromBody] CreateMemberCommand command)
    {
        var createdMember = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetMember), new { id = createdMember.Id }, createdMember);

    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMember(int id, UpdateMemberCommand command)
    {
        try
        {
            command.SetId(id);
            var member = await _mediator.Send(command);
            return Ok(member);

        }
        catch (Exception)
        {
            return NotFound("Member not found");
            throw;
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMember([FromRoute] int id)
    {
        try
        {
            var command = new DeleteMemberCommand();
            command.SetId(id);
            var member = await _mediator.Send(command);
            return Ok(member);

        }
        catch (Exception)
        {

            return NotFound("Member not found");
            throw;
        }


    }

    [HttpGet]
    public async Task<IActionResult> GetMembers()
    {
        try
        {
            var request = new GetMembersQuery();
            var response = await _mediator.Send(request);
            return Ok(response);

        }
        catch (Exception)
        {
            return NotFound("Members not found");

            throw;
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMember([FromRoute] int id)
    {
        try
        {
            var query = new GetMemberByIdQuery();
            query.SetId(id);
            var member = await _mediator.Send(query);
            return Ok(member);
        }
        catch (Exception)
        {
            return NotFound("Member not found");
            throw;
        }

    }

}
