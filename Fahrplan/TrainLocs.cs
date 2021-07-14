namespace Fahrplan
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Defines the <see cref="TrainLocs" />.
    /// </summary>
    public class TrainLocs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrainLocs"/> class.
        /// </summary>
        /// <param name="stopId">The stopId<see cref="string"/>.</param>
        /// <param name="stopName">The stopName<see cref="string"/>.</param>
        /// <param name="lat">The lat<see cref="string"/>.</param>
        /// <param name="lon">The lon<see cref="string"/>.</param>
        /// <param name="arrTime">The arrTime<see cref="string"/>.</param>
        /// <param name="depTime">The depTime<see cref="string"/>.</param>
        /// <param name="train">The train<see cref="string"/>.</param>
        /// <param name="type">The type<see cref="string"/>.</param>
        /// <param name="@operator">The operator<see cref="string"/>.</param>
        /// <param name="notes">The notes<see cref="Note[]"/>.</param>
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

        /// <summary>
        /// Gets the StopId.
        /// </summary>
        public String StopId { get; private set; }

        /// <summary>
        /// Gets the StopName.
        /// </summary>
        public String StopName { get; private set; }

        /// <summary>
        /// Gets the Lat.
        /// </summary>
        public String Lat { get; private set; }

        /// <summary>
        /// Gets the Lon.
        /// </summary>
        public String Lon { get; private set; }

        /// <summary>
        /// Gets the ArrTime.
        /// </summary>
        public String ArrTime { get; private set; }

        /// <summary>
        /// Gets the DepTime.
        /// </summary>
        public String DepTime { get; private set; }

        /// <summary>
        /// Gets the Train.
        /// </summary>
        public String Train { get; private set; }

        /// <summary>
        /// Gets the Type.
        /// </summary>
        public String Type { get; private set; }

        /// <summary>
        /// Gets the Operator.
        /// </summary>
        public String Operator { get; private set; }

        /// <summary>
        /// Gets the Notes.
        /// </summary>
        public Note[] Notes { get; private set; }
    }

    /// <summary>
    /// Defines the <see cref="Note" />.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class.
        /// </summary>
        /// <param name="key">The key<see cref="string"/>.</param>
        /// <param name="priority">The priority<see cref="string"/>.</param>
        /// <param name="text">The text<see cref="string"/>.</param>
        [JsonConstructor]
        public Note(string key, string priority, string text)
        {
            this.Key = key ?? throw new ArgumentNullException(nameof(key));
            this.Priority = priority ?? throw new ArgumentNullException(nameof(priority));
            this.Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// Gets the Key.
        /// </summary>
        public String Key { get; private set; }

        /// <summary>
        /// Gets the Priority.
        /// </summary>
        public String Priority { get; private set; }

        /// <summary>
        /// Gets the Text.
        /// </summary>
        public String Text { get; private set; }
    }
}
