using System;
using System.Threading;

namespace ConsoleAnalogClock
{
	class Program
	{
		static void Main(string[] args)
		{
			Clock clock = new Clock(13);

			while (true)
			{
				clock.Print();
				clock.Tick();

				Thread.Sleep(1000);
				Console.Clear();
			}
		}
	}
}