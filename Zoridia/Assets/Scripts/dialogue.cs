using UnityEngine;
using UnityEngine.UI;

public class dialogue : MonoBehaviour
{
    #region variables
    public TextAsset textFile;
    string[] textAssetLines;
    public Image mainImg;
    public Sprite[] characterImgs;
    public Text nameText, textText;
    public int a, b;
    #endregion

    #region methods
    void Start()
    {
        RetrieveInformation();
    }

    void RetrieveInformation()
    {
        textAssetLines = textFile.text.Split('\n');
        b = textAssetLines.Length;
    }

    void Update()
    {
        if (a < b)
        {
            string[] c = textAssetLines[a].Split(':');
            for (int e = 0; e < characterImgs.Length; e++)
            {
                if(characterImgs[e].name == c[0])
                {
                    mainImg.sprite = characterImgs[e];
                }
            }
            nameText.text = c[1];
            textText.text = c[2];
        }
    }

    public void Advance()
    {
        a += 1;
		if (a > b) a = b-1;
    }

    public void BackTrack()
    {
        a -= 1;
    }
    #endregion
}