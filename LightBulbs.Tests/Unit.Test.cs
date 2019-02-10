
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LightBulbs.Tests
{
	[TestFixture]
	public class LightBulbTests
	{
		private static readonly List<LightBulb> LightBulbs = new List<LightBulb>();

		[SetUp]
		public void Setup()
		{
			var current = 1;
			while (current <= 100)
			{
				LightBulbs.Add(new LightBulb {Id = current});
				current++;
			}

		}

		[TearDown]
		public void TearDown()
		{
			LightBulbs.Clear();
		}

		[Test]
		public void Test_All_Bulbs_Initial_State_Is_Off()
		{
			var result = LightBulbs.Where(l => l.IsSwitchedOn);
			Assert.That(result.Count(), Is.EqualTo(0));
		}

		[Test]
		public void Test_First_Person_Will_Turn_On_All_Bulbs()
		{
			const int next = 1;
			var count = 0;

			foreach (var i in Enumerable.Range(1, 100).ToArray())
			{
				var item = LightBulbs.First(l => l.Id == i);
				if (item.Id >= next && item.Id % next == 0)
				{
					item.SwitchState();
					count++;
				}
			}
			Assert.That(count, Is.EqualTo(100));
		}

		[Test]
		public void Test_Second_Person_Will_Switch_State_On_Fifty_Bulbs()
		{
			const int next = 2;
			var count = 0;
			foreach (var i in Enumerable.Range(1, 100).ToArray())
			{
				var item = LightBulbs.First(l => l.Id == i);
				if (item.Id >= next && item.Id % next == 0)
				{
					item.SwitchState();
					count++;
				}
			}

			Assert.That(count, Is.EqualTo(50));
		}

		[Test]

		public void Test_Fifth_Person_Will_Switch_State_On_Twenty_Bulbs()
		{
			const int next = 5;
			var count = 0;

			foreach (var i in Enumerable.Range(1, 100).ToArray())
			{
				var item = LightBulbs.First(l => l.Id == i);
				if (item.Id >= next && item.Id % next == 0)
				{
					item.SwitchState();
					count++;
				}
			}

			var on = LightBulbs.Where(l => l.IsSwitchedOn && l.Id % next== 0);
			Assert.That(count, Is.EqualTo(20));
		}

		[Test]
		public void Test_Thirteenth_Person_Will_Switch_State_On_Seven_Bulbs()
		{
			const int next = 13;
			var count = 0;
			int[] items = new int[7];

			foreach (var i in Enumerable.Range(1, 100).ToArray())
			{
				var item = LightBulbs.First(l => l.Id == i);
				if (item.Id >= next && item.Id % next == 0)
				{
					item.SwitchState();
					items[count] = item.Id;
					count++;
				}
			}

			Assert.That(count, Is.EqualTo(7));
			Assert.That(string.Join(",", items), Is.EqualTo("13,26,39,52,65,78,91"));
		}

		[Test]
		public void Test_Last_Person_Will_Switch_State_On_One_Bulb()
		{
			const int next = 100;
			var count = 0;
			int[] items = new int[1];

			foreach (var i in Enumerable.Range(1, 100).ToArray())
			{
				var item = LightBulbs.First(l => l.Id == i);
				if (item.Id >= next && item.Id % next == 0)
				{
					item.SwitchState();
					items[count] = item.Id;
					count++;
				}
			}

			Assert.That(count, Is.EqualTo(1));
			Assert.That(items.Length, Is.EqualTo(1));
			Assert.That(items[0],Is.EqualTo(100));
		}
		
	}
}
