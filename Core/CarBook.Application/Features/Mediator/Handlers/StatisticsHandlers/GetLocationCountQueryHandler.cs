using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetLocationCountQueryHandler :IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
    {
        private readonly ICarRepository _repository;

        public GetLocationCountQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCount();
            return new GetLocationCountQueryResult
            {
                LocationCount = value
            };
        }
    }
}
