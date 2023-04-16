using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SoundManager : MonoBehaviour
{
    private static S_SoundManager instance;
    public static S_SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<S_SoundManager>();
            }

            return instance;
        }
    } // Sound�� �������ִ� ��ũ��Ʈ�� �ϳ��� �����ؾ��ϰ� instance������Ƽ�� ���� ��𿡼��� �ҷ��������� �̱��� ���

    [SerializeField] AudioSource bgmPlayer;
    [SerializeField] AudioSource sfxPlayer;

    public float masterVolumeSFX = 1f;
    public float masterVolumeBGM = 1f;

    [SerializeField]
    private AudioClip mainBgmAudioClip; //����ȭ�鿡�� ����� BGM
    [SerializeField]
    private AudioClip adventureBgmAudioClip; //��庥�ľ����� ����� BGM
    [SerializeField]
    private AudioClip[] EndBgmAudioClip; //���� ����� BGM

    [SerializeField]
    private AudioClip[] sfxAudioClips; //ȿ������ ����

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        PlayBGMSound();
    }

    // ȿ�� ���� ��� : �̸��� �ʼ� �Ű�����, ������ ������ �Ű������� ����
    public void PlaySFXSound(int ID, float volume = 1f)
    {
        sfxPlayer.PlayOneShot(sfxAudioClips[ID], volume * masterVolumeSFX);
    }

    //BGM ���� ��� : ������ ������ �Ű������� ����
    public void PlayBGMSound(float volume = 1f, int type = 0)
    {
        bgmPlayer.loop = true; //BGM �����̹Ƿ� ��������
        bgmPlayer.volume = volume * masterVolumeBGM;

        if (SceneManager.GetActiveScene().name == "00_MainScene")
        {
            bgmPlayer.clip = mainBgmAudioClip;
            bgmPlayer.Play();
        }
        else if (SceneManager.GetActiveScene().name == "01_GameScene")
        {
            bgmPlayer.clip = adventureBgmAudioClip;
            bgmPlayer.Play();
        }
        else if (SceneManager.GetActiveScene().name == "02_EndScene")
        {
            bgmPlayer.clip = EndBgmAudioClip[type];
            bgmPlayer.Play();
        }
        //���� ���� �´� BGM ���
    }

}
