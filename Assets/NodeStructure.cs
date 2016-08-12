using UnityEngine;
using System.Collections;

public enum NodeStructureType {

	Castle, Barracks, Mill, Farm

}

public static class NodeStructureFactory{

	public static NodeStructure GetStructure(NodeStructureType type){

		int size = 0;

		switch (type) {

		case NodeStructureType.Barracks:
			size = 5;
			break;

		}

		return new NodeStructure(size);

	}

}

public class NodeStructure {

	int size = 0;

	public NodeStructure(int size){

	}
}
