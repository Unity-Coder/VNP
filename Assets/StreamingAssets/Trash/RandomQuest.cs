using UnityEngine;

public class RandomQuest : MonoBehaviour
{

    // C'est un tableau qui va contenir tes messages.
    private string[] _msgs;

    // Start is called before the first frame update
    void Start()
    {
        // Init de tes messages
        // On va faire simple on va en créer que 3 possibles.

        // Création d'un tableau pouvant contenir 3 chaine de caractères.
        _msgs = new string[3];

        // Initialisation du tableau de chaine de caractères.
        // On initialise les trois messages.
        _msgs[0] = "Je pige rien au C#.";
        _msgs[1] = "Je suis un master en C#.";
        _msgs[2] = "Je préfère picoler que programmer.";

        // En principe ton tableau de string à cette étape est initialisé
        // et contient les 3 messages.
    }

    // Update is called once per frame
    void Update()
    {
        // Si la touche à été pressée et relachée (UP)
        // J'ai considéré la touche Espace ((KeyCode.Space)
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // On récupère un nombre aléatoire entre 0 inclus
            // et l'indice maximum exclus du nombre d'éléments
            // de notre tableau _msgs.
            int indexRandom = Random.Range(0, _msgs.Length);

            // On récupère le messsage indicé par indexRandom.
            string afficheMessage = _msgs[indexRandom];

            // On affiche le message résultant.
            Debug.Log(afficheMessage);
        }
        
    }
}
