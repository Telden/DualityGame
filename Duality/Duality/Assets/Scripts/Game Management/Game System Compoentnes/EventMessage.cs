using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType { MOEVMENT_EVENT, ATTACK_EVENT, ITEM_EVENT, STAY_EVENT };

public class EventMessage  {


	public EventType myType;

	public EventMessage (EventType type)
	{
		myType = type;
	}

}