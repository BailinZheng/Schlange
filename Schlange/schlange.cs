using System.Collections.Generic;//using system class

public class Schlange
{
    public Directions Current_Dir = Directions.Right;
    public int WindowWidth { get; set; }
    public int WindowHeight { get; set; }
    public string nameplayer { get; set; }

    public Dictionary<Directions, (int XDir, int YDir)> DirectionsToMovement = new()
    {
        { Directions.Right, (1, 0) },
        { Directions.Left, (-1, 0) },
        { Directions.Up, (0, -1) },
        { Directions.Down, (0, 1) }
    };
 
    public int kx => schlangekörper[0].X;//gib zahl zum List
    public int ky => schlangekörper[0].Y;

    private bool turned = false;
    public bool Move(List<Wand> blocks)
    {
        var x = kx;
        x += DirectionsToMovement[Current_Dir].XDir;//die Werte addieren
        var y = ky;
        y += DirectionsToMovement[Current_Dir].YDir;

        if (x < 0)//Wenn die Schlange das WindowSizeLimit überschreitet
        {
            x = WindowWidth - 1;//Subtrahieren Sie eins vom Maximalwidthwert,Dadurch kann es vom unteren Bildschirmrand aus angezeigt werden.
        }
        if (x > WindowWidth - 1)
        {
            x = 0;
        }
        if (y < 0)
        {
            y = WindowHeight -1;
        }
        if (y > WindowHeight - 1)
        {
            y = 0;
        }

        return Move1(x, y, blocks);
    }
    private bool eating; //bewerten, ob die Schlange das Food getroffen hat
    public void Eat()
    {
        eating = true;
    }

    public List<(int X, int Y)> schlangekörper = new List<(int, int)>() { (5, 5) };//set list

    private bool Move1(int x, int y, List<Wand> blocks)
    {
        Console.SetCursorPosition(kx+1, ky+1);
        Console.Write("#");

        if (!eating)
        {
            var schlangenende = schlangekörper[schlangekörper.Count - 1];
            Console.SetCursorPosition(schlangenende.X+1, schlangenende.Y+1);
            Console.Write(" ");
            schlangekörper.RemoveAt(schlangekörper.Count - 1); //Entfernen den falschen Schlangenkörper, subtrahieren Sie 1 von der Anzahl der Einsen in der Liste
        }

        foreach (var item in schlangekörper)
        {
            if (item.X == x && item.Y == y)
            {
                return false;
            }
        }

        if(blocks.Any(block => block.Collide(x, y)))
        {
            return false;
        }

        schlangekörper.Insert(0, (x, y)); //schlangeköper position
        Console.SetCursorPosition(x+1, y+1);
        Console.Write("X");

        eating = false;
        turned = false;
        return true;
    }
    public void turn(char ch)
    {
        Directions new_Dir = Current_Dir;

        switch (ch)
        {
            case 'a':
                new_Dir = Directions.Left;
                break;
            case 's':
                new_Dir = Directions.Down;
                break;
            case 'w':
                new_Dir = Directions.Up;
                break;
            case 'd':
                new_Dir = Directions.Right;
                break;
        }//control die Schlange
        var opposite_Dir = Current_Dir switch
        {
            Directions.Left => Directions.Right,
            Directions.Right => Directions.Left,
            Directions.Up => Directions.Down,
            Directions.Down => Directions.Up,
        };
        if (new_Dir != Current_Dir && new_Dir != opposite_Dir && !turned)
        {
            Current_Dir = new_Dir;
            turned = true;
        }
    }
}
