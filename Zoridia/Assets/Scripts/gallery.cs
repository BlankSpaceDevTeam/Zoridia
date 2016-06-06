using UnityEngine;
using UnityEngine.UI;

public class gallery : MonoBehaviour {

    public Image[] galleryUI; 
    bool[] galleryBools;
    Sprite[] images;
    public Sprite lockedImage;

    void Start()
    {
        images = (Sprite[])Resources.LoadAll("gallery");
        galleryBools = saveload.dataFile.GetGalleryUnlockData();
        UpdateGallery();
    }

    void UpdateGallery()
    {
        for (int i = 0; i <= galleryUI.Length; i++)
        {
            if(galleryBools[i])
            {   //unlock
                galleryUI[i].sprite = images[i];
            }
            else
            {   //lock
                galleryUI[i].sprite = lockedImage;
            }
        }
    }
}
