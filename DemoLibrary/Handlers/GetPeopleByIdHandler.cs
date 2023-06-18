using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Handlers
{
    public class GetPeopleByIdHandler : IRequestHandler<GetPeopldeByIdQuery, PersonModel>
    {
        private readonly IMediator _mediator;
        public GetPeopleByIdHandler(IMediator mediator) 
        {
            _mediator = mediator;
        }

        public async Task<PersonModel> Handle(GetPeopldeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllPeopleQuery());

            var output = result.FirstOrDefault(x => x.Id == request.Id);

            return output;
            
        }
    }
}
