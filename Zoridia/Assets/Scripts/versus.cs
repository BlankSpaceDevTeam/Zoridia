using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class versus : MonoBehaviour {

    public GameObject sideObj, charSelectObj, stageSelectObj;
    public enum versusState {
        SideSelect,
        P1CharSelect,
        P2CharSelect,
        StageSelect
    };
    public versusState scriptState;

    void Update()
    {
        switch(scriptState)
        {
            case versusState.SideSelect:
                GameObjectActivity(true, false, false);
                break;

            case versusState.P1CharSelect:
                GameObjectActivity(false, true, false);
                break;

            case versusState.P2CharSelect:
                GameObjectActivity(false, true, false);
                break;

            case versusState.StageSelect:
                GameObjectActivity(false, false, true);
                break;
        }
    }

    void GameObjectActivity(bool a, bool b, bool c)
    {
        sideObj.SetActive(a);
        charSelectObj.SetActive(b);
        stageSelectObj.SetActive(c);
    }

}
