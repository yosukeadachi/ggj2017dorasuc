using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterFunction : MonoBehaviour
{
	public SuccessCheckerBase checkerObj;

    [Tooltip("objectに物が当たった場合に、このObjを消滅するか")]
    /// <summary>
    /// このobjectに何か物が当たったら、このObjは消滅するかどうか
    /// </summary>
    public bool isDestroy;

    [Tooltip("tagを設定した場合、tagと一致したときのみ当たったことにします。ｓ")]
    /// <summary>
    /// 設定したTagしか反応しなくなります。
    /// </summary>
    public string hitTag = "";

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("hit other Tag: " + other.collider.tag);
        if (hitTag == "" || hitTag == other.collider.tag)
        {
            // ここでHit数をAddしてください
            Debug.Log("hit!");

            //すぐ消えるので、Animetion後に消す場合は消してはいけません。
            if (isDestroy)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit other Tag: " + other.tag);
        if (hitTag == "" || hitTag == other.tag)
        {
            // ここでHit数をAddしてください
            Debug.Log("hit!");
			checkerObj.addCount();
            //すぐ消えるので、Animetion後に消す場合は消してはいけません。
            if (isDestroy)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
