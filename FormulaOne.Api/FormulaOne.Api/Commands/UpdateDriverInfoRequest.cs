using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Commands;

public class UpdateDriverInfoRequest : IRequest<bool>
{
    public UpdateDriverInfoRequest(UpdateDriverRequest updateRequest)
    {
        UpdateRequest = updateRequest;
    }

    public UpdateDriverRequest UpdateRequest { get; }
    
    
    
}