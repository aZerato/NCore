namespace NCore.Domain.SampleModule.Services
{
    /// <summary>
    /// Sample service.
    /// </summary>
    public class SampleService : ISampleService
    {
        /// <summary>
        /// NCs the ore. domain. sample module. services. IS ample service. is available.
        /// </summary>
        /// <returns><c>true</c>, if ore. domain. sample module. services. IS ample service. is available was NCed, <c>false</c> otherwise.</returns>
        bool ISampleService.IsAvailable()
        {
            return true;
        }
    }
}
