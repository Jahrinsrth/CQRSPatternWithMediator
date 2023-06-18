using Dapper;
using DemoLibrary.Commands;
using DemoLibrary.DataAccess;
using DemoLibrary.Models;
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
    public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonModel>
    {
        private readonly IDemoDataAccess _demoDataAccess;
        private readonly IConfiguration _configuration;

        public InsertPersonHandler(IDemoDataAccess  demoDataAccess, IConfiguration configuration) 
        {
            _demoDataAccess = demoDataAccess;
            _configuration = configuration;
        }
        public async Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));

            var sql = "Insert into Persons (FirstName, LastName) values (@FirstName, @Lastname)";

            var result = await connection.ExecuteAsync(sql, new { FirstName = request.FirstName, LastName = request.LastName });

            if(result > 0) 
            {
                return new PersonModel { FirstName = request.FirstName,LastName = request.LastName };
            }
            else 
            {
                return new PersonModel(){ };
            }


            //return Task.FromResult(_demoDataAccess.InsertPerson(request.FirstName, request.LastName));
        }
    }
}
