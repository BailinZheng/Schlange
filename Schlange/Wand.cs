﻿public class Wand
{
    public Wand(int size, int X, int Y)
    {
        this.position = (X, Y);
        this.size = size;
    }
    (int X, int Y) position;
    int size;
    public void draw()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.SetCursorPosition(position.X + 1 + i, position.Y + 1 + j);
                Console.Write("!");
            }
        }
    }
    internal bool Collide(int x, int y)
    {
        if (x >= position.X && x < position.X + size && y >= position.Y && y < position.Y + size)
        {
            return true;
        }
        return false;
    }
    public static List<Wand> GetBlocks(int height, int width, int maxBlocks, int maxSize)
    {
        List<Wand> blocks = new List<Wand>();

        Random random = new Random();
        int block_count = random.Next(maxBlocks);

        for (int i = 0; i < block_count; i++)
        {
            int x = random.Next(width);
            int y = random.Next(height);
            while (blocks.Any(block => block.position == (x, y)))
            {
                x = random.Next(width);
                y = random.Next(height);
            }
            int size =random.Next(new int[] {maxSize, height-y, width-x}.Min());
            blocks.Add(new Wand(size, x, y));
        }
        return blocks;
    }
}


