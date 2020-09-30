using ConsoleAnalogClock;
using System;
using System.Threading;

namespace ConsoleAnalogClock
{
	public static class Constants
	{ 
		public static int LENGTH = 13;
	}

	public abstract class HandOfClock
	{
		public int length;
		public double degree = 90;
		public double radian = 0;

		public abstract void Rotate();
	}

	public class SecondHand : HandOfClock
	{
		public SecondHand()
		{
			length = Constants.LENGTH - Constants.LENGTH / 5;
		}


        public override void Rotate()
        {
			degree -= 10;
			radian = degree * Math.PI / 180;
			//Clock::IncreaseSeconds();
		}
	}

	public class MinuteHand : HandOfClock
	{
		public MinuteHand()
		{
			length = Constants.LENGTH - Constants.LENGTH / 4 - 3;
		}

        public override void Rotate()
        {
			degree -= 5;
			radian = degree * Math.PI / 180;
			//Clock::IncreaseMinutes();
		}
	}

	public class HourHand : HandOfClock
	{
		public HourHand()
		{
			length = Constants.LENGTH - Constants.LENGTH / 4 - 3;
		}

		public override void Rotate()
		{
			degree -= 1;
			radian = degree * Math.PI / 180;
			//Clock::IncreaseHours();
		}
	}

	public class Clock
	{
		public SecondHand secondHand = new SecondHand();
		public MinuteHand minuteHand = new MinuteHand();
		public HourHand hourHand = new HourHand();

		public void Print()
		{
			Console.WriteLine();

			for (int y = Constants.LENGTH; y >= -Constants.LENGTH; y--)
			{
				Console.Write(" ");

				for (int x = -Constants.LENGTH; x <= Constants.LENGTH; x++)
				{
					double hourHandRadian = hourHand.radian;
					double minuteHandRadian = minuteHand.radian;
					double secondHandRadian = secondHand.radian;

					// Circle
					if (y * y > Constants.LENGTH * Constants.LENGTH - x * x)
						Console.Write("# ");
					// Hour Hand
					else if (y == Math.Round(Math.Tan(hourHandRadian) * x) && x >= 0 && x <= Math.Cos(hourHandRadian) * hourHand.length)
						Console.Write("% ");
					else if (y == Math.Round(Math.Tan(hourHandRadian) * x) && x <= 0 && x >= Math.Cos(hourHandRadian) * hourHand.length)
						Console.Write("% ");

					else if (x == Math.Round(1 / Math.Tan(hourHandRadian) * y) && y >= 0 && y <= Math.Sin(hourHandRadian) * hourHand.length)
						Console.Write("% ");
					else if (x == Math.Round(1 / Math.Tan(hourHandRadian) * y) && y <= 0 && y >= Math.Sin(hourHandRadian) * hourHand.length)
						Console.Write("% ");
					// Minute Hand
					else if (y == Math.Round(Math.Tan(minuteHandRadian) * x) && x >= 0 && x <= Math.Cos(minuteHandRadian) * minuteHand.length)
						Console.Write("$ ");
					else if (y == Math.Round(Math.Tan(minuteHandRadian) * x) && x <= 0 && x >= Math.Cos(minuteHandRadian) * minuteHand.length)
						Console.Write("$ ");

					else if (x == Math.Round(1 / Math.Tan(minuteHandRadian) * y) && y >= 0 && y <= Math.Sin(minuteHandRadian) * minuteHand.length)
						Console.Write("$ ");
					else if (x == Math.Round(1 / Math.Tan(minuteHandRadian) * y) && y <= 0 && y >= Math.Sin(minuteHandRadian) * minuteHand.length)
						Console.Write("$ ");

					// Second Hand
					else if (y == Math.Round(Math.Tan(secondHandRadian) * x) && x >= 0 && x <= Math.Cos(secondHandRadian) * secondHand.length)
						Console.Write("* ");
					else if (y == Math.Round(Math.Tan(secondHandRadian) * x) && x <= 0 && x >= Math.Cos(secondHandRadian) * secondHand.length)
						Console.Write("* ");

					else if (x == Math.Round(1 / Math.Tan(secondHandRadian) * y) && y >= 0 && y <= Math.Sin(secondHandRadian) * secondHand.length)
						Console.Write("* ");
					else if (x == Math.Round(1 / Math.Tan(secondHandRadian) * y) && y <= 0 && y >= Math.Sin(secondHandRadian) * secondHand.length)
						Console.Write("* ");
					// Empty Space
					else
						Console.Write("  ");
				}

				Console.WriteLine();
			}
		}

		public void NewXY()
		{
			// Rotating Hands
			secondHand.Rotate();
			minuteHand.Rotate();
			hourHand.Rotate();
		}
	}
}

class Program
{
    static void Main(string[] args)
    {
		Clock OB = new Clock();

		while (true)
		{
			OB.Print();
			OB.NewXY();

			Thread.Sleep(1000);
			Console.Clear();
		}
	}
}