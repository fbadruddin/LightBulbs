using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightBulbs
{
	public partial class _Default : Page
	{
		private static List<LightBulb> _lightBulbs = new List<LightBulb>();

		protected void Page_Load(object sender, EventArgs e)
		{
				Reset();
				PopulateList();
				ComputeResults();
		}

		private void PopulateList()
		{
			var current = 1;
			if (Cache["bulbs"] == null)
			{
				while(current <=100)
				{
					_lightBulbs.Add(new LightBulb {Id = current});
					current++;
				}
				Cache["bulbs"] = _lightBulbs;
			}
			else
			{
				_lightBulbs = (List<LightBulb>) Cache["bulbs"];
			}
		}



		protected void Compute_Click(object sender, EventArgs e)
		{
			Reset();
			PopulateList();
			ComputeResults();

		}

		private void ComputeResults()
		{
			GenerateTable();
		}

		private void GenerateTable()
		{
			var current = 1; 

			while(current <= 100)
			{
				SwitchBulbState(current);
				current++;
			}

		}

		
		private void Reset()
		{
			Results.Rows.Clear();
			Cache.Remove("bulbs");
			_lightBulbs.Clear();
		}

		private void SwitchBulbState(int next)
		{
			var tr = new TableRow();
			var tc = new TableCell {Text = $"{next}P"};
			tr.Cells.Add(tc);

			foreach (var i in Enumerable.Range(1, 100).ToArray())
			{
				var item = _lightBulbs.First(l => l.Id == i);
				if (item.Id >= next && item.Id % next == 0)
				{
					item.SwitchState();
				}
				tr.Cells.Add(new TableCell { Text =  item.IsSwitchedOn ? $"{i}T" : $"{i}F", BorderStyle = BorderStyle.Solid, BackColor = item.IsSwitchedOn ? Color.Yellow : Color.Red});
			}

			tr.Cells.Add(new TableCell { BorderStyle = BorderStyle.Solid, Text = OnAtThisTime().ToString() });
			Results.Rows.Add(tr);
		}

		private int OnAtThisTime()
		{
			return _lightBulbs.Count(l => l.IsSwitchedOn);
		}
		
	}

	/*
	 *There are 100 light bulbs lined up in a row in a long room. Each bulb has its own switch and is currently switched off. The room has an entry door and an exit door.
	 * There are 100 people lined up outside the entry door. Each bulb is numbered consecutively from 1 to 100. So is each person.
	 * Person No. 1 enters the room, switches on every bulb, and exits.
	 * Person No. 2 enters and flips the switch on every second bulb (turning off bulbs 2, 4, 6, ...).
	 * Person No. 3 enters and flips the switch on every third bulb (changing the state on bulbs 3, 6, 9, ...).
	 * This continues until all 100 people have passed through the room. How many of the light bulbs are illuminated after the 100th person has passed through the room? More specifically, which light bulbs are still illuminated, and why?
	 * */
}