using System;

public class Sink   
{
    private int xPos;
    private int yPos;
    private int input;

    public int XPos { get { return xPos; } set { xPos = value; } }
    public int YPos { get { return yPos; } set { yPos = value; } }
    public int Input { get { return input; } set { input = value; } }

	public Sink(int xPos_in, int yPos_in)
	{
        this.xPos = xPos_in;
        this.yPos = yPos_in;
	}
}
