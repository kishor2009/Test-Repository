using System;
using System.Collections;
using UnityEngine;

public class LineManager : MonoBehaviour {

    public Vector3[] lineRendererPositions;

	// Use this for initialization
	void Start () {
        lineRendererPositions = new Vector3[2];
	}
	
	// Update is called once per frame
	void Update () {
        UpdateLineRendererPositions();
	}

    void UpdateLineRendererPositions(){
        if(gameObject.GetComponent<HingeJoint2D>().connectedBody != null){
            lineRendererPositions[0] = transform.position;
            lineRendererPositions[1] = gameObject.GetComponent<HingeJoint2D>().connectedBody.position;
            gameObject.GetComponent<LineRenderer>().SetPositions(lineRendererPositions);
        }
        else {
            if(gameObject.GetComponent<LineRenderer>().enabled){
                Debug.Log("Disabling Line Renderer");
                gameObject.GetComponent<LineRenderer>().enabled = false;
            }
        }
    }

    public void FadeOutRopeTexture(){
        if(gameObject.GetComponent<LineManager>() != null && gameObject.GetComponent<LineManager>().enabled){
            Debug.Log("FadeOutRopeTexture Called");
            StartCoroutine("GraduallyDecreaseAlpha");
        }
    }

    IEnumerator GraduallyDecreaseAlpha(){
        float alpha = 1.0f;

        LineRenderer line = gameObject.GetComponent<LineRenderer>();
        Color start = line.startColor;
        Color end = line.endColor;

        while (alpha > 0.0f){
            alpha -=  Time.deltaTime * 1.0f;
            start.a = alpha;
            end.a = alpha;
            Debug.Log("Alpha Value: " + alpha);
            line.SetColors(start, end);
            yield return null;
        }

        StopCoroutine("GraduallyDecreaseAlpha");
    }
}
