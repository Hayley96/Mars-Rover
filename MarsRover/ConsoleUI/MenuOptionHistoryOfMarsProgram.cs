using static System.Console;
public static class MenuOptionHistoryOfMarsProgram
{
    public static void DisplayAboutInfo()
    {
        Clear();
        var prevForeColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine(@"A Mars rover is a motor vehicle designed to travel on the surface of Mars. 
Rovers have several advantages over stationary landers: they examine more territory, 
they can be directed to interesting features, they can place themselves in sunny 
positions to weather winter months, and they can advance the knowledge of how to perform 
very remote robotic vehicle control. 

They serve a different purpose than orbital spacecraft like Mars Reconnaissance Orbiter. 
A more recent development is the Mars helicopter.

As of May 2021, there have been six successful robotically operated Mars rovers; the first five, 
managed by the American NASA Jet Propulsion Laboratory, were (by date of Mars landing): 
Sojourner (1997–1997), Opportunity (2004–2018), Spirit (2004–2010), Curiosity (2012–), 
and Perseverance (2021–). The sixth, managed by the China National Space Administration, 
is Zhurong (2021–).

On January 24, 2016, NASA reported that then current studies on Mars by Opportunity and Curiosity 
would be searching for evidence of ancient life, including a biosphere based on autotrophic, 
chemotrophic or chemolithoautotrophic microorganisms, as well as ancient water, including fluvio-lacustrine
environments (plains related to ancient rivers or lakes) that may have been habitable. 
The search for evidence of habitability, taphonomy (related to fossils), and organic 
carbon on Mars is now a primary NASA objective -- Source: Wikipedia");
        ForegroundColor = prevForeColor;
    }
}