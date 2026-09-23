using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gerenciador central de áudio. Qualquer script chama
/// AudioManager.Instance?.PlaySFX(SfxId.Jump) pra tocar um efeito sonoro,
/// sem precisar ter um AudioSource próprio nem se preocupar com posição.
///
/// Setup no Unity:
/// - Criar um GameObject vazio na cena do Menu Principal (primeira cena
///   carregada), chamado "AudioManager", e adicionar este script a ele.
///   Ele usa DontDestroyOnLoad, então persiste pras outras cenas sozinho —
///   só precisa existir uma vez, na primeira cena.
/// - Preencher a lista "Sounds" no Inspector: cada entrada tem um Name
///   (use exatamente os valores de SfxId, ex: "Jump", "Coin") e o AudioClip
///   correspondente.
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume = 1f;
    }

    [Header("Efeitos sonoros (nome deve bater com SfxId)")]
    public Sound[] sounds;

    [Header("Música de fundo (opcional)")]
    public AudioClip musicClip;
    [Range(0f, 1f)] public float musicVolume = 0.5f;

    private AudioSource sfxSource;
    private AudioSource musicSource;
    private Dictionary<string, Sound> soundDict;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        sfxSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;

        soundDict = new Dictionary<string, Sound>();
        foreach (Sound s in sounds)
        {
            if (s != null && !string.IsNullOrEmpty(s.name) && !soundDict.ContainsKey(s.name))
            {
                soundDict.Add(s.name, s);
            }
        }

        if (musicClip != null)
        {
            musicSource.clip = musicClip;
            musicSource.volume = musicVolume;
            musicSource.Play();
        }
    }

    public void PlaySFX(string soundName)
    {
        if (soundDict.TryGetValue(soundName, out Sound sound) && sound.clip != null)
        {
            sfxSource.PlayOneShot(sound.clip, sound.volume);
        }
        else
        {
            Debug.LogWarning($"AudioManager: som '{soundName}' não configurado.");
        }
    }
}
