namespace ConsoleAnalogClock
{
    public class HourHand : ClockHand
	{
        public override char DisplayChar => '@';

		public HourHand(double length, double startingRadian, double speed) : base(length, startingRadian, speed) { }
	}
}
