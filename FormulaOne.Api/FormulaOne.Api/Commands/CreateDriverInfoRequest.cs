using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Commands;

public class CreateDriverInfoRequest : IRequest<GetDriverResponse>
{
    public CreateDriverInfoRequest(CreateDriverRequest driverRequest)
    {
        DriverRequest = driverRequest;
    }

    public CreateDriverRequest DriverRequest { get; }
}