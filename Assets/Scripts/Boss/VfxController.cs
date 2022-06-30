using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxController : MonoBehaviour
{
    public List<GameObject> vfx = new List<GameObject>();
    public float radius = 1.5f;
    public float delayMax = 2f;
    public float delayMin = 0.5f;
    public int numberOfTime = 5;

    private int idx;
    private float timer;
    private float delay;
    private int counter;

    private void OnEnable()
    {
        idx = 0;
        timer = 0f;
        counter = 0;

        foreach(GameObject go in vfx)
        {
            go.GetComponent<Animator>().Rebind();
        }
    }

    //private void Update()
    //{
    //    timer += Time.deltaTime;
    //    if (timer >= delay)
    //    {
    //        delay = Random.Range(delayMin, delayMax);
    //        SetVfx(vfx[idx]);
    //        idx = (idx == vfx.Count - 1)? 0 : idx + 1;
    //        ++counter;

    //        if (numberOfTime == counter)
    //        {
    //            gameObject.SetActive(false);
    //        }
    //    }
    //}

    //public void SetVfx(GameObject go)
    //{
    //    go.transform.position = Random.insideUnitCircle * radius;
    //    go.GetComponent<Animator>().Rebind();
    //    go.SetActive(true);
    //}
}
