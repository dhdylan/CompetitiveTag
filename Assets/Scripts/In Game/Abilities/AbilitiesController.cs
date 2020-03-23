using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;

public class AbilitiesController : MonoBehaviourPun
{
    public ActiveAbility activeAbility;
    public GameObject taggerGameObject;
    public AbilitiesContainer abilitiesContainer;
    public int amountOfFramesToTag = 4;


    void Start()
    {
        taggerGameObject.SetActive(false);

        if (this.transform.parent.transform.GetComponent<PhotonView>().IsMine)
        {
            AttachToAbiltiesObject.OnAbilityAttachedToAbilitiesObject += SetActiveAbility;
            UserInputController.OnActiveAbilityButtonPressed += ActivateActiveAbility;
            UserInputController.OnTagButtonPressed += Tag;

            InstantiateAbilityObjectsFromContainer();
        }
    }

    private void InstantiateAbilityObjectsFromContainer()
    {
        foreach (GameObject abilityPrefab in abilitiesContainer.abilityPrefabs)
        {
            Debug.Log("Looping through GameObjects in abilitiesContainer.abilityPrefabs on local player : Instantiating " + abilityPrefab.name);
            PhotonNetwork.Instantiate(abilityPrefab.name, Vector3.zero, Quaternion.identity);
        }
    }

    private void SetActiveAbility()
    {
        activeAbility = GetComponentInChildren<ActiveAbility>();
        activeAbility.transform.position = this.transform.position;    // idk why but if i dont dont tell it to reset it's position, it will instantiate at (0, -4.7, 0) or something
        if(activeAbility != null)
        {
            AttachToAbiltiesObject.OnAbilityAttachedToAbilitiesObject -= SetActiveAbility;
        }
    }

    private void ActivateActiveAbility()
    {
        activeAbility.Activate();
    }

    private void Tag()
    {
        StartCoroutine(SetObjectActiveForFrames(taggerGameObject, amountOfFramesToTag));
    }

    public IEnumerator SetObjectActiveForFrames(GameObject objectToSetActive, int frames)
    {
        objectToSetActive.SetActive(true);
        for(int i=0; i<frames; i++)
        {
            yield return null;
        }
        objectToSetActive.SetActive(false);
        yield break;

    }

    private void FindActiveAbility()
    {
        activeAbility = this.gameObject.GetComponentInChildren<ActiveAbility>();
    }

    void OnDestroy()
    {
        UserInputController.OnActiveAbilityButtonPressed -= ActivateActiveAbility;
    }
}
