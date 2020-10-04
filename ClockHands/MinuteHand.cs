namespace ConsoleAnalogClock
{
    public class MinuteHand : ClockHand
	{
		public override char DisplayChar => '#';

		public MinuteHand(double length, double startingRadian, double speed) : base(length, startingRadian, speed) { }
	}
}
