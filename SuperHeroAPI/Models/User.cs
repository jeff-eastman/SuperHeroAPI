namespace SuperHeroAPI.Models
{
    public class User
    {
        //This is what we'll send back to the user after they've succesfully logged in.  Equiv to UserDto
        public string UserName { get; set; }

        public string Token { get; set; }

        public string EmailAddress { get; set; }

        public string Country { get; set; }


    }
}
