using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float mouseSensitivity = 250f;
	public float speed = 15f;
	public float interactionDistance = 3f;
	public float jumpForce = 1000f;
	RaycastHit rcHit;

	Transform camT;
	float rotY;

	Rigidbody rb;
	bool isCursorLocked = false;

	void Start()
	{
		LockCursor();
		camT = Camera.main.transform;
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		//	Movement
		float movementX = Input.GetAxisRaw("Horizontal");
		float movementZ = Input.GetAxisRaw("Vertical");

		Vector3 moveX = transform.right * movementX;
		Vector3 moveZ = transform.forward * movementZ;

		Vector3 movement = (moveX + moveZ).normalized * speed;

		if (movement != Vector3.zero)
		{
			//Debug.Log("moving");
			rb.MovePosition(rb.position + movement * Time.deltaTime);
		}

		//	Mouse rotation
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity);
		rotY += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
		rotY = Mathf.Clamp(rotY, -80, 80);
		camT.localEulerAngles = Vector3.left * rotY;

		//	Interaction ray
		Vector3 eyePosition = camT.position;
		Debug.DrawRay(eyePosition, camT.transform.forward, Color.red);

		if (Input.GetButtonDown("Fire1"))
		{
			if (Physics.Raycast(eyePosition, camT.transform.forward, out rcHit, interactionDistance))
			{
				
				Debug.Log("Interact");
				if (rcHit.collider.gameObject.GetComponentInParent<AnimController>())
				{
					Debug.Log("Interactable object");
					rcHit.collider.gameObject.GetComponentInParent<AnimController>().Animate();
				}
				if (rcHit.collider.gameObject.GetComponentInParent<LightController>())
				{
					Debug.Log("Interactable object");
					rcHit.collider.gameObject.GetComponentInParent<LightController>().Toggle();
				}
			}
			LockCursor();
		}

		if (Input.GetButtonDown("Jump"))
		{
			rb.AddForce(Vector3.up*jumpForce);
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//SceneManager.GetSceneAt(0);
			UnlockCursor();
			SceneManager.GetSceneByName("menu");
		}
	}

	void LockCursor()
	{
		if (!isCursorLocked)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			isCursorLocked = true;
		}
	}

	void UnlockCursor()
	{
		if (isCursorLocked)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			isCursorLocked = false;
		}
	}
}
