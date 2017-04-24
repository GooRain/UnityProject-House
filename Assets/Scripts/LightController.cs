using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

	public Light lamp;
	public void Toggle () {
		lamp.enabled = !lamp.enabled;
	}
}
