using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    [SerializeField] private Transform back;

    [SerializeField] private Transform front;

    public int GetSortingOrder(GameObject obj)
    {
        float objDist = Mathf.Abs(back.position.y - obj.transform.position.y);
        float totalDist = Mathf.Abs(back.position.y - front.position.y);

        return (int)(Mathf.Lerp(System.Int16.MinValue, System.Int16.MaxValue, objDist / totalDist));
    }
    

}
