using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByKmDrivenLessThan1000QueryHandler: IRequestHandler<GetCarCountByKmDrivenLessThan1000Query, GetCarCountByKmDrivenLessThan1000QueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByKmDrivenLessThan1000QueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByKmDrivenLessThan1000QueryResult> Handle(GetCarCountByKmDrivenLessThan1000Query request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByKmDrivenLessThan1000();
            return new GetCarCountByKmDrivenLessThan1000QueryResult
            {
                CarCountByKmDrivenLessThan1000 = value,
            };
        }
    }
}




