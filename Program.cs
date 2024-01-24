using System;
using System.Linq;
using System.Net.Mail;

string[] questions = {
	"Ile nóg ma koń?", 
	"Jak jest GRA po angielsku?", 
	"Jak nazywa się główny bohater gry Wiedźmin?", 
	"W której serii filmów grał Keanu Reeves?",
	"Czy autorka gry zasłużyła na ocenę 5?"
};
string[] answers = {
	"A. 2 \nB. 4 \nC. 6 \nD. 8", 
	"A. Grey \nB. Guy \nC. Game \nD. Gum",
	"A. Geralt \nB. Gerardo \nC. Rzerart \nD. Reginald",
	"A. Piraci z Karaibów \nB. Piła \nC. Matrix \nD. Star Wars",
	"A. Tak \nB. Owszem \nC. Zdecydowanie \nD. Wszystkie odpowiedzi są poprawne"
};
string[]correctAnswers = {"B","C","A","C","D"};
//int[]correctAnswers = { 1, 2, 0, 2, 3,};
int playerPoints = 0;

Console.WriteLine("Witaj, chcesz sprawdzić się w moim Quizie? \nNapisz TAK lub NIE");
string? Answer;
Answer = Console.ReadLine()?.ToUpper();

string[] playerNamesBase = {"Chomiczek", "Kotek", "Piesek", "Konik", "Jeżyk", "Wężyk", "Szczurek", "Wilczek"};

bool userWantsToQuit = false;
if (Answer != "TAK" && Answer != "NIE")
	do
	{
		Console.WriteLine("Nie rozumiem, napisz TAK lub NIE");
		Answer = Console.ReadLine()?.ToUpper();

		if (Answer == "NIE")
		{ 
			userWantsToQuit = true;
			break;
		}

} while (Answer != "TAK");

if(Answer == "NIE"){
	userWantsToQuit = true;
}

if(userWantsToQuit){
	Console.WriteLine("Do widzenia.");
	return;
}

if (Answer == "TAK")
{
	Console.WriteLine("Zanim zaczniemy, podaj swoją nazwę (Jeśli nie podasz, wybiorę jakąś za ciebie):");
	string? playerName = Console.ReadLine()?.ToLower().Trim();

    Random names = new Random();
    int playerNamesBaseIndex = names.Next(playerNamesBase.Length);
    string? baseName = playerNamesBase[playerNamesBaseIndex]; 

    if (string.IsNullOrWhiteSpace(playerName)) {
        Console.WriteLine($"Dobrze, a więc będziesz się nazywać {baseName}. Przygotuj się teraz na kilka trudnych pytań. \nŻeby zacząć, kliknij Enter!");
    }
    else {
	Console.WriteLine($"Dobrze, {playerName}, przygotuj się teraz na kilka trudnych pytań. \nŻeby zacząć, kliknij dowolny przycisk!");
    }
}

Console.ReadKey();

for (int i=0; i< questions.Length; i++)
{
	Console.WriteLine("Pytanie " + (i +1)+ ":");
	Console.WriteLine(questions[i]);
	Console.WriteLine(answers[i]);
	Console.WriteLine("Wybierz odpowiedź A, B, C lub D. \nWpisanie niepoprawnego znaku lub brak udzielenia odpowiedzi skutuje nieotrzymaniem punktu!");
	string? playerAnswer = Console.ReadLine()?.Trim();

	if (CheckAnswer(playerAnswer, correctAnswers[i]))
	{
		playerPoints++;
	}
}

bool CheckAnswer(string answerToCheck, string correctAnswer)
{
	return string.Equals(answerToCheck,correctAnswer, StringComparison.OrdinalIgnoreCase);
}


Console.WriteLine($"Jak myślisz, na ile pytań udało ci się odpowiedzieć poprawnie? \nWpisz cyfrę od 0 do 5 i zobaczymy czy masz rację!");
bool parseScore = int.TryParse(Console.ReadLine(), out int playerScore);
if (!parseScore){
	Console.WriteLine("Rozumiem, że wolisz nie zgadywać.");
}
else if (playerScore > 5) {
	Console.WriteLine("Nie żartuj sobie! Aż tak dobrze nigdy by ci nie poszło.");
}
else if (playerScore > playerPoints) {
    Console.WriteLine("Przykro mi, nie poszło ci aż tak dobrze."); 
}
else if (playerScore == playerPoints) {
    Console.WriteLine("Zgadza się! Udało ci się trafić.");
}
else if (playerScore < playerPoints) {
    Console.WriteLine("Niespodzianka! Poszło ci lepiej niż myślisz.");
}

Console.WriteLine($"Suma twoich punktów wynosi: " + playerPoints + "/" + questions.Length);
Console.WriteLine("Dziękuję za uczestnistwo w quzie!");