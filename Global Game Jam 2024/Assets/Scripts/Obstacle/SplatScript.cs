using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatScript : MonoBehaviour
{
    [SerializeField] float stayTime = 3f;
    [SerializeField] float growTime = 0.2f;
    [SerializeField] float rotateAmount = 45f;

    void Start()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(Vector3.zero, growTime).From())
            .Append(transform.DORotateQuaternion(Quaternion.Euler(0, 0, Random.Range(-rotateAmount, rotateAmount)), growTime))
            .AppendInterval(stayTime)
            .Append(transform.GetComponent<SpriteRenderer>().material.DOFade(0, 2 * growTime))
            .OnComplete(() => { Destroy(gameObject); });
    }
}
