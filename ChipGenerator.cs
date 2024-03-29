using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class ChipGenerator
    {

        // Generate random chips of given number
        public static ColorChip[] GenerateRandomChips(int numChips)
        {
            Random random = new Random();
            Color[] colors = (Color[])Enum.GetValues(typeof(Color));

            ColorChip[] chips = new ColorChip[numChips];

            for (int i = 0; i < numChips; i++)
            {
                Color startColor = colors[random.Next(colors.Length)];
                Color endColor = colors[random.Next(colors.Length)];

                // Ensuring that start and end colors are not same
                while (startColor == endColor)
                {
                    endColor = colors[random.Next(colors.Length)];
                }

                chips[i] = new ColorChip(startColor, endColor);
            }

            return chips;
        }
    }
}
