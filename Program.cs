using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Car KiaCeed = new Car();
BasicCarCheck basic = new BasicCarCheck();
ElectricianCarCheck electric = new ElectricianCarCheck();
MechanicCarCheck mechanic = new MechanicCarCheck();
SpecialistCarCheck specialist = new SpecialistCarCheck();
basic.SetNext(electric);
electric.SetNext(mechanic);
mechanic.SetNext(specialist);
Console.WriteLine("Putting car through all the required checks:");
basic.HandleRequest(KiaCeed);
if (KiaCeed.HasProblem)
{
	Console.WriteLine($"{KiaCeed.Problem}");
}
else
{
	Console.WriteLine("The car is fully functional");
}

public class Car
{
	public bool HasProblem { get; set; }
	public string Problem { get; set; }

}

class BasicCarCheck : CarCheck { }
class ElectricianCarCheck : CarCheck { }
class MechanicCarCheck : CarCheck { }
class SpecialistCarCheck : CarCheck { }

abstract class CarCheck
{
	const int problemIndicator = 3;
	CarCheck Next;
	public void SetNext(CarCheck next)
	{
		Next = next;
	}
	public void HandleRequest(Car car)
	{
		int checkGrade = new Random().Next(1, 10);
		if (checkGrade <= problemIndicator)
		{
			car.HasProblem = true;
			car.Problem = $"{this.GetType().FullName} has found a problem";
		}
		else
		{
			car.HasProblem = false;
			if (Next != null)
			{
				Next.HandleRequest(car);
			}
		}
	}
}