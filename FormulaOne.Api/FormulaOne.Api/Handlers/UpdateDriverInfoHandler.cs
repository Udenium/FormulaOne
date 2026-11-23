using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class UpdateDriverInfoHandler : IRequestHandler<UpdateDriverInfoRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateDriverInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateDriverInfoRequest request, CancellationToken cancellationToken)
    {
        var driverUpdate = _mapper.Map<Driver>(request.UpdateRequest);

        await _unitOfWork.Drivers.Update(driverUpdate);
        await _unitOfWork.CompleteAsync();

        return true;
    }
}