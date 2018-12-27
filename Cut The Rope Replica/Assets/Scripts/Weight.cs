using UnityEngine;

public class Weight : MonoBehaviour {

    public float hingeAnchorYPos;

    public void ConnectWeightToEndOfRope(Rigidbody2D ERB){
        HingeJoint2D weightHJ = gameObject.AddComponent<HingeJoint2D>();
        weightHJ.autoConfigureConnectedAnchor = false;
        weightHJ.connectedBody = ERB;
        weightHJ.anchor = Vector2.zero;
        weightHJ.connectedAnchor = new Vector2(0.0f, -hingeAnchorYPos);
    }	
}
