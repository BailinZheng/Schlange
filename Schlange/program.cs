using System.IO;
StreamWriter sw = new StreamWriter(@"C:\Users\bailin.zheng\Documents\Schlangen-Partitur.txt", true);

var schlange = new Schlange();
var food = new Food();

Console.WriteLine("Wie hoch willst du der Size sein ?");
string input = Console.ReadLine();
schlange.WindowHeight = int.Parse(input);
if (InputCheck.CheckHeight(schlange) == false) {
    Console.WriteLine("Der Anzahl des WindowHeight ist zu groß oder zu klein");
    return;
}

Console.WriteLine("Wie breit willst du der Size sein ?");
input = Console.ReadLine();
    
schlange.WindowWidth = int.Parse(input);
if (InputCheck.CheckWidth(schlange) == false)
{
    Console.WriteLine("Der Anzahl des WindowWidth ist zu groß oder zu klein");
    return;
}
Console.WriteLine("Wie viele Blöcke willst du haben?");

input = Console.ReadLine();

if (InputCheck.IsInt(input) == false)
{
    Console.WriteLine("falsch Eingabe");
    return;
}

int blöcke = int.Parse(input);
if (InputCheck.CheckBlock(schlange,blöcke) == false)
{
    Console.WriteLine("Der Anzahl des Blocks ist zu groß oder zu klein");
    return;
}

schlange.nameplayer = "anonymous"; 
Console.WriteLine("Wer bist du?");
schlange.nameplayer = Console.ReadLine();

Console.Clear();

int refreshRate = 170; //das Bildschirmaktualisierungsintervall

var blocks = Wand.GetBlocks(schlange.WindowHeight, schlange.WindowWidth, blöcke, 3);

blocks.ForEach(block => block.draw());

Console.CursorVisible = false;//ausblenden des Cursors

//draw wall
Console.SetCursorPosition(0, 0);

var horizontaleKante = new String('-', schlange.WindowWidth + 3);
Console.WriteLine(horizontaleKante);

for (int j = 0; j < schlange.WindowHeight; j++)
{
    Console.SetCursorPosition(0, j+1);
    Console.Write("|");

    Console.SetCursorPosition(schlange.WindowWidth+2, j + 1);
    Console.Write("|");
}

Console.WriteLine();
Console.WriteLine(horizontaleKante);

food.setfood(schlange, blocks , schlange.WindowWidth, schlange.WindowHeight);
while (true)
{
    while (Console.KeyAvailable == false)   //wenn mann nicht auf die Tastatur drückt
    {
        if (schlange.kx == food.foodx && schlange.ky == food.foody) //wenn food und schlange treffen
        {
            if(schlange.schlangekörper.Count == schlange.WindowWidth * schlange.WindowHeight)
            {
                Console.SetCursorPosition(0, schlange.WindowHeight + 2);
                Console.Write("Nice, you are the winner!");
            }
            schlange.Eat();
            food.setfood(schlange, blocks , schlange.WindowWidth, schlange.WindowHeight);
        }
        Thread.Sleep(refreshRate);

        if (!schlange.Move(blocks))
        {
            Console.SetCursorPosition(0, schlange.WindowHeight + 2);
            Console.Write("Game Over");
            Console.SetCursorPosition(0, schlange.WindowHeight + 3);
            Console.Write("Liebe " + (schlange.nameplayer ) + " Your score is " + (schlange.schlangekörper.Count - 1).ToString());
            sw.WriteLine((schlange.nameplayer) + "'s score is " + (schlange.schlangekörper.Count - 1).ToString());
            sw.Close();
            return;
        }
    }
    char ch = Console.ReadKey(true).KeyChar; //check der Tastatur input
    schlange.turn(ch);
}
System.IO.StreamReader st;
st = new System.IO.StreamReader(@"C:\Users\bailin.zheng\Documents\Schlangen-Partitur.txt", System.Text.Encoding.UTF8);
public enum Directions
{
    Left = 0,
    Right = 1,
    Up = 2,
    Down = 3,
}