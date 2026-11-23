using MediatR;

namespace FormulaOne.Api.Commands;

public class DeleteDriverInfoRequest : IRequest<bool>
{
    public DeleteDriverInfoRequest(Guid driverId)
    {
        DriverId = driverId;
    }

    public Guid DriverId { get; }
}