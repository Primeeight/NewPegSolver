public class ProgramStart
{
    public static void Main(string[] args)
    {
        Program program = new Program();
        program.createTriangle();
        
                program.displayTriangle(program.triMap);
                program.mapTriangle();
                Console.WriteLine(program.checkSolution(program.triMap));
                if (program.move((2, 2), (1, 1)) == (0, 0))
                {
                        Console.WriteLine("move from 2,2 to 1,1 is 0,0");
                }
                else
                {
                        Console.WriteLine("move failed");
                }

    }
 }
