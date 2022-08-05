public class Food
{
    public int foodx;
    public int foody; //food position
    public int height;
    public int width;
    Random random = new Random(); // zufällige nummer
    public void setfood(Schlange schlange, List<Wand> blocks, int width, int height)
    {
        foodx = random.Next(width); //Grenzel von Random
        foody = random.Next(height);

        while (schlange.schlangekörper.Contains((foodx, foody)) || blocks.Any(block => block.Collide(foodx, foody)))
        {
        foodx = random.Next(width); //Grenzel von Random
        foody = random.Next(height);
        }
        Console.SetCursorPosition(foodx+1, foody+1);//set food position
        Console.Write("ö");//print
    }
}