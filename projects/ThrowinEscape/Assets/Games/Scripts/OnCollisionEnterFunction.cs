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
        Debug.Log("hit other Tag: " + other.collider.gameObject.tag);
        if (hitTag == "" || hitTag == other.collider.tag)
        {
            // ここでHit数をAddしてください
            Debug.Log("hit!");

            //すぐ消えるので、Animetion後に消す場合は消してはいけません。
            if (isDestroy)
            {
                // 当たったら音を鳴らしてからdestroyします
                var destroySound = GetComponentInChildren<SoundManager>();
                destroySound.PlaySoundOneShot();
                Destroy(this.gameObject, destroySound.sound.length);
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
                var destroySound = GetComponentInParent<SoundManager>();
                destroySound.PlaySoundOneShot();
                Destroy(this.gameObject);
            }
        }
    }
}
