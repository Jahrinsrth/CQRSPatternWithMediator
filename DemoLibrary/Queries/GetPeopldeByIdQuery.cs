using DemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Queries
{
    public class GetPeopldeByIdQuery : IRequest<PersonModel>
    {
        public int Id { get; set; }
        public GetPeopldeByIdQuery(int id) 
        {
            Id = id;
        }

    }
}
