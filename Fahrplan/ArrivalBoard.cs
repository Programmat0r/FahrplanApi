using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplan
{
    class ArrivalBoard : IApiEndpoint<ArrivalBoard[]>
    {
        public String Id { get; private set; }
        public Board[] Boards { get; private set; }

        public Authentication ApiAuthentication => throw new NotImplementedException();

        public ArrivalBoard(String id)
        {
            if (id is null || id == "")
                throw new ArgumentNullException("ArrivalBoard id can't be empty");

            this.Id = id;
        }

        public ArrivalBoard[] Get()
        {
            throw new NotImplementedException();
        }

    
    }

    class Board
    {
        public String Name { get; protected set; }
        public String Type { get; protected set; }
        public String BoardId { get; protected set; }
        public String StopId { get; protected set; }
        public String StopName { get; protected set; }
        public String DateTime { get; protected set; }
        public String Origin { get; protected set; }
        public String Track { get; protected set; }
        public String DetailsId { get; protected set; }


    }

}
