using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject prefabNode;
	
	private Camera cameraReference;
	
	//private GameObject selectedObject;
	
	public GameObject SelectedObject{ get; set; }
	
	private static PlayerController _instance;
	
	public static PlayerController Instance { get {return _instance; } }
	
	void Awake(){
		
		if (_instance != null && _instance != this){
			Destroy(this.gameObject);
		}
		else{
			_instance = this;
		}

		cameraReference = GetComponent<Camera>();
	}

	// Use this for initialization
	void Start () {
	

		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown(0)){
		
			LeftClick();
		}
		
	}
	
	void FixedUpdate(){
	
		
	}
	
	private void Select(GameObject newSelected){
		
		if (SelectedObject != null){
			SelectedObject.SendMessage("SetSelect",false);
		}
		
		newSelected.SendMessage("SetSelect",true);
		
		SelectedObject = newSelected;
	
	}
	
	private void instantiateNode(Node parent, Vector2 position){
		
		GameObject node = (GameObject)Instantiate(prefabNode, position, Quaternion.identity);
		parent.addChild(node);
		
	}
	
	private void LeftClick(){
		
		Vector2 worldMousePosition = cameraReference.ScreenToWorldPoint(Input.mousePosition);
			
			Collider2D[] clickedColliders = Physics2D.OverlapPointAll(worldMousePosition);
				
				foreach (Collider2D clickedCollider in clickedColliders){
				
					if (clickedCollider.gameObject.tag == "NodeObject"){
					
						//this.SelectedObject = clickedCollider.gameObject;
						Select(clickedCollider.gameObject);
						return;
					}
					
				}
			
			if (SelectedObject != null){
				
				Node selectedNode = SelectedObject.GetComponent<Node>();
				
				if (selectedNode != null){
					
					instantiateNode(selectedNode, worldMousePosition);
				
				}
			
			}
	
	}
	
	
	

}
