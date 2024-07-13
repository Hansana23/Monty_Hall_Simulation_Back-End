using MontyHallSimulationTask.Models;

namespace MontyHallSimulationTask.Services
{
    public interface IMontyHallService
    {
        SimulationResult Simulate(SimulationRequest request);
        void ClearSimulations();
    }
}
