using FluentResults;
using MediatR;
using Streetcode.BLL.Dto.AdditionalContent.Coordinates.Types;

namespace Streetcode.BLL.MediatR.AdditionalContent.Coordinate.Create;

public record CreateCoordinateCommand(PaymentResponseDTO StreetcodeCoordinate) : IRequest<Result<Unit>>;