namespace ConsoleAnalogClock
{
    public class SecondHand : ClockHand
	{
		public override char DisplayChar => '+';
		
		public SecondHand(double length, double startingRadian, double speed) : base(length, startingRadian, speed) { }
	}
}
