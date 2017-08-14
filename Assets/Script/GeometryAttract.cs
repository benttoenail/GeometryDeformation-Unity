using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometryAttract : MonoBehaviour {

	public GameObject attractor;
	List<Vector3> verts = new List<Vector3>();
	List<Vector3> destination = new List<Vector3>(); 

	int vertexCount;
	MeshFilter _meshfilter;
	Mesh _mesh;



	// Use this for initialization
	void Start () {
		_meshfilter = GetComponent<MeshFilter>();
		_mesh = _meshfilter.mesh;

		vertexCount = _mesh.vertexCount;

		for(int i = 0; i < vertexCount; i++){
			
			verts.Add(_mesh.vertices[i]);
			destination.Add(_mesh.vertices[i]);
		}



		print(verts.Count);
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 goal = attractor.transform.position;

		for(int i = 0; i < vertexCount; i++)
		{
			Vector3 dist = goal - verts[i];
			float mag = dist.magnitude;
			Vector3 go = (goal / mag) + verts[i];

			destination[i] = go;

		}

		_mesh.SetVertices(destination);
		
	}
}
