namespace ConsoleAnalogClock
{
    public abstract class ClockHand
	{
		public double Length { get; }
		public double Radian { get; private set; }
		public double Speed { get; }

		public virtual char DisplayChar { get; }

		public ClockHand(double length, double startingRadian, double speed)
        {
			Length = length;
			Radian = startingRadian;
			Speed = speed;
		}

		public virtual void Rotate()
        {
			Radian -= Speed;
		}
	}
}
