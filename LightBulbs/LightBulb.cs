using System.ComponentModel;

namespace LightBulbs
{
	public class LightBulb
	{
		public int Id { get; set; }
		[DefaultValue(false)]
		public bool IsSwitchedOn { get; set; }

		public void SwitchState()
		{
			IsSwitchedOn = IsSwitchedOn != true;
		}

    }
}