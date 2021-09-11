using UnityEngine;

public class GenerateSlantedGrid : MonoBehaviour
{
    [SerializeField] private Vector2Int _gridSizing;
    [SerializeField] private float _spacingH;
    [SerializeField] private float _spacingV;

    private void OnDrawGizmosSelected()
    {
        for (int j = 0; j < _gridSizing.y; j++)
        {
            for (int i = 0; i < _gridSizing.x; i++)
            {
                Vector3 position = new Vector3(i * _spacingH + j%2 * _spacingV/2, j * _spacingV, 0.0f);
                Gizmos.DrawCube(position, Vector3.one);
            }
        }
    }
}