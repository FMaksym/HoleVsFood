using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshUpdater : MonoBehaviour
{
    private MeshFilter _meshFilter;
    private MeshCollider _meshCollider;

    public void Initialize(MeshFilter meshFilter, MeshCollider meshCollider)
    {
        _meshFilter = meshFilter;
        _meshCollider = meshCollider;
    }

    public void UpdateHoleVerticesPosition(List<int> holeVertices, List<Vector3> offsets, Vector3 holeCenterPosition)
    {
        Mesh mesh = _meshFilter.mesh;
        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < holeVertices.Count; i++)
        {
            vertices[holeVertices[i]] = holeCenterPosition + offsets[i];
        }

        mesh.vertices = vertices;
        _meshFilter.mesh = mesh;
        _meshCollider.sharedMesh = mesh;
    }
}
