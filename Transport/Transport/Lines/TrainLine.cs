using System;
using System.Collections.Generic;
using System.Text;
using Transport.Exceptions;

namespace Transport.Lines
{
    class TrainLine : Line
    {
        const int MINUMUM_NAME_LENGTH = 1;
        const int MAXIUMUM_NAME_LENGTH = 10;
        public TrainLine(string name)
        {
            Name = name;

            if (name.Length > MAXIUMUM_NAME_LENGTH)
            {
                throw new InvalidTrainLineException("Error: Cannot create TrainLine " + name + ", maximum name length is " + MAXIUMUM_NAME_LENGTH + " letters!");
            }
            else if (name.Length < MINUMUM_NAME_LENGTH)
            {
                throw new InvalidTrainLineException("Error: Cannot create TrainLine " + name + ", minumum name length is " + MINUMUM_NAME_LENGTH + " letters!");
            }
            else
            {
                Name = name;
            }
        }
    }
}
