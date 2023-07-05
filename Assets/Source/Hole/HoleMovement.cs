using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HoleMovement : MonoBehaviour
{
    [Header("Hole Mesh & Collider")]
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private MeshCollider _meshCollider;

    [Space] [Header("Hole")]
    [SerializeField] Vector2 moveLimits;
    [SerializeField] private float _holeRadius;
    [SerializeField] private Transform _holeCenter;
    [SerializeField] private Transform _magniteCircleCenter;

    [Space]
    [SerializeField] private float moveSpeed;

    private Mesh _mesh;
    private List<int> _holeVertices;
    private List<Vector3> _offsets;
    private int _holeVerticesCount;

    private InputManager _inputManager;
    private MeshUpdater _meshUpdater;

    private void Start()
    {
        Game.IsGameOver = false;
        _inputManager = GetComponent<InputManager>();
        _meshUpdater = GetComponent<MeshUpdater>();
        _meshUpdater.Initialize(_meshFilter, _meshCollider);

        _holeVertices = new List<int>();
        _offsets = new List<Vector3>();

        _mesh = _meshFilter.mesh;

        FindHoleVertices();
        RotateMagniteCircle();
    }

    private void Update()
    {
        if (Game.IsGame){
            bool isMoving = _inputManager.IsMoving();
            if (!Game.IsGameOver && isMoving){
                MoveHole();
                _meshUpdater.UpdateHoleVerticesPosition(_holeVertices, _offsets, _holeCenter.position);
            }
        }
    }

    private void RotateMagniteCircle()
    {
        _magniteCircleCenter.DORotate(new Vector3(90f, 0f, 90f), 0.2f)
            .SetEase(Ease.Linear)
            .From(new Vector3(90f, 0f, 0f))
            .SetLoops(-1, LoopType.Incremental);
    }

    private void MoveHole()
    {
        Vector2 input = _inputManager.GetInput();
        Vector3 touch = CalculateTouchPosition(input);

        Vector3 targetPos = ClampTargetPosition(touch);

        _holeCenter.position = targetPos;
    }

    private Vector3 CalculateTouchPosition(Vector2 input)
    {
        Vector3 touch = Vector3.Lerp(_holeCenter.position, _holeCenter.position + new Vector3(input.x, 0f, input.y), moveSpeed * Time.deltaTime);
        return touch;
    }

    private Vector3 ClampTargetPosition(Vector3 touch)
    {
        Vector3 targetPos = new Vector3(
            Mathf.Clamp(touch.x, -moveLimits.x, moveLimits.x),
            touch.y,
            Mathf.Clamp(touch.z, -moveLimits.y, moveLimits.y)
        );
        return targetPos;
    }

    private void FindHoleVertices()
    {
        for (int i = 0; i < _mesh.vertices.Length; i++){
            float distance = Vector3.Distance(_holeCenter.position, _mesh.vertices[i]);
            if (distance < _holeRadius){
                _holeVertices.Add(i);
                _offsets.Add(_mesh.vertices[i] - _holeCenter.position);
            }
        }
        _holeVerticesCount = _holeVertices.Count;
    }
}