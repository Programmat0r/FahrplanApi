using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplan
{
    public class Board
    {
        [JsonConstructor]
        public Board(string name, string type, string boardId, string stopId, string stopName, string dateTime, string origin, string track, string detailsId)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            BoardId = boardId ?? throw new ArgumentNullException(nameof(boardId));
            StopId = stopId ?? throw new ArgumentNullException(nameof(stopId));
            StopName = stopName ?? throw new ArgumentNullException(nameof(stopName));
            DateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
            Origin = origin;
            Track = track ?? throw new ArgumentNullException(nameof(track));
            DetailsId = detailsId ?? throw new ArgumentNullException(nameof(detailsId));
        }

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
