using MontyHallSimulationTask.Models;

namespace MontyHallSimulationTask.Services
{
    public class MontyHallService : IMontyHallService
    {
        private List<SimulationResult> _simulations = new List<SimulationResult>();

        public SimulationResult Simulate(SimulationRequest request)
        {
            var wins = 0;
            var losses = 0;
            var random = new Random();

            for (int i = 0; i < request.NumberOfGames; i++)
            {
                var carBehindDoor = random.Next(0, 3);
                var playerChoice = random.Next(0, 3);
                var showDoor = Enumerable.Range(0, 3).First(x => x != carBehindDoor && x != playerChoice);
                var newPlayerChoice = request.ChangeDoor
                    ? Enumerable.Range(0, 3).First(x => x != playerChoice && x != showDoor)
                    : playerChoice;

                if (newPlayerChoice == carBehindDoor)
                {
                    wins++;
                }
                else
                {
                    losses++;
                }
            }

            var result = new SimulationResult
            {
                TotalGames = request.NumberOfGames,
                Wins = wins,
                Losses = losses,
                ChangedDoor = request.ChangeDoor
            };

            _simulations.Add(result);
            return result;
        }

        public void ClearSimulations()
        {
            _simulations.Clear();
        }
    }
}
