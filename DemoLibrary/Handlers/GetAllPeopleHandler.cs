using Dapper;
using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoLibrary.Handlers
{
    public class GetAllPeopleHandler : IRequestHandler<GetAllPeopleQuery, List<PersonModel>>
    {
        private readonly IDemoDataAccess _dataAccess;

        private readonly IConfiguration _configuration;

        public GetAllPeopleHandler(IDemoDataAccess dataAccess,IConfiguration configuration)
        {
            _dataAccess = dataAccess;
            _configuration = configuration;

        }
        public async Task<List<PersonModel>> Handle(GetAllPeopleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

                var users = await connection.QueryAsync<PersonModel>("Select * from Persons");

                return users.ToList();

                //return Task.FromResult(_dataAccess.GetAllPeople());
            }
            catch (Exception ex) 
            {

                throw;
            }

        }
    }
}
