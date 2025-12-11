using System.Linq;


// création du tableau 3 fois 3
char[,] plateau = new char[3, 3]
{
    { ' ', ' ', ' ' },
    { ' ', ' ', ' ' },
    { ' ', ' ', ' ' }
};


char joueur = 'X'; // le joueur qui commence

for (int tour = 0; tour < 9; tour++)
{
    AfficherPlateau(plateau);
    Console.WriteLine("Au tour du joueur "+joueur);

    int l, c;

    
    while (true)
    {
        (l, c) = SaisirCoup();

        if (plateau[l, c] == ' ')
        {
            plateau[l, c] = joueur;

            break;
        }
        else
        {
            Console.WriteLine("Cette case est déjà occupée !");
        }
    }
    if (JoueurGagne(plateau, joueur))
    {
        AfficherPlateau(plateau);
        Console.WriteLine("Le joueur "+ joueur +" a gagné !");
        break;
    }
    // Changer de joueur
    joueur = (joueur == 'X') ? 'O' : 'X';
}


Console.WriteLine("Fin de la partie !");







// methode affichage plateau 
void AfficherPlateau(char[,] p)
{
    Console.Clear();

    for (int i = 0; i < 3; i++)
    {
        // Ligne du contenu
        Console.Write(" ");
        for (int j = 0; j < 3; j++)
        {
            Console.Write(" " + p[i, j] + " ");
            if (j < 2)
                Console.Write("|");
        }
        Console.WriteLine();

        // Ligne des séparateurs
        if (i < 2)
        {
            Console.Write(" ---+---+---");
            Console.WriteLine();
        }
    }
}



//fonction saisir une valeur
(int ligne, int colonne) SaisirCoup()
{
    int ligne;
    int colonne;

    while (true)
    {
        Console.Write("Entre une ligne (0-2) : ");
        string? inputLigne = Console.ReadLine();

        Console.Write("Entre une colonne (0-2) : ");
        string? inputColonne = Console.ReadLine();

        bool okLigne = int.TryParse(inputLigne, out ligne);
        bool okColonne = int.TryParse(inputColonne, out colonne);


        if (okLigne && okColonne &&
        ligne >= 0 && ligne <= 2 &&
        colonne >= 0 && colonne <= 2)

        {
            break; 
        }
        Console.WriteLine("Saisie invalide, réessaie !");
        Console.WriteLine();
    }     

    return (ligne, colonne);
}


bool JoueurGagne(char[,]plateau, char joueur)
{
    bool ligneGagnante = Enumerable.Range(0, 3)
        .Any(i => Enumerable.Range(0, 3)
        .All(j=> plateau[i,j]== joueur));

    bool colonneGagnante = Enumerable.Range(0, 3)
    .Any(j => Enumerable.Range(0, 3)
    .All(i => plateau[i, j] == joueur));

    bool diag1 = Enumerable.Range(0, 3)
        .All(i => plateau[i, i] == joueur);

    bool diag2 = Enumerable.Range(0, 3)
        .All(i => plateau[i, 2 - i] == joueur);

    return (ligneGagnante || colonneGagnante || diag1 || diag2);

}

