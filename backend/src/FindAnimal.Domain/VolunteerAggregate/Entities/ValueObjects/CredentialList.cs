using CSharpFunctionalExtensions;
using FindAnimal.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.VolunteerAggregate.Entities.ValueObjects
{
    public record CredentialList
    {
        private CredentialList() { }
        private CredentialList(IEnumerable<Credential> credentials)
        {
            _credentials = credentials.ToList();
        }


        private List<Credential> _credentials { get; } = [];
        public IReadOnlyList<Credential> CredentialsList => _credentials;
        

        
        public static Result<CredentialList> Create(List<Credential> credentials)
        {
            var credentialList = new CredentialList(credentials);

            return credentialList;
        }
    }
}
