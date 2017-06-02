using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Exceptions
    {
        public void Test()
        {
            
            try
            {

                User user = new User("user1@gmail.com", "Secret");
                user = null;
                throw new ArgumentNullException(nameof(user));

                //Sign up user...
                //Email in use
                throw new Exception("Email in use");
            }
            catch(ArgumentNullException exception)
            {
                Console.WriteLine($"Null error: {exception}");

            }
            catch(Exception exception)
            {
                Console.WriteLine($"An error: {exception}");
            }
            finally
            {
            

            }

            Console.WriteLine("OK");
            
        }

    }
}
