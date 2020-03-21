using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Frame
    {
        int score;

        public int Score
        {
            get { return score; }
        }

        public void add(int pins)
        {
            score += pins;
        }

    }

    public class Game
    {
        int score;
        private int[] throws = new int[21];
        private int currentThrow;
        private int currentFrame = 1;
        private bool isFristThrow = true;


        public int Score
        {
            get { return ScoreForFrame(currentFrame - 1); }
        }

        //public int ScoreForCurrentFrame
        //{
        //  get{ return 1; }
        //}

        public int CurrentFrame
        {
            get { return currentFrame; }
        }

        public void add(int pins)
        {
            throws[currentThrow++] = pins;
            score += pins;

            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (isFristThrow)
            {
                if (pins == 10)
                    currentFrame++;

                isFristThrow = false;
            }
            else
            {
                isFristThrow = true;
                currentFrame++;
            }

            if (currentFrame > 10)
                currentFrame = 10;
        }

        //public int ScoreForFrame(int frame)
        //{
        //    int score = 0;
        //    for (int ball = 0; 
        //        frame > 0 && ball < CurrentThrow;
        //        ball+=2, frame--)
        //    {
        //        score += throws[ball] + throws[ball + 1];
        //    }
        //    return score;
        //}


        public int ScoreForFrame(int theFrame)
        {
            int score = 0;
            int ball = 0;

            for (int currentFrame = 0;
                currentFrame < theFrame;
                currentFrame++)
            {
                int firstThrow = throws[ball++];
                int secondThrow = throws[ball++];
                int frameScore = firstThrow + secondThrow;

                if (firstThrow == 10)
                    frameScore += throws[ball] + throws[++ball];

                else if (frameScore == 10)
                    frameScore += throws[ball];
                
                score += frameScore;
            }
            return score;
        }


    }
}
