/* dvnlib.UserDisplay.cs
 * u250708_code
 * u250708_documentation
 */

namespace dvnlib.Common
{
    public class UserDisplay
    {
        internal static void Message(string exeAsm, string message)
        {
            if (exeAsm == "dvn")
            {
                Console.WriteLine(message);
            }
            else if (exeAsm == "dvngui")
            {
               //GUI
            }
            else
            {
                //Do nothing, maybe log?
            }
        }
    }
}
