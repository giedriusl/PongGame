using System;
using System.Threading;

namespace PongGame
{
    class GameTable
    {
        private Player _firstPlayer { get; set; }
        private Player _secondPlayer { get; set; }
        private Ball _ball { get; set; }
        private bool _scored = false;
        public GameTable()
        {
            Console.CursorVisible = false;
            _ball = new Ball();
            _firstPlayer = new Player();
            _secondPlayer = new Player(isSecond: true);
            InitDraw();
        }

        public void Start()
        {
            while (_firstPlayer.Points < 5 || _secondPlayer.Points < 5)
            {
                while (!Console.KeyAvailable) { }
                _scored = false;
                while (!_scored)
                {
                    if (!Console.KeyAvailable)
                    {
                        _scored = _ball.Move(_firstPlayer, _secondPlayer);
                        Thread.Sleep(100);
                    } else
                    {
                        _scored = _ball.Move(_firstPlayer,_secondPlayer);
                        PlayerMove();
                        Thread.Sleep(100);
                    }                    
                }

                _ball.Reset();
                _firstPlayer.Reset();
                _secondPlayer.Reset();

            }

        }

        private void InitDraw()
        {
            DrawTable();
            _firstPlayer.Draw();
            _secondPlayer.Draw();
            _ball.Draw();
        }

        public void InitPlayers()
        {
            _firstPlayer = new Player();
            _secondPlayer = new Player(isSecond: true);
        }

        public void DrawTable()
        {
            Console.Clear();
            Console.CursorLeft = 0;
            Console.CursorTop = (int)Borders.Ceiling;
            for (int i = 0; i < 43; i++)
            {
                Console.Write("=");
            }

            Console.CursorLeft = 0;
            Console.CursorTop = (int)Borders.Floor;
            for (int i = 0; i < 43; i++)
            {
                Console.Write("=");
            }
            
        }
        
        public void PlayerMove()
        {
            var key = Console.ReadKey(true).Key.ToString();
            Thread.Sleep(10);

            switch (key)
            {
                case "W":
                    _firstPlayer.Move(Move.Up);
                    break;
                case "S":
                    _firstPlayer.Move(Move.Down);
                    break;
                case "UpArrow":
                    _secondPlayer.Move(Move.Up);
                    break;
                case "DownArrow":
                    _secondPlayer.Move(Move.Down);
                    break;
            }
        }

    }
}

