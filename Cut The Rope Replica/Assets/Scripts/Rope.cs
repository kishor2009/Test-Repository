using System;
using System.Collections;
using UnityEngine;

public class Rope : MonoBehaviour {

    public Rigidbody2D hook;
    public GameObject linkPrefab;
    public Weight weightBody;
    public int links = 7;
    //public Vector3 [] linkPositions;

	// Use this for initialization
	void Start () {
        GenerateRope();
	}

    private void GenerateRope()
    {
        Rigidbody2D previousRB = hook;
        for (int i = 0; i < links; i++){
            GameObject link = Instantiate(linkPrefab, transform);
            link.GetComponent<HingeJoint2D>().connectedBody = previousRB;

            if(i < (links - 1)){
                previousRB = link.GetComponent<Rigidbody2D>();
            }
            else{
                weightBody.ConnectWeightToEndOfRope(link.GetComponent<Rigidbody2D>());
            }
        }
    }

    public IEnumerator StartRopeFading(){
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < transform.childCount; i++){
            if(transform.GetChild(i).gameObject.GetComponent<LineManager>() != null){
                transform.GetChild(i).gameObject.GetComponent<LineManager>().FadeOutRopeTexture();
                Debug.Log("StartRopeFading Called");
            }
        }

        StopCoroutine("StartRopeFading");
    }
}
