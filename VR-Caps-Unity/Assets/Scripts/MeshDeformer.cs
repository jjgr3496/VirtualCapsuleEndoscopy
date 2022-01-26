using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshDeformer : MonoBehaviour {

	//THE REFERENCE LINK https://catlikecoding.com/unity/tutorials/mesh-deformation/


	//Mesh component to access the mesh of the object
	Mesh deformingMesh;
	
	//Storing the original mesh vertices position, and keeping track of the deformed vertices
	Vector3[] originalVertices, displacedVertices;
	
    public float sinAmplitude = 0.005f;
    public float timeStep = 0.05f;
	
	float currentTime = 0f;



    //Vertex normals
    Vector3[] vertexNormals;

	//Store the mesh and its vertices, also makes a copy of the original vertices to the displaced vertices
    void Start () {
		deformingMesh = GetComponent<MeshFilter>().mesh;
		originalVertices = deformingMesh.vertices;
		displacedVertices = new Vector3[originalVertices.Length];
		vertexNormals = deformingMesh.normals;
		for (int i = 0; i < originalVertices.Length; i++){
			displacedVertices[i] = originalVertices[i];
		}
	}

	//This method gets the input variables "point" and "force" from the "MeshDeformerInput" script and applies the given "force" on the given "point"
	//It loops through the displaced vertices and applies the deforming force to each vertex
    public void AddDeformingForce (Vector3 point, float force) {
        return;
	}

	//Since not all vertices are deformed equally, there should be a gradual decrease of the effect on the vertices as they get farther away from the collision point
	//We get the direction and the distance of each vertex from the deforming force
    void AddForceToVertex (int i, Vector3 point, float force) {
    	return;

	}

	//Now that we have a velocity for each vertex, we move them
	//Updating mesh info by assigning the displaced vertices to the mesh, and recalculate normals and update mesh collider
    void Update () {
		for (int i = 0; i < displacedVertices.Length; i++) {
			UpdateVertex(i);
		}
		deformingMesh.vertices = displacedVertices;
		deformingMesh.RecalculateNormals();
		//vertexNormals = deformingMesh.normals;
		currentTime = currentTime + timeStep;
	}

	
	void UpdateVertex (int i) {
		Vector3 normal = vertexNormals[i];
		float magnitude = sinAmplitude * (float)System.Math.Sin(currentTime);
		/*if(magnitude < 0.0f){
			magnitude = 0.0f;
		}*/
		Vector3 displacement = normal * magnitude;
		displacedVertices[i] = originalVertices[i] + displacement;
	}

}