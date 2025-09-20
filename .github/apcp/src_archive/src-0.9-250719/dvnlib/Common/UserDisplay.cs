/* dvnlib.UserDisplay.cs
 * u250719_code
 * u250719_documentation
 */

namespace dvnlib.Common
{
    /// <summary>Provides methods for displaying user messages based on the execution context.</summary>
    public class UserDisplay
    {
        /// <summary>Display a message to the user, either via the console or GUI.</summary>
        /// <param name="exeAsmName">The executing assembly</param>
        /// <param name="message">The message to display</param>
        internal static void Message(string exeAsmName, string message)
        {
            switch (exeAsmName)
            {
                case "dvn":
                    Console.WriteLine(message);
                    break;

                case "dvngui":
                    // GUI logic will go here.
                    break;

                default:
                    // Oops!
                    break;
            }
        }
    }
}