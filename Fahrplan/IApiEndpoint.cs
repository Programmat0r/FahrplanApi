namespace Fahrplan
{
    /// <summary>
    /// Defines the <see cref="IApiEndpoint{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    interface IApiEndpoint<T> where T : class
    {
        /// <summary>
        /// Gets the ApiAuthentication.
        /// </summary>
        Authentication ApiAuthentication { get; }

        /// <summary>
        /// Gets or sets a value indicating whether TestMode.
        /// </summary>
        bool TestMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SecureConnection.
        /// </summary>
        bool SecureConnection { get; set; }

        /// <summary>
        /// The Get.
        /// </summary>
        /// <returns>The <see cref="T"/>.</returns>
        T Get();
    }
}
