namespace spots.Models.Account.Viewmodels.Extentions
{
    public static class LoginViewModelExtensions
    {
        public static LoginViewModel WithReturnUrl(this LoginViewModel loginViewModel, string returnUrl)
        {
            loginViewModel.ReturnUrl = returnUrl;
            return loginViewModel;
        }
    }
}