using System;

public class Pump
{
    private int capacity;
    private int currentFlow;
    private int xPos;
    private int yPos;

    public int Capacity { get { return capacity; } set { capacity = value; } }
    public int CurrentFlow { get { return currentFlow; } set { currentFlow = value; } }
    public int XPos { get { return xPos; } set { xPos = value; } }
    public int YPos { get { return yPos; } set { yPos = value; } }

	public Pump(int capacity_in, int currentFlow_in, int xPos_in, int yPos_in)
	{
        this.capacity = capacity_in;
        this.currentFlow = currentFlow_in;
        this.xPos = xPos_in;
        this.yPos = yPos_in;
	}
}
