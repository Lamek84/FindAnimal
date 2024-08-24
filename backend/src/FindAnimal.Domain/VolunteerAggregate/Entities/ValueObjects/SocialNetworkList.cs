using CSharpFunctionalExtensions;
using FindAnimal.Domain.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.VolunteerAggregate.Entities.ValueObjects
{
    public record SocialNetworkList
    {
        private SocialNetworkList() { }

        private SocialNetworkList(IEnumerable<SocialNetwork> networkList)
        {
            _snetworkList = (List<SocialNetwork>)networkList;
        }


        private List<SocialNetwork> _snetworkList { get; } = [];
        public IReadOnlyList<SocialNetwork> NetworksList => _snetworkList;


        public static Result<SocialNetworkList> Create(IEnumerable<SocialNetwork> networkList)
        {
            var socialNetworkList = new SocialNetworkList(networkList);

            return socialNetworkList;
        }
    }
}
