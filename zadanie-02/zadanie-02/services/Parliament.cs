using System;


namespace zadanie_02.services
{
    public class Parliament
    {

        public event EventHandler<bool> VotingStarted;
        public event EventHandler<bool> VotingEnded;
        private string topic { get; }
        private int ParliamentarianAmount { get; }
        public Parliamentarian[] parliamentarians;
        private int forCount = 0;
        private int againstCount = 0;


        public Parliament(int parliamentarianAmount, string topic)
        {
            this.topic = topic;
            ParliamentarianAmount = parliamentarianAmount;
            parliamentarians = new Parliamentarian[parliamentarianAmount];

            for (int i = 0; i < this.ParliamentarianAmount; i++)
            {
                Parliamentarian parliamentarian = new Parliamentarian(i);
                parliamentarians[i] = parliamentarian;
                parliamentarian.Vote += this.AddVote;
                this.VotingStarted += parliamentarian.SetVotingStatus;
                this.VotingEnded += parliamentarian.SetVotingStatus;
            }


        }

        public void AddVote(object sender, bool vote)
        {
            if (vote)
            {
                this.forCount += 1;
            }
            else
            {
                this.againstCount += 1;
            }
        }

        public void StartVoting()
        {
            VotingStarted?.Invoke(this, true);
        }

        public void StopVoting()
        {
            VotingStarted?.Invoke(this, false);
            PrintResult();
        }

        public void PrintResult()
        {
            Console.WriteLine($"Voting about: {this.topic}, parliamentarians for: {this.forCount}, parliamentarians against: {this.againstCount}");
        }


    }
}

