using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    public class FindLongestLink
    {
        public static List<ColorChip> FindLongestSequence(ColorChip[] chips)
        {
            List<ColorChip> longestSequence = null;

            foreach (var chip in chips)
            {
                if (chip.StartColor == Color.Blue)
                {
                    List<ColorChip> sequence = FindSequence(chips, new List<ColorChip> { chip }, new HashSet<ColorChip>());
                    if (sequence != null && (longestSequence == null || sequence.Count > longestSequence.Count))
                    {
                        longestSequence = sequence;
                    }
                }
            }

            return longestSequence;
        }

        // Using recursive method to find the sequence of chips
        private static List<ColorChip> FindSequence(ColorChip[] chips, List<ColorChip> currentSequence, HashSet<ColorChip> visited)
        {
            ColorChip lastChip = currentSequence[currentSequence.Count - 1];

            if (lastChip.EndColor == Color.Green)
            {
                return currentSequence;
            }

            List<ColorChip> longestSequence = null;

            foreach (var chip in chips)
            {
                if (!visited.Contains(chip) && chip.StartColor == lastChip.EndColor)
                {
                    visited.Add(chip);
                    List<ColorChip> newSequence = new List<ColorChip>(currentSequence){chip};

                    // Recursively finding the sequence starting from the new chip
                    List<ColorChip> nextSequence = FindSequence(chips, newSequence, new HashSet<ColorChip>(visited));
                    if (nextSequence != null && (longestSequence == null || nextSequence.Count > longestSequence.Count))
                    {
                        longestSequence = nextSequence;
                    }
                }
            }

            return longestSequence;
        }
    }
}