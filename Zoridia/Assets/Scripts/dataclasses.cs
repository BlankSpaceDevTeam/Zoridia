using UnityEngine;

[System.Serializable]
public class data {
    bool[] galleryUnlockBools;

    /// <summary> Returns the Gallery Data </summary>
    public bool[] GetGalleryUnlockData() { return galleryUnlockBools; }

    /// <summary> Sets the Gallery Data </summary>
    public void SetGalleryUnlockData(bool[] a) { galleryUnlockBools = a; }

}
