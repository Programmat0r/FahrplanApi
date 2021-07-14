using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplan
{
    public class Location
    {

        public String Name { get; private set; }
        public long Lon { get; private set; }
        public long Lat { get; private set; }
        public String Id { get; private set; }


        public Location(String name)
        {
            if (name is null)
                throw new ArgumentNullException("Location name can't be empty");

            this.Name = name;
        }
    }
}
