using System;
using System.Collections.Generic;
using System.Text;
using atmframework_swtgrp9;

namespace ATM.Core
{
    public class ConsoleLogger : ILog
    {
        private int _clsnListSize = 0;
        private int _airspaceListSize = 0;
        private int _currentConsoleWidth;

        private readonly int _stringLength = 50;
        private readonly int _collisionLenght = 50;

        public ConsoleLogger()
        {
        }

        public void Log(LOGTYPE type, List<string> logMessages)
        {
            switch(type)
            {
                case LOGTYPE.AIRSPACE:
                    PrintAirspace(logMessages);

                    break;

                case LOGTYPE.COLLISIONS:
                    PrintCollisions(logMessages);

                    break;

                case LOGTYPE.CLEAR:
                    Clear();

                    break;

                default:
                    break;
            }
        }

        private void PrintAirspace(List<string> logMessages)
        {
            WidthChangeCheck();
            if (_airspaceListSize != logMessages.Count)
            {
                ClearAirspace(logMessages);
            }

            for (int i = 0; i < logMessages.Count; i++)
            {
                Console.SetCursorPosition(0, i);
                ClearLine(i, _stringLength);
                Console.SetCursorPosition(0, i);
                Console.Write(logMessages[i]);
            }
        }

        private void PrintCollisions(List<string> messages)
        {
            WidthChangeCheck();
            if (_clsnListSize != messages.Count)
            {
                ClearCollisions(messages);
            }

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkRed;

            for (int i = 0; i < messages.Count; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - messages[i].Length > 0 ? Console.WindowWidth - messages[i].Length : 0, i);
                Console.Write(messages[i]);
            }

            Console.ResetColor();
        }


        private void ClearCollisions(List<string> collisions)
        {
            for (int i = 0; _clsnListSize > i; ++i)
            {
                Console.SetCursorPosition((Console.WindowWidth - _collisionLenght), i);
                for (int k = 0; _collisionLenght > k; ++k)
                {
                    Console.Write(" ");
                }
            }
            _clsnListSize = collisions.Count;
        }

        private void ClearAirspace(List<string> messages)
        {
            Console.SetCursorPosition(0, _airspaceListSize);
            for (int j = 0; _airspaceListSize > j; ++j)
            {
                ClearLine(j, _stringLength);
            }
            _airspaceListSize = messages.Count;
        }

        private void ClearLine(int index, int length)
        {
            Console.SetCursorPosition(0, index);
            for (int i = 0; length > i; ++i)
            {
                Console.Write(" ");
            }
        }
        internal void WidthChangeCheck()
        {
            if (_currentConsoleWidth != Console.WindowWidth)
            {
                Console.Clear();
                _currentConsoleWidth = Console.WindowWidth;
            }
        }
        }

    }
}
 