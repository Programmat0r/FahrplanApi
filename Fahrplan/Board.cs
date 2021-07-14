namespace Fahrplan
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Defines the <see cref="Board" />.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <param name="type">The type<see cref="string"/>.</param>
        /// <param name="boardId">The boardId<see cref="string"/>.</param>
        /// <param name="stopId">The stopId<see cref="string"/>.</param>
        /// <param name="stopName">The stopName<see cref="string"/>.</param>
        /// <param name="dateTime">The dateTime<see cref="string"/>.</param>
        /// <param name="origin">The origin<see cref="string"/>.</param>
        /// <param name="track">The track<see cref="string"/>.</param>
        /// <param name="detailsId">The detailsId<see cref="string"/>.</param>
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

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public String Name { get; protected set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public String Type { get; protected set; }

        /// <summary>
        /// Gets or sets the BoardId.
        /// </summary>
        public String BoardId { get; protected set; }

        /// <summary>
        /// Gets or sets the StopId.
        /// </summary>
        public String StopId { get; protected set; }

        /// <summary>
        /// Gets or sets the StopName.
        /// </summary>
        public String StopName { get; protected set; }

        /// <summary>
        /// Gets or sets the DateTime.
        /// </summary>
        public String DateTime { get; protected set; }

        /// <summary>
        /// Gets or sets the Origin.
        /// </summary>
        public String Origin { get; protected set; }

        /// <summary>
        /// Gets or sets the Track.
        /// </summary>
        public String Track { get; protected set; }

        /// <summary>
        /// Gets or sets the DetailsId.
        /// </summary>
        public String DetailsId { get; protected set; }
    }
}
