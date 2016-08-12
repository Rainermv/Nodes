using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

	public GameObject selectedLineObject;
	public GameObject parentLineObject;
	
	private List<Node> children = new List<Node>();
	Node parent;
	
	LineRenderer selectedLineRenderer;
	LineRenderer parentLineRenderer;
		
	private int segments = 30;
    private float radius = 0.5f;
	
	// Use this for initialization
	void Start () {
	
		radius = GetComponent<CircleCollider2D>().radius;
		
		//SET SELECTED LINE
		selectedLineRenderer = selectedLineObject.GetComponent<LineRenderer>();
		selectedLineRenderer.SetVertexCount (segments + 1);
		selectedLineRenderer.useWorldSpace = false;
		CreateCirclePoints ();
		
		// SET PARENT LINE
		if (parent != null){
			parentLineRenderer = parentLineObject.GetComponent<LineRenderer>();
			parentLineRenderer.SetVertexCount (2);
						
			parentLineRenderer.SetPosition (0,this.transform.position);
			parentLineRenderer.SetPosition (1,parent.transform.position);
		}
		
		SetSelect(false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void setParent(Node parentNode){
	
		//parent = newParent.GetComponent<Node>();
		parent = parentNode;
		
		//parentLineRenderer.SetPosition (0,this.transform.position);
		//parentLineRenderer.SetPosition (1,parentNode.transform.position);
	
	}
	
	public void addChild(GameObject nodeObject){
	
		Node child = nodeObject.GetComponent<Node>();
		
		if (child != null){
			children.Add(child);
			child.setParent(this);
		}
		
	}
	
	public void addChild(Node node){
		
		children.Add(node);
		
	}
	
	public void SetSelect(bool selected){
		
		selectedLineRenderer.enabled = selected;
	
	}
	
	void CreateCirclePoints ()
    {
        float x;
        float y;
        float z = -0.5f;
       
        float angle = 20f;
       
        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin (Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos (Mathf.Deg2Rad * angle) * radius;
                   
            selectedLineRenderer.SetPosition (i,new Vector3(x,y,z) );
                   
            angle += (370f / segments);
        }
    }
}
