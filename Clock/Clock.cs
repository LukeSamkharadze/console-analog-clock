using System;
using System.Collections.Generic;

namespace ConsoleAnalogClock
{
    public class Clock
	{
		public int Length { get; }
		public List<ClockHand> ClockHands { get; } = new List<ClockHand>();

		public Clock(int length)
        {
			Length = length;

			ClockHands.Add(new HourHand(length - 8, Math.PI/2, Math.PI/180));
			ClockHands.Add(new MinuteHand(length - 5, Math.PI / 2, Math.PI / 100));
			ClockHands.Add(new SecondHand(length - 2, Math.PI / 2, Math.PI / 20));
		}

		public void Print()
		{
			Console.WriteLine();

			for (int y = Length; y >= -Length; y--)
			{
				for (int x = -Length; x <= Length; x++)
					if (y * y > Length * Length - x * x)
						Console.Write("##");
					else
					{
						bool canDraw = true;
						Action<char> draw = new Action<char>(o => { canDraw = false; Console.Write(o + " "); });

						for(int clockHand=0; clockHand < ClockHands.Count && canDraw; clockHand++)
							if (y == Math.Round(Math.Tan(ClockHands[clockHand].Radian) * x) && x >= 0 && x <= Math.Cos(ClockHands[clockHand].Radian) * ClockHands[clockHand].Length)
								draw(ClockHands[clockHand].DisplayChar);
							else if (y == Math.Round(Math.Tan(ClockHands[clockHand].Radian) * x) && x <= 0 && x >= Math.Cos(ClockHands[clockHand].Radian) * ClockHands[clockHand].Length)
								draw(ClockHands[clockHand].DisplayChar);
							else if (x == Math.Round(1 / Math.Tan(ClockHands[clockHand].Radian) * y) && y >= 0 && y <= Math.Sin(ClockHands[clockHand].Radian) * ClockHands[clockHand].Length)
								draw(ClockHands[clockHand].DisplayChar);
							else if (x == Math.Round(1 / Math.Tan(ClockHands[clockHand].Radian) * y) && y <= 0 && y >= Math.Sin(ClockHands[clockHand].Radian) * ClockHands[clockHand].Length)
								draw(ClockHands[clockHand].DisplayChar);

						if (canDraw)
							Console.Write("  ");
					}

				Console.WriteLine();
			}
		}

		public void Tick()
		{
			ClockHands.ForEach(o => o.Rotate());
		}
	}
}
