using System;
using System.Collections.Generic;
using System.Text;
using Transport.Exceptions;

namespace Transport
{
    class TrainPort : Port
    {
        /// <summary>
        /// A ConcreteProduct
        /// </summary>
        public TrainPort(string name)
        {
            const int MAXIUMUM_NAME_LENGTH = 25;
            const int MINUMUM_NAME_LENGTH = 1;

            if (name.Length > MAXIUMUM_NAME_LENGTH)
            {
                throw new InvalidTrainPortException("Error: Cannot create TrainPort " + name + ", maximum name length is " + MAXIUMUM_NAME_LENGTH + " letters!");
            }
            else if (name.Length < MINUMUM_NAME_LENGTH)
            {
                throw new InvalidTrainPortException("Error: Cannot create TrainPort " + name + ", minumum name length is " + MINUMUM_NAME_LENGTH + " letters!");
            }
            else
            {
                Name = name;
            }
        }
    }
}
