using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RitualCharmManager : MonoBehaviour {

	public List<RitualCharmController> ritualCharms;

	public List<RitualCharmController> getRandomCharms(int numberOfCharms){

		ritualCharms.Shuffle ();

		var selected = new List<RitualCharmController>();
		var needed = numberOfCharms;
		var available = ritualCharms.Count;
		var rand = new System.Random();

		while (selected.Count < numberOfCharms) {
			
			if( rand.NextDouble() < needed / available ) {
				selected.Add (ritualCharms [available - 1]);
				needed--;
			}

			available--;

		}

		return selected;

	}
}
