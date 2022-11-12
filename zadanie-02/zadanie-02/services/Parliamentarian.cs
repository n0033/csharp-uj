using System;

namespace zadanie_02.services
{

    public class Parliamentarian
    {
        public event EventHandler<bool> Vote;
        public int Number { get; }
        private bool votingOngoing = false;
        private bool voted = false;


        public Parliamentarian(int number)
        {
            Number = number;
        }

        private bool randomBool()
        {
            var random = new Random();
            return random.Next(2) == 0;
        }

        public void SetVotingStatus(object sender, bool status)
        {
            this.votingOngoing = status;
        }

        public void OnVote(object sender, EventArgs e)
        {
            if (votingOngoing && !voted)
            {
                Vote?.Invoke(this, randomBool());
                voted = true;
            }
            else
            {
                Console.WriteLine($"Voting has not yet started or " +
                    $"parliamentarian {Number} has already voted.");
            }
        }
    }
}

