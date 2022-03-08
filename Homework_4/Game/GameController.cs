using Game.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game
{
    class GameController
    {
        private List<string> roundResults = new List<string>();
        private TextBlock resultsTextBlock;
        private List<int> maxValuePlayers = new List<int>();
        public int Winner { get; set; }

        public GameController()
        {
        }
        public void StartGame(int numPlayers, int numDices)
        {
            List<int> resultPlayers = new List<int>(); 
            bool needtoRender = true;
            int maxValue = 1;
            int round = 1;
            List<int> playersIndeces = Enumerable.Range(0, numPlayers).ToList();
            do
            {
                Console.Clear();
                resultPlayers = ThrowDices(playersIndeces, numDices, round);
                resultsTextBlock.Render();
                maxValue = resultPlayers.Max();
                foreach (int i in playersIndeces)
                {
                    if (resultPlayers[i] == maxValue)
                    {
                        maxValuePlayers.Add(i);
                    }
                }
                if (maxValuePlayers.Count() == 1)
                {
                    Winner = maxValuePlayers[0];
                    needtoRender = false;
                }
                else
                {
                    playersIndeces.Clear();
                    foreach(int j in maxValuePlayers){
                        playersIndeces.Add(j);
                    }
                    resultPlayers.Clear();
                    round++;
                }
                maxValuePlayers.Clear();
                Thread.Sleep(3000);
            } while (needtoRender);
        }


        private List<int> ThrowDices(List<int> playersIndeces, int numDices, int round)
        {
            Random rnd = new Random();
            List<int> resultPlayers = new List<int>();
            int numPlayers = playersIndeces.Count();
            roundResults.Add($"Round: {round}!");

            for (int player = 0; player < numPlayers; player++)
            {
                List<int> resultDices = new List<int>();
                string tmp_result = $"Player {player}: ";
                for (int i = 0; i < numDices; i++)
                {
                    int diceResult = rnd.Next(1, 6);
                    resultDices.Add(diceResult);
                    tmp_result = tmp_result + $"D{i}: {diceResult}; ";
                }

                tmp_result = tmp_result + $"Sum: {resultDices.Sum()}; ";
                resultPlayers.Add(resultDices.Sum());
                roundResults.Add(tmp_result);
            }
            resultsTextBlock = new TextBlock(5, 5, 50, roundResults);
            roundResults.Clear();
            return resultPlayers;
        }

    }
}
