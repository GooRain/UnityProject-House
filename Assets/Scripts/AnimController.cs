using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimController : MonoBehaviour {

	public Animator anim;

	public void Animate() {
		if(!anim.GetBool("isOpen")) {
			anim.SetBool("isOpen", true);
		}
		else {
			anim.SetBool("isOpen", false);
		}
	}
}
