/* dvnlib.UserDisplay.cs
 * u250715_code
 * u250715_documentation
 */

namespace dvnlib.Common
{
    /// <summary>Provides methods for displaying user messages based on the execution context.</summary>
    public class UserDisplay
    {
        /// <summary>
        /// Display a message to the user, either via the console or GUI.
        /// </summary>
        /// <param name="exeAsm">The executing assembly</param>
        /// <param name="message">The message to display</param>
        internal static void Message(string exeAsm, string message)
        {
            switch (exeAsm)
            {
                case "dvn":
                    Console.WriteLine(message);
                    break;

                case "dvngui":
                    break;

                default:
                    break;
            }
        }
    }
}