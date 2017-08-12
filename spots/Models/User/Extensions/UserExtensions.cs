namespace spots.Models.User.Extensions
{
    public static class UserExtensions
    {
        public static SpotUser WithEmail(this SpotUser user, string email)
        {
            user.Email = email;
            return user;
        }
    }
}