namespace Fahrplan
{
    using System;

    /// <summary>
    /// Defines the <see cref="Api" />.
    /// </summary>
    public class Api
    {
        /// <summary>
        /// The GetEndpoint.
        /// </summary>
        /// <param name="testMode">The testMode<see cref="bool"/>.</param>
        /// <param name="secure">The secure<see cref="bool"/>.</param>
        /// <returns>The <see cref="String"/>.</returns>
        public static String GetEndpoint(bool testMode, bool secure = true)
        {

            String endpoint = "";

            if (secure)
            {
                endpoint = "https://";
            }
            else
            {
                endpoint = "http://";
            }

            if (testMode)
            {
                return endpoint + "api.deutschebahn.com/freeplan/v1/";
            }
            else
            {
                return endpoint + "api.deutschebahn.com/fahrplan-plus/v1/";
            }
        }
    }
}
