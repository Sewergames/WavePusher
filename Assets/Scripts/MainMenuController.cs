using UnityEngine;

public class MainMenuController : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

		if (viewportPos.x < 0)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, viewportPos.y, viewportPos.z));
        }
        else if (viewportPos.x > 1)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, viewportPos.y, viewportPos.z));
        }
        else if (viewportPos.y < 0)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewportPos.x, 1.0f, viewportPos.z));
        }
        else if (viewportPos.y > 1)
        {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewportPos.x, 0.0f, viewportPos.z));
        }
    }
}
