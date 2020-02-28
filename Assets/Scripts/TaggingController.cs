using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaggingController : MonoBehaviour
{
    public Tagger tagger;
    public GameObject taggerGameObject;

    void Start()
    {
        tagger = GetComponentInChildren<Tagger>();
        taggerGameObject = tagger.gameObject;
    }
}
