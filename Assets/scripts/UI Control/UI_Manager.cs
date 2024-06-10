using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public TMP_Text InteractionText;

    private void Start() {
        InteractionText.text = "";
    }
}
