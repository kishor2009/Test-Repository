using UnityEngine;

public class RopeCutter : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(0)){
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            Debug.Log("Firing Mouse Button 0");

            if(hit.collider != null && hit.collider.tag == "link"){
                hit.collider.gameObject.GetComponent<LineRenderer>().enabled = false;
                hit.collider.transform.parent.gameObject.GetComponent<Rope>().StartCoroutine("StartRopeFading");
                Destroy(hit.collider.gameObject, 0.0f);
            }
        }
	}
}
