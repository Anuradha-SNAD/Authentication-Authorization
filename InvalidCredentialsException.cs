namespace ProductManagement.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string msg): base(msg)
        { 
        }
    }
}
