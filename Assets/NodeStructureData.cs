using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "StructureData", menuName = "Game/Structure", order = 1)]
public class NodeStructureData : ScriptableObject {

	public string typeName;
	public float radius;
	public Color color = Color.white;
}
