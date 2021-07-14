namespace Fahrplan
{
    using System;

    /// <summary>
    /// Defines the <see cref="Authentication" />.
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// Gets the TokenBearer.
        /// </summary>
        public String TokenBearer { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Authentication"/> class.
        /// </summary>
        /// <param name="tokenBearer">The tokenBearer<see cref="String"/>.</param>
        public Authentication(String tokenBearer)
        {
            if (tokenBearer is null || tokenBearer == "")
                throw new ArgumentNullException("TokenBearer can't be empty");
            this.TokenBearer = tokenBearer;
        }
    }
}
