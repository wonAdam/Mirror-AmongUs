using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField] private List<Image> crewImgs;

    [SerializeField] private List<Button> imposterCountButtons;

    [SerializeField] private List<Button> maxPlayerCountButtons;

    private CreateGameRoomData roomData;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var crewImg in crewImgs)
        {
            Material materialInstance = Instantiate(crewImg.material);
            crewImg.material = materialInstance;
        }

        roomData = new CreateGameRoomData() { imposterCount = 1, maxPlayerCount = 10 };
        UpdateCrewImages();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateImposterCount(int count)
    {
        roomData.imposterCount = count;

        // 임포스터 버튼 Frame Set
        for (int i = 0; i < imposterCountButtons.Count; ++i)
        {
            if (i == count - 1)
            {
                imposterCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                imposterCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }


        int limitMaxPlayer = count == 1 ? 4 : count == 2 ? 7 : 9;
        if(roomData.maxPlayerCount < limitMaxPlayer)
        {
            UpdateMaxPlayerCount(limitMaxPlayer);
        }
        else
        {
            UpdateMaxPlayerCount(roomData.maxPlayerCount);
        }

        // 임포스터 수에 따른 최대 플레이어수 제한
        for(int i = 0; i < maxPlayerCountButtons.Count; ++i)
        {
            var text = maxPlayerCountButtons[i].GetComponentInChildren<Text>();
            if(i < limitMaxPlayer - 4)
            {
                maxPlayerCountButtons[i].interactable = false;
                text.color = Color.gray;
            }
            else
            {
                maxPlayerCountButtons[i].interactable = true;
                text.color = Color.white;
            }
        }

        UpdateCrewImages();
    }

    public void UpdateMaxPlayerCount(int count)
    {
        roomData.maxPlayerCount = count;
        for(int i = 0; i < maxPlayerCountButtons.Count; ++i)
        {
            if(i == count - 4)
            {
                maxPlayerCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                maxPlayerCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }

        UpdateCrewImages();
    }

    private void UpdateCrewImages()
    {
        foreach (var crewImg in crewImgs)
        {
            crewImg.material.SetColor("_PlayerColor", Color.white);
        }

        int imposterCount = roomData.imposterCount;
        int idx = 0;
        while(imposterCount != 0)
        {
            if(idx >= roomData.maxPlayerCount)
            {
                idx = 0;
            }

            if(crewImgs[idx].material.GetColor("_PlayerColor") != Color.red && UnityEngine.Random.Range(0, 5) == 0)
            {
                crewImgs[idx].material.SetColor("_PlayerColor", Color.red);
                imposterCount--;
            }
            idx++;
        }

        for(int i = 0; i < crewImgs.Count; i++)
        {
            if(i < roomData.maxPlayerCount)
            {
                crewImgs[i].gameObject.SetActive(true);
            }
            else
            {
                crewImgs[i].gameObject.SetActive(false);
            }
        }
    }

    public void CreateRoom()
    {
        var manager = AmongUsRoomManager.singleton;
        
        // Room Settings
        //
        //

        manager.StartHost();
    }
    
}

public class CreateGameRoomData
{
    public int imposterCount;
    public int maxPlayerCount;
}
