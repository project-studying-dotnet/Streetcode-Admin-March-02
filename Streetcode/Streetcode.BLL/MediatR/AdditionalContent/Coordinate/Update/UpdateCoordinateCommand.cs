using FluentResults;
using MediatR;
using Streetcode.BLL.Dto.AdditionalContent.Coordinates.Types;

namespace Streetcode.BLL.MediatR.AdditionalContent.Coordinate.Update;

public record UpdateCoordinateCommand(PaymentResponseDTO StreetcodeCoordinate) : IRequest<Result<Unit>>;