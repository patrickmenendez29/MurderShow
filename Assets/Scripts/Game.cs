using System;


    public class Game
    {
        public string name;
        public int score;
        public Difficulty difficulty;

        public enum Difficulty
        {
            EASY, MEDIUM, HARD
        }

        public int level;

        public Game(string name, int score, Difficulty difficulty)
        {
            this.name = name;
            this.score = score;
            this.difficulty = difficulty;

        }

        
    }





