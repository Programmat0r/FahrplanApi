using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplan
{
   public class TrainLocs
    {
        [JsonConstructor]
        public TrainLocs(string stopId, string stopName, string lat, string lon, string arrTime, string depTime, string train, string type, string @operator, Note[] notes)
        {
            StopId = stopId ?? throw new ArgumentNullException(nameof(stopId));
            StopName = stopName ?? throw new ArgumentNullException(nameof(stopName));
            Lat = lat ?? throw new ArgumentNullException(nameof(lat));
            Lon = lon ?? throw new ArgumentNullException(nameof(lon));
            ArrTime = arrTime;
            DepTime = depTime;
            Train = train ?? throw new ArgumentNullException(nameof(train));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Operator = @operator ?? throw new ArgumentNullException(nameof(@operator));
            Notes = notes ?? throw new ArgumentNullException(nameof(notes));
        }

        public String StopId { get; private set; }
        public String StopName { get; private set; }
        public String Lat { get; private set; }
        public String Lon { get; private set; }
        public String ArrTime { get; private set; }
        public String DepTime { get; private set; }
        public String Train { get; private set; }
        public String Type { get; private set; }
        public String Operator { get; private set; }
        public Note[] Notes { get; private set; }

    }
    public class Note
    {
        [JsonConstructor]
        public Note(string key, string priority, string text)
        {
            this.Key = key ?? throw new ArgumentNullException(nameof(key));
            this.Priority = priority ?? throw new ArgumentNullException(nameof(priority));
            this.Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public String Key { get; private set; }
        public String Priority { get; private set; }
        public String Text { get; private set; }

    }
}
