using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

	public Light lamp;
	public GameObject floor;
	Color newColor = new Color(0, 0, 0);
	public float rate = 2f;
	float counter = 0f;
	bool isChangingColor = false;
	float t = 0;
	float r, g, b;

	private void Update()
	{
		//r += (int)(100 * Time.deltaTime);
		//g += (int)(100 * Time.deltaTime);
		//b += (int)(100 * Time.deltaTime);
		//Debug.Log(r);

		counter -= Time.deltaTime;

		if (counter <= 0 && !isChangingColor)
		{
			newColor = Random.ColorHSV();
			isChangingColor = true;
		}

		lamp.color = LerpRGB(lamp.color, newColor, t);

		if (t < 1)
		{
			t += Time.deltaTime / rate;
			//t = Mathf.Clamp(t, 0, 1);
		}
		else
		{
			counter = 0.1f;
			isChangingColor = false;
			t = 0;
		}
	}
	public void Toggle()
	{
		lamp.enabled = !lamp.enabled;
		// if (floorSwitch)
		//   floor.GetComponent<Renderer>().material.color = Color.white;
		//else
		//    floor.GetComponent<Renderer>().material.color = Color.rg;

		floor.GetComponent<Renderer>().material.color = Random.ColorHSV();
		//floorSwitch = !floorSwitch;
	}

	public Color LerpRGB(Color a, Color b, float t)
	{
		return new Color(
		a.r + (b.r - a.r) * t,
		a.g + (b.g - a.g) * t,
		a.b + (b.b - a.b) * t,
		a.a + (b.a - a.a) * t
	);
	}
}
